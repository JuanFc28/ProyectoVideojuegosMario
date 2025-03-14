using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded = true;  // variable de los objetos del piso para simular la tierra
    private bool isCrouching = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Verifica si Mario está en el suelo al iniciar el juego
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, LayerMask.GetMask("Ground", "PlataformaDinamica"));
        isGrounded = hit.collider != null;  // Si golpea algo, está en el suelo
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        // Movimiento horizontal
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        // Control de dirección (voltear sprite)
        if (moveInput > 0)
            spriteRenderer.flipX = false;  // Mirar a la derecha
        else if (moveInput < 0)
            spriteRenderer.flipX = true;   // Mirar a la izquierda

        // Saltar
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isCrouching)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }

        
        // Actualizar animaciones
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //MArio se convierte en hijo, para que se mueva cuando se mueve la plataforma
        if (collision.gameObject.CompareTag("DinamicPlatform"))
        {
            transform.SetParent(collision.transform);  // Asegurar que Mario sea hijo de la plataforma
            rb.linearVelocity = Vector2.zero;  // Resetear la velocidad para evitar movimiento involuntario
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            transform.SetParent(null);  // Si toca el suelo normal, ya no es hijo de la plataforma
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DinamicPlatform"))
        {
            transform.parent = null;  // Mario deja de ser hijo de la plataforma
        }
    }
}


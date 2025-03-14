using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 3f;
    public float moveDistance = 7f;
    private Vector3 startPosition;
    private int direction = 1;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.position += Vector3.right * direction * speed * Time.deltaTime;

        // Invertir dirección si se mueve demasiado lejos de su punto de inicio
        if (Mathf.Abs(transform.position.x - startPosition.x) > moveDistance)
        {
            direction *= -1; // Cambia de dirección
        }
    }
}


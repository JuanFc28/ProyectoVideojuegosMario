using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public float parallaxFactor; // Controla la velocidad del parallax
    public float cameraSpeed = 5f; // Velocidad de movimiento automático de la cámara
    private Transform cameraTransform;
    private Vector3 previousCameraPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraTransform = Camera.main.transform;
        previousCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Mover la cámara automáticamente
        cameraTransform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);

        // Calcular el movimiento de la cámara para el parallax
        Vector3 deltaMovement = cameraTransform.position - previousCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxFactor, 0, 0);
        previousCameraPosition = cameraTransform.position;
    }
}

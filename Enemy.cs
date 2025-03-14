using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject explosionPrefab; // Prefab de la explosión

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisión detectada con: " +other.gameObject.name); // Debug para ver si se detecta la colisión

        if (other.CompareTag("Player")) // Verifica si choca con el jugador
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity); // Crea la explosión
            Destroy(gameObject); // Destruye el enemigo
        }
    }

}


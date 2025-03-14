using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject explosionPrefab; // Prefab de la explosi�n

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisi�n detectada con: " +other.gameObject.name); // Debug para ver si se detecta la colisi�n

        if (other.CompareTag("Player")) // Verifica si choca con el jugador
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity); // Crea la explosi�n
            Destroy(gameObject); // Destruye el enemigo
        }
    }

}


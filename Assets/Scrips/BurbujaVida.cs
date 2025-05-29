using UnityEngine;

public class BurbujaVida : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Sumar una vida extra
            GameManager.instance.vidas++;
            Debug.Log("¡Vida extra obtenida! Vidas: " + GameManager.instance.vidas);

            // Destruir la burbuja
            Destroy(gameObject);

            // Actualizar UI
            UIManager.Instance.ActualizarUI();
        }
    }
}

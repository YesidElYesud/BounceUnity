using UnityEngine;

public class Anillo : MonoBehaviour
{
    public Sprite anilloRecogido;  // El sprite del anillo cuando ya fue recogido
    private bool recogido = false; // Para evitar que se recoja varias veces

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!recogido && collision.CompareTag("Player"))
        {
            recogido = true;

            // Reducir la cantidad de anillos restantes en el GameManager
            GameManager.instance.anillosRestantes--;

            // Cambiar sprite
            if (anilloRecogido != null)
            {
                GetComponent<SpriteRenderer>().sprite = anilloRecogido;
            }

            // Actualizar UI
            UIManager.Instance.OnAnillosCambiados();
        }
    }
}

using UnityEngine;

public class DesplazarCamaraEnColision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Obtener la cámara principal
            Camera camara = Camera.main;

            if (camara != null)
            {
                Vector3 nuevaPosicion = camara.transform.position;
                nuevaPosicion.y = transform.position.y;  // Ajustar solo la Y
                camara.transform.position = nuevaPosicion;
            }
        }
    }
}

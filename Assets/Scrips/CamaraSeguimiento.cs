using UnityEngine;

public class CamaraSeguimiento : MonoBehaviour
{
    public Transform jugador;          // Referencia al jugador
    public float margenX = 2f;         // Margen horizontal
    public float suavizado = 0.1f;     // Suavizado del movimiento
    private Vector3 velocidad = Vector3.zero;

    void LateUpdate()
    {
        if (jugador != null)
        {
            Vector3 posicionDeseada = transform.position;

            // Verificar si el jugador se sale del margen horizontal
            float diferenciaX = jugador.position.x - transform.position.x;

            if (Mathf.Abs(diferenciaX) > margenX)
            {
                // Mover la cámara en X solo si sale del margen
                posicionDeseada.x = jugador.position.x - Mathf.Sign(diferenciaX) * margenX;
            }

            // Mantener la posición Y y Z actual de la cámara
            posicionDeseada.y = transform.position.y;
            posicionDeseada.z = transform.position.z;

            // Suavizar movimiento hacia la posición deseada
            transform.position = Vector3.SmoothDamp(transform.position, posicionDeseada, ref velocidad, suavizado);
        }
    }
}

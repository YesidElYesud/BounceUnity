using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemigoEstatico : MonoBehaviour
{
    private Vector3 origenNivel; // Origen donde inicia el jugador
    private Transform checkpointActual; // Posición del último checkpoint

    private void Start()
    {
        // Guardamos el origen del nivel (posición inicial del jugador)
        origenNivel = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Accedemos al controlador del jugador
            PlayerController player = collision.GetComponent<PlayerController>();

            if (player != null)
            {
                // Si tiene checkpoint guardado, lo mueve allí, si no, al origen
                if (player.ultimoCheckpoint != null)
                {
                    collision.transform.position = player.ultimoCheckpoint.position;
                }
                else
                {
                    collision.transform.position = origenNivel;
                }

                // Resta una vida
                player.vidas--;

                // Si se quedó sin vidas, reiniciamos el nivel pero guardamos puntaje
                if (player.vidas <= 0)
                {
                    PlayerPrefs.SetInt("Puntos", player.puntos); // Guardar puntaje
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reiniciar nivel
                }
            }
        }
    }
}

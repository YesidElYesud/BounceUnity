using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemigoMovimientoCiclico : MonoBehaviour
{
    public Transform puntoA;  // Primer punto (referencia)
    public Transform puntoB;  // Segundo punto (referencia)
    public float velocidad = 2f;  // Velocidad de patrulla

    private Vector3 origenNivel;  // Origen del jugador
    private Vector3 destinoActual;

    private void Start()
    {
        // Guardamos la posición original del jugador para respawn
        origenNivel = GameObject.FindGameObjectWithTag("Player").transform.position;

        // Determinar el punto más cercano como destino inicial
        if (puntoA != null && puntoB != null)
        {
            float distanciaA = Vector3.Distance(transform.position, puntoA.position);
            float distanciaB = Vector3.Distance(transform.position, puntoB.position);

            destinoActual = (distanciaA < distanciaB) ? puntoB.position : puntoA.position;
        }
    }

    private void Update()
    {
        if (puntoA != null && puntoB != null)
        {
            // Mover hacia el destino actual
            transform.position = Vector3.MoveTowards(transform.position, destinoActual, velocidad * Time.deltaTime);

            // Si llegamos, cambiar al otro punto
            if (Vector3.Distance(transform.position, destinoActual) < 0.1f)
            {
                destinoActual = (destinoActual == puntoA.position) ? puntoB.position : puntoA.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if (player != null)
            {
                // Si tiene checkpoint, respawn allí; si no, al origen
                if (player.ultimoCheckpoint != null)
                {
                    collision.transform.position = player.ultimoCheckpoint.position;
                }
                else
                {
                    collision.transform.position = origenNivel;
                }

                // Restar vida
                player.vidas--;

                // Si se queda sin vidas, guardar puntaje y reiniciar nivel
                if (player.vidas <= 0)
                {
                    PlayerPrefs.SetInt("Puntos", player.puntos);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }
}

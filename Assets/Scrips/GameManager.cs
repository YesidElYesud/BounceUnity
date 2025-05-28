using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int vidas = 3;
    public int puntaje = 0;
    public int nivelActual = 1; // Nuevo: para mostrar nivel en UI
    public int anillosRestantes = 0; // Nuevo: para mostrar anillos en UI

    [HideInInspector]
    public Vector3 puntoInicio;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IniciarNivel(Vector3 inicio)
    {
        puntoInicio = inicio;
    }

    public void RestarVida()
    {
        vidas--;
        if (UIManager.Instance != null)
            UIManager.Instance.OnVidasCambiadas();

        if (vidas <= 0)
        {
            ReiniciarNivel();
        }
        else
        {
            RespawnJugador();
        }
    }

    public void SumarPuntos(int cantidad)
    {
        puntaje += cantidad;
        if (UIManager.Instance != null)
            UIManager.Instance.OnPuntosCambiados();
    }

    public void SumarAnillo()
    {
        anillosRestantes++;
        if (UIManager.Instance != null)
            UIManager.Instance.OnAnillosCambiados();
    }

    private void RespawnJugador()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            PlayerController pc = player.GetComponent<PlayerController>();
            if (pc != null && pc.ultimoCheckpoint != null)
                player.transform.position = pc.ultimoCheckpoint.position;
            else
                player.transform.position = puntoInicio;

            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.linearVelocity = Vector2.zero;
        }
    }

    private void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

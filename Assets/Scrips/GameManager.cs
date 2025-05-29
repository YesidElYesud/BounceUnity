using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int vidas = 3;
    public int puntaje = 0;
    public int nivelActual = 1;
    public int anillosRestantes = 0;

    [HideInInspector]
    public Vector3 puntoInicio;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;  // Agregamos este evento para inicializar al cargar escena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        // Eliminamos el evento para evitar duplicados
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InicializarNivel(scene.buildIndex);
    }

    private void InicializarNivel(int buildIndex)
    {
        switch (buildIndex)
        {
            case 1:  // Nivel 1
                anillosRestantes = 5;
                vidas = 3;  // Opcional: resetear vidas si quieres
                nivelActual = 1;
                puntaje = 0;  // Opcional: reiniciar puntaje si quieres
                break;

            case 2:  // Nivel 2
                anillosRestantes = 8;
                nivelActual = 2;
                break;

            // Agrega más casos para otros niveles
            default:
                anillosRestantes = 0;
                nivelActual = buildIndex;
                break;
        }

        // Actualiza la UI si es necesario
        if (UIManager.Instance != null)
        {
            UIManager.Instance.OnAnillosCambiados();
            UIManager.Instance.OnVidasCambiadas();
            UIManager.Instance.OnPuntosCambiados();
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

using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalFinal : MonoBehaviour
{
    private bool portalActivo = false;

    void Start()
    {
        // Inicialmente desactivado
        gameObject.SetActive(false);
    }

    void Update()
    {
        // Si los anillos restantes son 0 y el portal no está activo
        if (!portalActivo && GameManager.instance.anillosRestantes <= 0)
        {
            portalActivo = true;
            gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (portalActivo && collision.CompareTag("Player"))
        {
            CargarSiguienteNivel();
        }
    }

    void CargarSiguienteNivel()
    {
        int nivelActual = SceneManager.GetActiveScene().buildIndex;
        int siguienteNivel = nivelActual + 1;

        // Asegúrate de tener más escenas configuradas en Build Settings
        if (siguienteNivel < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(siguienteNivel);
        }
        else
        {
            Debug.Log("No hay más niveles, reiniciando desde el principio.");
            SceneManager.LoadScene(0);
        }
    }
}

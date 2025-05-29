using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalFinal : MonoBehaviour
{
    private bool portalActivo = false;
    private SpriteRenderer spriteRenderer;
    private Collider2D portalCollider; // Cambié el nombre para evitar conflicto

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        portalCollider = GetComponent<Collider2D>();

        // Inicialmente desactivamos solo la parte visual y el collider
        if (spriteRenderer != null) spriteRenderer.enabled = false;
        if (portalCollider != null) portalCollider.enabled = false;
    }

    void Update()
    {
        if (!portalActivo && GameManager.instance.anillosRestantes <= 0)
        {
            portalActivo = true;
            if (spriteRenderer != null) spriteRenderer.enabled = true;
            if (portalCollider != null) portalCollider.enabled = true;
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

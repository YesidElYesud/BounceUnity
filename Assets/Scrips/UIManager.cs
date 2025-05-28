using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI nivelText, anillosText, vidasText, puntosText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        ActualizarUI(); // Mostrar valores iniciales
    }

    public void ActualizarUI()
    {
        if (GameManager.instance != null)
        {
            nivelText.text = "Nivel: " + GameManager.instance.nivelActual;
            anillosText.text = "Anillos: " + GameManager.instance.anillosRestantes;
            vidasText.text = "Vidas: " + GameManager.instance.vidas;
            puntosText.text = "Puntos: " + GameManager.instance.puntaje;
        }
    }

    public void OnVidasCambiadas()
    {
        ActualizarUI();
    }

    public void OnPuntosCambiados()
    {
        ActualizarUI();
    }

    public void OnAnillosCambiados()
    {
        ActualizarUI();
    }

    private void Update()
    {
        // Si deseas que se actualice cada frame:
        // ActualizarUI();
    }
}

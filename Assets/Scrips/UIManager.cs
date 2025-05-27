using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI nivelText, anillosText, vidasText, puntosText;
    private PlayerController jugador;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void ActualizarUI()
    {
        nivelText.text = "Nivel: " + GameManager.Instance.nivelActual;
        anillosText.text = "Anillos: " + GameManager.Instance.anillosRestantes;
        vidasText.text = "Vidas: " + jugador.vidas;
        puntosText.text = "Puntos: " + jugador.puntos;
    }

    void Update()
    {
        ActualizarUI();
    }
}


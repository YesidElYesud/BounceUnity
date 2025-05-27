using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int anillosRestantes;
    public int nivelActual = 1;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        anillosRestantes = GameObject.FindGameObjectsWithTag("Anillo").Length;
        UIManager.Instance.ActualizarUI();
    }

    public void AnilloRecogido()
    {
        anillosRestantes--;
        UIManager.Instance.ActualizarUI();
        if (anillosRestantes <= 0)
            PasarNivel();
    }

    public void PasarNivel()
    {
        nivelActual++;
        // Aquí puedes cargar la siguiente escena o mostrar pantalla de nivel completado
        SceneManager.LoadScene("Nivel" + nivelActual);
    }

    public void GameOver()
    {
        // Reiniciar el nivel o mostrar pantalla de fin
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

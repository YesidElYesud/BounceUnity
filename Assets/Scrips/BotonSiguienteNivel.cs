using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonSiguienteNivel : MonoBehaviour
{
    public void CargarNivel1()
    {
        SceneManager.LoadScene(1);  // Asumiendo que el nivel 1 es el siguiente
    }
}

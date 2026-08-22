using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    // Conectar este método a CUALQUIER botón que tenga que cambiar de escena.
    // El nombre de la escena se pasa como parámetro desde el Inspector,
    // no hace falta escribir un método nuevo por cada botón.
    public void CargarEscena(string nombreEscena)
    {
        Time.timeScale = 1f; // por las dudas venís de un menú de pausa, evita que la próxima escena arranque congelada
        SceneManager.LoadScene(nombreEscena);
    }
}
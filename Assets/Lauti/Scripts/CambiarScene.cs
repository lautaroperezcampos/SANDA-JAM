using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    // Conectar este método a CUALQUIER botón que tenga que cambiar de escena.
    // El nombre de la escena se pasa como parámetro desde el Inspector,
    // no hace falta escribir un método nuevo por cada botón.

    public void CargarEscena(int nivel)
    {
        Time.timeScale = 1f; // por las dudas venís de un menú de pausa, evita que la próxima escena arranque congelada
        if (nivel == 1)
        {
            SceneManager.LoadScene("Nivel1");
        }
        else if (nivel == 2)
        {
            SceneManager.LoadScene("Nivel2");
        }
        else if (nivel == 3)
        {
            SceneManager.LoadScene("Nivel3");
        }

    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaManager : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject panelPausa; // el panel de UI que contiene la ventana de pausa

    [Header("Escena del menú principal")]
    public string nombreEscenaMenu = "MenuPrincipal"; // tiene que coincidir EXACTO con el nombre de la escena en Build Settings

    private bool estaPausado = false;

    // Conectar al botón de pausa que ya armaste (OnClick en el Inspector)
    public void Pausar()
    {
        panelPausa.SetActive(true);
        Time.timeScale = 0f;
        estaPausado = true;
    }

    // Conectar al botón "Reanudar" del panel de pausa
    public void Reanudar()
    {
        panelPausa.SetActive(false);
        Time.timeScale = 1f;
        estaPausado = false;
    }

    // Conectar al botón "Volver al menú" del panel de pausa
    public void VolverAlMenu()
    {
        // Importante: hay que restaurar el timeScale ANTES de cambiar de escena,
        // si no, el menú principal puede arrancar congelado.
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombreEscenaMenu);
    }
}
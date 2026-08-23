using UnityEngine;

public class MostrarObra : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject panelObra; // el panel/imagen de referencia de la reliquia

    // Conectar este único método al botón (OnClick en el Inspector)
    public void ToggleObra()
    {
        panelObra.SetActive(!panelObra.activeSelf);
    }
}
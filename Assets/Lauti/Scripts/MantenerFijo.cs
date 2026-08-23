using UnityEngine;

// Poné este script en CUALQUIER elemento de UI que se esté moviendo solo
// (por el zoom de la cámara u otra causa que no encontremos). Fuerza su
// posición de vuelta a donde arrancó, todos los frames, sin excepción.
[RequireComponent(typeof(RectTransform))]
public class MantenerFijo : MonoBehaviour
{
    private RectTransform rt;
    private Vector2 posicionFija;
    private Vector3 escalaFija;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        posicionFija = rt.anchoredPosition; // guarda dónde arrancó, apenas inicia
        escalaFija = rt.localScale;         // guarda el tamaño con el que arrancó
    }

    void LateUpdate()
    {
        // Se ejecuta después de todo lo demás en el frame (incluido el zoom),
        // así pisa cualquier corrimiento o cambio de tamaño que haya pasado.
        rt.anchoredPosition = posicionFija;
        rt.localScale = escalaFija;
    }
}
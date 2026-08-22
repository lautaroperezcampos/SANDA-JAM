using UnityEngine;
using UnityEngine.InputSystem;

// Este script va en la CÁMARA PRINCIPAL (Main Camera), no en las piezas.
// Requiere que la cámara sea Orthographic (típico en un juego 2D).
[RequireComponent(typeof(Camera))]
public class ZoomCamara : MonoBehaviour
{
    [Header("Niveles de zoom (orthographic size)")]
    [Tooltip("Índice 0 = normal, 1 = zoom nivel 1, 2 = zoom nivel 2 (como el AWP)")]
    public float[] niveles = new float[] { 10f, 6f, 3f };

    [Header("Velocidad de la transición suave")]
    public float velocidadZoom = 8f;

    private Camera cam;
    private int nivelActual = 0;
    private Vector3 posicionCentral; // la posición "hogar" de la cámara, en el nivel normal

    void Awake()
    {
        cam = GetComponent<Camera>();
        posicionCentral = transform.position; // se guarda una sola vez, al arrancar
    }

    void Update()
    {
        // Cada apretada de E avanza un nivel, y al pasar el último vuelve al 0
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            nivelActual = (nivelActual + 1) % niveles.Length;
        }

        float tamañoObjetivo = niveles[nivelActual];

        if (nivelActual == 0)
        {
            // Nivel normal: no seguimos al cursor, volvemos derecho a la posición central
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, tamañoObjetivo, Time.deltaTime * velocidadZoom);
            transform.position = Vector3.Lerp(transform.position, posicionCentral, Time.deltaTime * velocidadZoom);
        }
        else
        {
            // Niveles de zoom: el zoom entra hacia donde apunta el cursor
            Vector3 mouseAntes = GetMouseWorldPosition();

            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, tamañoObjetivo, Time.deltaTime * velocidadZoom);

            Vector3 mouseDespues = GetMouseWorldPosition();

            transform.position += (mouseAntes - mouseDespues);
        }
    }

    // Convierte la posición del mouse en pantalla a una posición del mundo,
    // usando el tamaño ACTUAL de la cámara (por eso hay que llamarla antes y después del Lerp)
    private Vector3 GetMouseWorldPosition()
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = cam.ScreenToWorldPoint(mouseScreenPos);
        mouseWorldPos.z = 0f;
        return mouseWorldPos;
    }
}
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class MoverPieza : MonoBehaviour
{
    [Header("Borde al agarrar")]
    public Color colorBorde = Color.yellow;
    public float grosorBorde = 1.15f; // qué tanto más grande es el borde (15%)

    private bool isDragging = false;
    private Vector3 dragOffset;

    private SpriteRenderer sr;
    private GameObject borde;
    private SpriteRenderer srBorde;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        CrearBorde();
    }

    // Genera el cuadrado de borde como hijo, una sola vez, al arrancar
    void CrearBorde()
    {
        borde = new GameObject("Borde");
        borde.transform.SetParent(transform);
        borde.transform.localPosition = Vector3.zero;
        borde.transform.localScale = Vector3.one * grosorBorde;

        srBorde = borde.AddComponent<SpriteRenderer>();
        srBorde.sprite = sr.sprite;           // mismo dibujo que la pieza
        srBorde.color = colorBorde;           // pero de un solo color
        srBorde.sortingOrder = sr.sortingOrder - 1; // se dibuja DETRÁS de la pieza

        borde.SetActive(false); // arranca oculto
    }

    void OnMouseDown()
    {
        isDragging = true;
        dragOffset = transform.position - GetMouseWorldPosition();

        borde.SetActive(true); // muestra el marco de color
    }

    void OnMouseDrag()
    {
        if (!isDragging) return;
        transform.position = GetMouseWorldPosition() + dragOffset;
    }

    void OnMouseUp()
    {
        isDragging = false;

        borde.SetActive(false); // oculta el marco de nuevo
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        mouseWorldPos.z = 0f;
        return mouseWorldPos;
    }
}
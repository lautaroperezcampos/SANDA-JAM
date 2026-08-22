using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class MoverPieza : MonoBehaviour
{
    [Header("Borde al agarrar")]
    public Color colorBorde = Color.yellow;
    public float grosorBorde = 1.15f; // qué tanto más grande es el borde (15%)

    [Header("Estado")]
    public bool tomada = false; // true apenas el jugador la agarra por primera vez

    private bool isDragging = false;
    private Vector3 dragOffset;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private GameObject borde;
    private SpriteRenderer srBorde;

    [Header("Escala")]
    public float escalaEnSelector = 0.3f;
    public float escalaFueraDeSelector = 0.6f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        CrearBorde();
        transform.localScale = Vector3.one * escalaEnSelector;
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

        // A partir de acá, esta pieza "sale" del selector: el paginado
        // ya no la va a apagar ni reposicionar nunca más.
        if (!tomada)
        {
            transform.localScale = Vector3.one * escalaFueraDeSelector;
        }
        tomada = true;
    }

    void OnMouseDrag()
    {
        if (!isDragging) return;
        transform.position = GetMouseWorldPosition() + dragOffset;
        rb.simulated = false;


    }
    // NUEVO: rota la pieza 90° con la tecla R, solo mientras se arrastra
    void Update()
    {
        if (!isDragging) return;

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            transform.Rotate(0f, 0f, -90f); // -90 = sentido horario (derecha, abajo, izquierda, arriba)
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        rb.simulated = true;
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
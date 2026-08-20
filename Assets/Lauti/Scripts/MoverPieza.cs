using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider2D))]
public class MoverPieza : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 dragOffset;

    void Start()
    {
        Debug.Log("El script MoverPieza está corriendo en: " + gameObject.name);
    }

    void OnMouseDown()
    {
        Debug.Log("CLICK EN: " + gameObject.name);
        isDragging = true;
        dragOffset = transform.position - GetMouseWorldPosition();
    }
    void OnMouseDrag()
    {
        if (!isDragging) return;
        transform.position = GetMouseWorldPosition() + dragOffset;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        mouseWorldPos.z = 0f;
        return mouseWorldPos;
    }
}
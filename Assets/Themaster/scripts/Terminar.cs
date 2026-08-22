using UnityEngine;

public class Terminar : MonoBehaviour
{
    public int cantidadPiezas = 0;
    public GameObject Listo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Listo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
     if(cantidadPiezas == 6)
        {
            Listo.SetActive(true);
        }
        else
        {
            Listo.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pieza"))
        {
            cantidadPiezas++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pieza"))
        {
            cantidadPiezas--;
        }
    }
}

using UnityEngine;

public class Terminar : MonoBehaviour
{
    public int cantidadPiezas = 0;
    public int nivel = 0;
    public GameObject Listo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Listo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
     if( nivel == 1)
        {
            if (cantidadPiezas == 6)
            {
                Listo.SetActive(true);
            }
            else
            {
                Listo.SetActive(false);
            }
        }
        else if(nivel == 2)
        {
            if (cantidadPiezas == 14)
            {
                Listo.SetActive(true);
            }
            else
            {
                Listo.SetActive(false);
            }
        }
        else if (nivel == 3)
        {
            if (cantidadPiezas == 33)
            {
                Listo.SetActive(true);
            }
            else
            {
                Listo.SetActive(false);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pieza"))
        {
            cantidadPiezas++;
            nivel = 1;
        }

        if (collision.CompareTag("Piezalvl2"))
        {
            cantidadPiezas++;
            nivel = 2;
        }
        if (collision.CompareTag("Piezalvl3"))
        {
            cantidadPiezas++;
            nivel = 3;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pieza"))
        {
            cantidadPiezas--;
        }
        if (collision.CompareTag("Piezalvl2"))
        {
            cantidadPiezas--;
        }
        if (collision.CompareTag("Piezalvl3"))
        {
            cantidadPiezas--;
        }
    }
}

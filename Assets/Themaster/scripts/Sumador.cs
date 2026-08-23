using UnityEngine;

public class Sumador : MonoBehaviour
{
    public Puntaje puntos;
    public bool activar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activar = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        puntos = FindAnyObjectByType<Puntaje>();

        if (collision.CompareTag("Pieza"))
        {
            if (activar)
            {
                puntos.Puntos += 7;
            }

            activar = false;
        }

        if (collision.CompareTag("Piezalvl2"))
        {
            if (activar)
            {
                puntos.Puntos += 1;
            }

            activar = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        

    }
}

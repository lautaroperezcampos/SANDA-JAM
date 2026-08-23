using UnityEngine;

public class Sumador2 : MonoBehaviour
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

        if (collision.CompareTag("Piedralvl3"))
        {
            if (activar)
            {
                puntos.Puntos += 7;
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

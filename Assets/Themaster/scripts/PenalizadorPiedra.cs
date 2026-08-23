using UnityEngine;

public class PenalizadorPiedra : MonoBehaviour
{
    public Puntaje puntos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Piedralvl3"))
        {
            puntos = FindAnyObjectByType<Puntaje>();
            puntos.Perdidas += 2;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Piedralvl3"))
        {
            puntos.Perdidas -= 2;
        }


    }
}

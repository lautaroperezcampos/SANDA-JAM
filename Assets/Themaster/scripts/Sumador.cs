using UnityEngine;

public class Sumador : MonoBehaviour
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


        if (collision.CompareTag("Pieza"))
        {
            puntos = FindAnyObjectByType<Puntaje>();
            puntos.Puntos += 7;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {


        if (collision.CompareTag("Pieza"))
        {
            puntos.Puntos -= 7;
        }
    }
}

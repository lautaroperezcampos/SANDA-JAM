using UnityEngine;

public class Puntaje : MonoBehaviour
{
    public float Puntos;

    public bool Derrota;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Puntos = 100;
    }

    // Update is called once per frame
    void Update()
    {

        if(Puntos <= 80 % Puntos)
        {
            Derrota = true;
        }

    }
}

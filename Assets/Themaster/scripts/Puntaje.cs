using UnityEngine;

public class Puntaje : MonoBehaviour
{
    public float Puntos;
    public int Perdidas;
    public bool Derrota;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Puntos = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Puntos < 80)
        {
            Derrota = true;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Restar();
        }
    }
    void Restar()
    {
        Puntos = Puntos - Perdidas; 
    }
}

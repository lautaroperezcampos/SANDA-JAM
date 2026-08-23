using UnityEngine;

public class Puntaje : MonoBehaviour
{
    public float Puntos;
    public float Porcentaje;
    public int Perdidas;
    public bool Derrota;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Puntos < 80)
        {
            Derrota = true;
        }
        else
        {
            Derrota = false;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Restar();
        }

        Porcentaje = 100 / 100 * Puntos;
    }
    void Restar()
    {
        Puntos = Puntos - Perdidas; 
    }
}

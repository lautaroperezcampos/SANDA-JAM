using UnityEngine;
using System.Collections.Generic;

public class Union : MonoBehaviour
{
    public List<GameObject> PiezasDelNivel1;
    public GameObject ubicador;
    public GameObject Padre;
    public GameObject puntuador;
    private void Awake()
    {
        puntuador.SetActive(false);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            UnificarPiezasNivel1();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Padre.transform.position = Vector2.zero;

            puntuador.SetActive(true);
       
        }
    }
    public void UnificarPiezasNivel1()
    {
         Padre = new GameObject("PiezaCompletaLvl1");

        Vector2 centrosuma = Vector2.zero;
        foreach(GameObject pieza in PiezasDelNivel1)
        {
            centrosuma += (Vector2)pieza.transform.position;
        }
        Vector2 centropromedio = centrosuma / PiezasDelNivel1.Count;

        Padre.transform.position = new Vector2(centropromedio.x, centropromedio.y);
        foreach(GameObject pieza in PiezasDelNivel1)
        {
            if(pieza != null )
            {
                pieza.transform.SetParent(Padre.transform, true);
            }
        }
        DontDestroyOnLoad(Padre);
        
       
    }
}

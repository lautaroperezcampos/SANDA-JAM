using UnityEngine;
using System.Collections.Generic;

public class Union : MonoBehaviour
{
    public List<GameObject> PiezasDelNivel1;
    public GameObject ubicador;
    public GameObject Padre;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            UnificarPiezasNivel1();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Padre.transform.localPosition = Vector3.zero;
        }
    }
    public void UnificarPiezasNivel1()
    {
         Padre = new GameObject("PiezaCompletaLvl1");



        foreach(GameObject pieza in PiezasDelNivel1)
        {
            if(pieza != null )
            {
                pieza.transform.SetParent(Padre.transform, false);
            }
        }
        DontDestroyOnLoad(Padre);
        
       
    }
}

using UnityEngine;
using System.Collections.Generic;

public class Union : MonoBehaviour
{
    public List<GameObject> PiezasDelNivel1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            UnificarPiezasNivel1();
        }
    }
    public void UnificarPiezasNivel1()
    {
        GameObject Padre = new GameObject("PiezaCompletaLvl1");

        Padre.transform.position = PiezasDelNivel1[0].transform.position;

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

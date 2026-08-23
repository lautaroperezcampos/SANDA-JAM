using UnityEngine;
using System.Collections.Generic;

// Poné este script en CADA selector por separado (uno en el selector A,
// otro componente igual en el selector B). Cada instancia es independiente:
// no comparte piezas ni página con el otro selector.
public class SelectorPiezas : MonoBehaviour
{
    [Header("Piezas de ESTE selector (hoy 5, a futuro pueden ser más)")]
    public List<GameObject> piezas;

    [Header("Posiciones fijas de la barra (5 slots)")]
    public Transform[] slots; // arrastrar en el Inspector las 5 posiciones de la barra

    [Header("Config")]
    public int piezasPorPagina = 5;

    private int paginaActual = 0;

    void Start()
    {
        MostrarPagina(0);
    }

    void MostrarPagina(int pagina)
    {
        int inicio = pagina * piezasPorPagina;
        int fin = inicio + piezasPorPagina;

        for (int i = 0; i < piezas.Count; i++)
        {
            // Chequeamos si la pieza está tomada, sea cual sea de los 2 scripts que tenga
            // (MoverPieza en Nivel1/Nivel2, MoverPieza2 en Nivel3)
            bool piezaTomada = false;

            MoverPieza mp = piezas[i].GetComponent<MoverPieza>();
            if (mp != null)
            {
                piezaTomada = mp.tomada;
            }
            else
            {
                MoverPieza2 mp2 = piezas[i].GetComponent<MoverPieza2>();
                if (mp2 != null) piezaTomada = mp2.tomada;
            }

            // Si el jugador ya la agarró alguna vez, no la tocamos para nada:
            // sigue viva donde el jugador la haya dejado, sin importar la página.
            if (piezaTomada) continue;

            bool perteneceAEstaPagina = (i >= inicio && i < fin);
            piezas[i].SetActive(perteneceAEstaPagina);

            if (perteneceAEstaPagina)
            {
                int slotIndex = i - inicio;
                piezas[i].transform.position = slots[slotIndex].position;
            }
        }

        paginaActual = pagina;
    }

    // Conectar este método al botón de la flecha DERECHA (OnClick en el Inspector)
    public void Siguiente()
    {
        int siguienteInicio = (paginaActual + 1) * piezasPorPagina;

        // Si no hay piezas para la próxima página, no hacemos nada
        if (siguienteInicio >= piezas.Count) return;

        MostrarPagina(paginaActual + 1);
    }

    // Conectar este método al botón de la flecha IZQUIERDA (OnClick en el Inspector)
    public void Anterior()
    {
        if (paginaActual == 0) return; // ya estamos en la primera página

        MostrarPagina(paginaActual - 1);
    }
}
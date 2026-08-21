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
        // Primero apagamos todas las piezas de este selector
        foreach (var pieza in piezas)
        {
            pieza.SetActive(false);
        }

        // Prendemos y ubicamos solo las que corresponden a esta página
        int inicio = pagina * piezasPorPagina;
        for (int i = 0; i < piezasPorPagina; i++)
        {
            int index = inicio + i;
            if (index >= piezas.Count) break; // no hay más piezas, cortamos

            piezas[index].SetActive(true);
            piezas[index].transform.position = slots[i].position;
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
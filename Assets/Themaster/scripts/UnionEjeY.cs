using UnityEngine;

public class UnionEjeY : MonoBehaviour
{
    public GameObject PiezaPrincipal;
    public bool verificador;
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
        verificador = true;
        if (collision.CompareTag("Arriba"))
        {
            PiezaPrincipal.GetComponent<SistemaUnionPrincipal>().Padre = collision.transform;
            PiezaPrincipal.GetComponent<SistemaUnionPrincipal>().Unificar = true;
        }
    }
}

using UnityEngine;

public class SistemaUnionPrincipal : MonoBehaviour
{
    public Transform Padre;
    public bool verificador;
    public bool Unificar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Unir(Unificar);
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.SetParent(null);
        }

    }
    void Unir(bool i)
    {
        if (i)
        {
            transform.SetParent(Padre, false);
            i = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        verificador = true;
        if (collision.CompareTag("Arriba"))
        {


        }
    }
}

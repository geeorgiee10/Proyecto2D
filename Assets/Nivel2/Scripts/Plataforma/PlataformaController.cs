using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class PlataformaController : MonoBehaviour
{

    [Header("Movimiento")]
    [SerializeField] private float distancia = 3f; 
    [SerializeField] private float velocidad = 2f; 
    public float velocidadMin = 1f;
    public float velocidadMax = 3f; 

    private float faseAleatoria;

    private Vector2 puntoInicial;
    private bool yendoADerecha = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        velocidad = Random.Range(velocidadMin, velocidadMax);

        puntoInicial = transform.position;

        faseAleatoria = Random.Range(0f, 1f);
    }

    void Update()
    {
        Vector2 destino = yendoADerecha ? puntoInicial + Vector2.right * distancia : puntoInicial - Vector2.right * distancia;

        transform.position = Vector2.MoveTowards(transform.position, destino, velocidad * Time.deltaTime * (1f + faseAleatoria));

        if ((Vector2)transform.position == destino)
            yendoADerecha = !yendoADerecha;
    }

    
}

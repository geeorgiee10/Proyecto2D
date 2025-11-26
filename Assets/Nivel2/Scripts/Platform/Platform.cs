using UnityEngine;

public class Platform : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidad = 2f; 

    [SerializeField] string etiquetaJugador = "Player";
    [SerializeField] Transform plataforma;

    [SerializeField] private Animator animator;

    [SerializeField] private Transform puntoA;
    [SerializeField] private Transform puntoB;

    [Header("Sonidos")]
        [SerializeField] private AudioSource sonidoPlataforma;


    private bool yendoADerecha = true;
    private bool volver = false;
    private bool encima = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    void Update()
    {
        if(volver && !encima)
        {
            Volver();
        }
    }

    public void Moverse()
    {
        Vector2 destino = yendoADerecha ? puntoB.position : puntoA.position;

        transform.position = Vector2.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);

        if ((Vector2)transform.position == (Vector2)destino)
            yendoADerecha = !yendoADerecha;
    }

    public void Volver()
    {
        transform.position = Vector2.MoveTowards( transform.position,puntoA.position, velocidad * Time.deltaTime);

        if ((Vector2)transform.position == (Vector2)puntoA.position)
        {
            volver = false;
        }
            
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(etiquetaJugador))
        {
            encima = true;
            volver = false;

            collision.transform.parent = plataforma;
            animator.SetTrigger("Moverse");
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(etiquetaJugador))
        {
            if(!sonidoPlataforma.isPlaying)    
                sonidoPlataforma.Play();
            Moverse();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(sonidoPlataforma.isPlaying)    
            sonidoPlataforma.Stop();
        animator.SetTrigger("DejarMoverse");
        volver = true;
        encima = false;
        if (collision.gameObject.tag.Equals(etiquetaJugador))
        {
            if(collision.transform != null && transform != null &&
            collision.gameObject.activeInHierarchy && gameObject.activeInHierarchy)
            {
                collision.gameObject.transform.parent = null;
            }
        }
    }

}

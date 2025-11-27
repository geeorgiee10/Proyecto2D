using UnityEngine;

public class BolaPinchos : MonoBehaviour
{
    public GameObject explosionEffect;   
    public float destroyDelay = 0.2f;

    [Header("Sonidos")]
        [SerializeField] private AudioSource sonidoBomba;

    void Awake()
    {

    }

    private void  OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            sonidoBomba.Play();
            Debug.Log("Sonido");
            Explotar();
            
        }

        if (collision.collider.CompareTag("Suelo"))
        {
            Explotar();
        }

        if (collision.collider.CompareTag("Traps"))
        {
            Explotar();
        }

        if (collision.collider.CompareTag("ObstaculosNivel2"))
        {
            Explotar();
        }
    }

    void Explotar()
    {
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject, destroyDelay);
    }
}

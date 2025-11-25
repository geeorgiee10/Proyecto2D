using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCharacter : MonoBehaviour
{

    public GameObject[] personajes; 
    public GameObject[] previews;
    public Transform puntoSpawn;

    public Transform imagenTransicion;     

    private int indexActual = 0;
    private GameObject personajeActual;

    [SerializeField] private AudioSource sonidoChangePJ;
    [SerializeField] private AudioSource sonidoSelectLevel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MostrarPersonaje();
    }

    void MostrarPersonaje()
    {

        if(personajeActual != null)
            Destroy(personajeActual);

            personajeActual = Instantiate(
                previews[indexActual],
                puntoSpawn.position,
                puntoSpawn.rotation
            );

            personajeActual.transform.position = puntoSpawn.position;
            personajeActual.transform.rotation = puntoSpawn.rotation;

            
    }

    public void Siguiente()
    {
        indexActual++;
        if(indexActual >= previews.Length)
            indexActual = 0;

        if(!sonidoChangePJ.isPlaying)    
            sonidoChangePJ.Play();

        MostrarPersonaje();
    }

    public void Anterior()
    {
        indexActual--;
        if(indexActual < 0)
            indexActual = previews.Length - 1;

        if(!sonidoChangePJ.isPlaying)    
            sonidoChangePJ.Play();

        MostrarPersonaje();
    }

    public void Jugar(string escena)
    {
        GameManager.Instance.personajeSeleccionado = personajes[indexActual];

        if(!sonidoSelectLevel.isPlaying)    
            sonidoSelectLevel.Play();

        TransicionController.Instance.CambiarEscena(escena);
    }
}

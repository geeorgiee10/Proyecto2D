using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCharacter : MonoBehaviour
{

    public GameObject[] personajes; 
    public GameObject[] previews;     
    public Transform puntoSpawn;         

    private int indexActual = 0;
    private GameObject personajeActual;

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

            if (personajeActual == null)
                Debug.LogError("NO SE INSTANCIÓ EL PERSONAJE");
            else
                Debug.Log("Instanciado en: " + personajeActual.transform.position);
    }

    public void Siguiente()
    {
        indexActual++;
        if(indexActual >= previews.Length)
            indexActual = 0;

        MostrarPersonaje();
    }

    public void Anterior()
    {
        indexActual--;
        if(indexActual < 0)
            indexActual = previews.Length - 1;

        MostrarPersonaje();
    }

    public void Jugar(string escena)
    {
        GameManager.Instance.personajeSeleccionado = personajes[indexActual];
        SceneManager.LoadScene(escena);
    }
}

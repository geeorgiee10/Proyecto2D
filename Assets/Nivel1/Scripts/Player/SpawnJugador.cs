using UnityEngine;

public class SpawnJugador : MonoBehaviour
{

    public Transform puntoSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManager.Instance == null || GameManager.Instance.personajeSeleccionado == null){
            Debug.LogError("NO HAY PERSONAJE SELECCIONADO");
            return;
        }

        GameObject pj = Instantiate(
            GameManager.Instance.personajeSeleccionado,
            puntoSpawn.position,
            puntoSpawn.rotation
        );

        pj.transform.localScale = new Vector3(1f, 1f, 1f);

        
    }

    
}

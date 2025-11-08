using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{

    public Transform puntoSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(GameManager.Instance.personajeSeleccionado != null)
        {
            Instantiate(GameManager.Instance.personajeSeleccionado, puntoSpawn.position, puntoSpawn.rotation);
        }
    }

    
}

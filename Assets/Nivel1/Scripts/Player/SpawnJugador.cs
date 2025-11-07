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

        if(Camera.main != null)
        {
            Camera.main.transform.SetParent(pj.transform);

            Camera.main.transform.localPosition = new Vector3(0, 2, -4);  
            Camera.main.transform.localRotation = Quaternion.Euler(10, 0, 0);
        }

    }

    
}

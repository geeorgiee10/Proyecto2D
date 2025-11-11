using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnJugador : MonoBehaviour
{

    public Transform puntoSpawn;


    public Transform puntoSpawnActual;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (SpawnCheckpoint.Instance.checkpointPillado == true)
            puntoSpawn.position = new Vector3(-10.23f, 3.98f, 0f);
        
        


        if (Camera.main != null)
        {
            Camera.main.transform.SetParent(puntoSpawn.transform);

            Camera.main.transform.localPosition = new Vector3(0, 2, -4);
            Camera.main.transform.localRotation = Quaternion.Euler(10, 0, 0);
        }

        StartCoroutine(Aparecer());
    
    }
    
    private IEnumerator Aparecer()
    {
        
        puntoSpawn.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(0.5f);

        GameObject pj = Instantiate(
            GameManager.Instance.personajeSeleccionado,
            puntoSpawn.position,
            puntoSpawn.rotation
        );

        pj.transform.localScale = new Vector3(1f, 1f, 1f);

        if (Camera.main != null)
        {
            Camera.main.transform.SetParent(pj.transform);

            Camera.main.transform.localPosition = new Vector3(0, 2, -4);
            Camera.main.transform.localRotation = Quaternion.Euler(10, 0, 0);
        }

        puntoSpawn.gameObject.SetActive(false);
        
        
    }

    
}

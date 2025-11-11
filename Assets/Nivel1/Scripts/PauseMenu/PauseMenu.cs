using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject panelPausa;
    public GameObject panelInstrucciones;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelPausa.SetActive(false);
        panelInstrucciones.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AbrirMenu();
        }
    }

    public void AbrirMenu()
    {
        panelPausa.SetActive(true); 
        Time.timeScale = 0;
    }

    public void CerrarMenu()
    {
        panelPausa.SetActive(false); 
        Time.timeScale = 1;
    }

    public void Instrucciones()
    {
        panelInstrucciones.SetActive(true);
    }

    public void CerrarInstrucciones()
    {
        panelInstrucciones.SetActive(false);
    }

    public void VolverMenu()
    {
        Time.timeScale = 1;

        if(GameManager.Instance != null)
            Destroy(GameManager.Instance.gameObject);

        SceneManager.LoadScene("Menu");
    }

    public void Reiniciar()
    {
        Time.timeScale = 1;
        SpawnCheckpoint.Instance.QuitarCheckpoint();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

     

     
}

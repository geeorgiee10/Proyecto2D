using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuNivel3 : MonoBehaviour
{

    public GameObject panelPausa;
    public GameObject panelInstrucciones;
    public GameObject canvas;

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
        canvas.transform.GetChild(3).gameObject.SetActive(false);
        canvas.transform.GetChild(4).gameObject.SetActive(false);
        canvas.transform.GetChild(5).gameObject.SetActive(false);
        canvas.transform.GetChild(6).gameObject.SetActive(false);
        canvas.transform.GetChild(7).gameObject.SetActive(false);
        canvas.transform.GetChild(9).gameObject.SetActive(false);
        panelInstrucciones.SetActive(true);
    }

    public void CerrarInstrucciones()
    {
        canvas.transform.GetChild(3).gameObject.SetActive(true);
        canvas.transform.GetChild(4).gameObject.SetActive(true);
        canvas.transform.GetChild(5).gameObject.SetActive(true);
        canvas.transform.GetChild(6).gameObject.SetActive(true);
        canvas.transform.GetChild(7).gameObject.SetActive(true);
        canvas.transform.GetChild(9).gameObject.SetActive(true);
        panelInstrucciones.SetActive(false);
    }

    public void VolverMenu()
    {
        Time.timeScale = 1;
        Datos.Instance.vidas = 4;
        VidasJugador.Instance.SetLives(Datos.Instance.vidas);

        if(GameManager.Instance != null)
            Destroy(GameManager.Instance.gameObject);

        SceneManager.LoadScene("Menu");
    }

    public void Reiniciar()
    {
        Time.timeScale = 1;
        Datos.Instance.vidas = 4;
        VidasJugador.Instance.SetLives(Datos.Instance.vidas);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

     

     
}

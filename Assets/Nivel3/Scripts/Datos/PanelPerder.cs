using UnityEngine;
using UnityEngine.SceneManagement;


public class PanelPerder : MonoBehaviour
{
    public GameObject panelPerder;

    public static PanelPerder Instance;

    public GameObject canvas;
    

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this; 
        }
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelPerder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PerderVidas()
    {
        Time.timeScale = 0;
        canvas.transform.GetChild(3).gameObject.SetActive(false);
        canvas.transform.GetChild(4).gameObject.SetActive(false);
        canvas.transform.GetChild(5).gameObject.SetActive(false);
        canvas.transform.GetChild(6).gameObject.SetActive(false);
        canvas.transform.GetChild(7).gameObject.SetActive(false);
        canvas.transform.GetChild(9).gameObject.SetActive(false);
        canvas.transform.GetChild(10).gameObject.SetActive(false);
        panelPerder.SetActive (true); 
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        Datos.Instance.vidas = 4;
        VidasJugador.Instance.SetLives(Datos.Instance.vidas);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

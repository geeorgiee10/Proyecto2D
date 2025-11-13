using UnityEngine;
using UnityEngine.SceneManagement;


public class PanelPerder : MonoBehaviour
{
    public GameObject panelPerder;

    public static PanelPerder Instance;
    

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
        panelPerder.SetActive (true);
        
        
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        Datos.Instance.vidas = 3;
        VidasJugador.Instance.SetLives(Datos.Instance.vidas);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

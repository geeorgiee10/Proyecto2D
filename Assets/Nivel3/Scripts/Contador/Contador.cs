using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Contador : MonoBehaviour
{
    public static Contador Instance;

    [Header("Tiempo inicial en segundos")]
    public float tiempoInicial = 10f; 

    private float tiempoRestante;
    private bool contando = true;
    
    public TextMeshProUGUI temporizador;
 
    private void Awake()
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

    void Start()
    {
        ReiniciarContador();
    }

    

    void Update()
    {
        if (contando)
        {
            tiempoRestante  -= Time.deltaTime;
            if (tiempoRestante < 0f)
                tiempoRestante = 0f;

            temporizador.text = "Time Remaining: " + FormatearTemporizador(tiempoRestante);

            if(tiempoRestante <= 0f && contando)
            {
                contando = false;
                Datos.Instance.vidas--;
                VidasJugador.Instance.LoseLife();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
            
    }


    private string FormatearTemporizador(float tiempo)
    {
        int minutos = Mathf.FloorToInt(tiempo / 60f);
        int segundos = Mathf.FloorToInt(tiempo % 60f);

        return string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    public void ReiniciarContador()
    {
        tiempoRestante = tiempoInicial;
        contando = true;

        if (temporizador != null)
            temporizador.text = "Time Remaining: " + FormatearTemporizador(tiempoRestante);
        
    }
}

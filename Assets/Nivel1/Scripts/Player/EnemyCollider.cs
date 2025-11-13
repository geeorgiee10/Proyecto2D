using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollider : MonoBehaviour
{

    [SerializeField] private float tiempoEspera;
    private PlayerMove playerMove;
    private PlayerAnimation playerAnimation;
    //private VidasJugador vidasJugador;

    private VidasJugador vidasJugador;

    private bool inmune;

    /*[Header("Sonidos")]
    [SerializeField] private AudioSource sonidoMuerte;*/


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        playerAnimation = GetComponent<PlayerAnimation>();
        vidasJugador = GetComponent<VidasJugador>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            if(!inmune)
                StartCoroutine(PararYReiniciar());
        }

        if (other.collider.CompareTag("ObstaculosNivel2"))
        {
            if(!inmune)
                StartCoroutine(PararYReiniciarNivel2());
        }
    }


    private IEnumerator PararYReiniciar()
    {
        // Time.timeScale = 0;
        inmune = true;
        //vidasJugador.LoseLife();

        //sonidoMuerte.Play();
        playerAnimation.AnimacionMuerte();
        yield return new WaitForSecondsRealtime(tiempoEspera);
        inmune = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    private IEnumerator PararYReiniciarNivel2()
    {
        inmune = true;
        Datos.Instance.vidas--;
        vidasJugador.LoseLife();

        //sonidoMuerte.Play();
        playerAnimation.AnimacionMuerte();
        yield return new WaitForSecondsRealtime(tiempoEspera);
        inmune = false;
        if(Datos.Instance.vidas < 0)
        {
            PanelPerder.Instance.PerderVidas();
            yield break;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        
    }
}

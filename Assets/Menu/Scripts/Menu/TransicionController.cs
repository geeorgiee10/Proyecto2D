using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TransicionController : MonoBehaviour
{
    public static TransicionController Instance;

    [SerializeField] private Transform imagenTransicion;
    [SerializeField] private float duracion = 1f;
    [SerializeField] private float escalaMax = 20f;

    [SerializeField] private Transform canvas;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //StartCoroutine(Achicar());
    }
    

    public void CambiarEscena(string nombreEscena)
    {
        StartCoroutine(AgrandarYCambiar(nombreEscena));
    }

    private IEnumerator AgrandarYCambiar(string nombreEscena)
    {
        canvas.gameObject.SetActive(false);
        imagenTransicion.gameObject.SetActive(true);
        yield return StartCoroutine(Agrandar());
        SceneManager.LoadScene(nombreEscena);

    }

    private IEnumerator Agrandar()
    {

        float tiempoEspera = 0f;

        Vector3 inicio = Vector3.one;
        Vector3 fin = Vector3.one * escalaMax;

        while (tiempoEspera < duracion)
        {
            tiempoEspera += Time.deltaTime;
            float t = tiempoEspera / duracion;
            imagenTransicion.localScale = Vector3.Lerp(inicio, fin, t);
            yield return null;
        }
        imagenTransicion.localScale = fin;

    }

    
}

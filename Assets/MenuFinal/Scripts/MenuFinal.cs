using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFinal : MonoBehaviour
{
    public GameObject confetiPrefab;  
    public Vector3 areaSize = new Vector3(16, 0, 5);
    public float spawnInterval = 0.1f;
    public float confetiTiempoVida = 3f;

    public GameObject creditos;

    private float timer;

    void Start()
    {
        creditos.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnInterval)
        {
            SpawnConfeti();
            timer = 0f;
        }
    }

    void SpawnConfeti()
    {
        Vector3 randomPos = transform.position + new Vector3(
            Random.Range(-areaSize.x / 2, areaSize.x / 2),
            0,
            Random.Range(-areaSize.z / 2, areaSize.z / 2)
        );

        GameObject confeti = Instantiate(confetiPrefab, randomPos, Quaternion.identity);

        Destroy(confeti, confetiTiempoVida);
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

    public void SalirJuego()
    {
        Debug.Log("Salir Juego");
        Application.Quit();
    }

    public void Creditos()
    {
        creditos.SetActive(true);
    }

    public void CerrarCreditos()
    {
        creditos.SetActive(false);
    }
}

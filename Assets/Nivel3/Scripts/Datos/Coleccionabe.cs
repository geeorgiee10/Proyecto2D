using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Coleccionabe : MonoBehaviour
{

    public static Coleccionabe Instance;

    public int coleccionables = 0;

    public Transform MetaSpawn1;
    public Transform MetaSpawn2;
    public Transform MetaSpawn3;
    public Transform MetaSpawn4;

    public Transform Meta;

    public TextMeshProUGUI etiquetaColeccionables;
    public TextMeshProUGUI etiquetaMeta;

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
            //DontDestroyOnLoad(gameObject); 
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        etiquetaColeccionables.text = "0";
        etiquetaMeta.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActualizarColeccionable()
    {

        coleccionables++;

        etiquetaColeccionables.text = coleccionables.ToString();

        if(coleccionables >= 6)
        {
            etiquetaMeta.text = "LA META HA APARECIDO";
            MostrarMeta();
        }

    }

    public void MostrarMeta()
    {
        Transform[] spawnsMetaAleatorios = { MetaSpawn1, MetaSpawn2, MetaSpawn3, MetaSpawn4 };

        int elementoAleatorio = Random.Range(0, spawnsMetaAleatorios.Length);

        Transform puntoSeleccionado = spawnsMetaAleatorios[elementoAleatorio];

        if (Meta != null)
        {
            
            Instantiate(Meta, puntoSeleccionado.position, Quaternion.identity);
            Meta.gameObject.SetActive(true);
        }
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Datos : MonoBehaviour
{

    public int vidas = 3;

    public static Datos Instance;
    

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
            DontDestroyOnLoad(gameObject); 
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




}

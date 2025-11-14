using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidasJugador : MonoBehaviour
{

    public static VidasJugador Instance;

    [Header("Imagenes")]
        [SerializeField] private List<Image> hearts = new();

    [Header("Config")]
    [SerializeField] private int maxLives = 4;

    private int currentLives;


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

        maxLives = Mathf.Clamp(maxLives, 0, hearts.Count);
        if (Datos.Instance != null)
        {
            SetLives(Datos.Instance.vidas);
        }
    }

    public void Start()
    {
        if (Datos.Instance != null)
        {
            SetLives(Datos.Instance.vidas);
        }
    }

    public void SetLives(int lives)
    {
        currentLives = Mathf.Clamp(lives, 0, maxLives);
        for(int i = 0; i < hearts.Count; i++)
        {
            if (i >= maxLives)
            {
                hearts[i].gameObject.SetActive(false);
            }
            else
            {
                hearts[i].gameObject.SetActive(i < currentLives);
            }
            
        }
    }

    public void LoseLife(int amount = 1)
    {
        currentLives -= amount;
        SetLives(currentLives);
    }
    
}

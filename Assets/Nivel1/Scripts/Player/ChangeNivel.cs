using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeNivel : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private Rigidbody2D rb;

    private string escenaSiguiente;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Meta"))
        {

            StartCoroutine(Desaparecer());

        }
    }
    

    private IEnumerator Desaparecer()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        animator.SetTrigger("Meta");

        //DontDestroyOnLoad(gameObject);

        yield return new WaitForSecondsRealtime(0.5f);

        rb.constraints = RigidbodyConstraints2D.None;

        if (SpawnCheckpoint.Instance != null)
        {
            SpawnCheckpoint.Instance.QuitarCheckpoint();
        }


        string escenaActual = SceneManager.GetActiveScene().name;

        switch (escenaActual)
        {

            case "Nivel1":
                escenaSiguiente = "Nivel2";
                break;

            case "Nivel2":
                escenaSiguiente = "Nivel3";
                break;

            case "Nivel3":
                escenaSiguiente = "MenuFinal";
                break;

            default:
                Debug.LogWarning($"⚠️ Escena actual '{escenaActual}' no reconocida.");
                break;
        }

        if (!string.IsNullOrEmpty(escenaSiguiente))
        {   
            TransicionController.Instance.CambiarEscena(escenaSiguiente);
        }

        
    }
}

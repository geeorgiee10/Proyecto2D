using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoNivel2 : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private Rigidbody2D rb;
    private string escena = "Nivel2";


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

        DontDestroyOnLoad(gameObject);

        yield return new WaitForSecondsRealtime(0.5f);

        rb.constraints = RigidbodyConstraints2D.None;

        SpawnCheckpoint.Instance.QuitarCheckpoint();

        TransicionController.Instance.CambiarEscena(escena);
        
    }
}

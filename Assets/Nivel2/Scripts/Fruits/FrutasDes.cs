using UnityEngine;

public class FrutasDes : MonoBehaviour
{
    [SerializeField] private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<Collider2D>().enabled = false;

            transform.GetChild(0).gameObject.SetActive(false);

            transform.GetChild(1).gameObject.SetActive(true);

            animator.SetTrigger("Desbanana");

            
            StartCoroutine(FrutasDesactivar());

            Frutas.Instance.ActualizarColeccionable();

        }
    }

    private System.Collections.IEnumerator FrutasDesactivar()
    {
        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);
    }
}

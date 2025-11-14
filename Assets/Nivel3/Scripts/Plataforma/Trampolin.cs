using UnityEngine;

public class Trampolin : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private Rigidbody2D rbPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            animator.SetTrigger("Rebotar");

            Debug.Log("Collider" + other.collider);

            other.collider.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 15f, ForceMode2D.Impulse);


        }
    }
}

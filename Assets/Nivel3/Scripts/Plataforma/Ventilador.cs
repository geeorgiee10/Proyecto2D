using UnityEngine;

public class Ventilador : MonoBehaviour
{

    private Rigidbody2D rbPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            rbPlayer = other.GetComponent<Rigidbody2D>();
            rbPlayer.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            rbPlayer.AddForce(Vector2.up * 20f, ForceMode2D.Force);

        }
    }
}

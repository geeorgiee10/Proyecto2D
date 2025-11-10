using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public SpawnJugador spawnJugador;
    private bool activado = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!activado && other.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Checkpoint");

            activado = true;

            SpawnCheckpoint.Instance.GuardarCheckpoint();

        }
    }
}

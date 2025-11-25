using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public SpawnJugador spawnJugador;
    private bool activado = false;
    [Header("Sonidos")]
        [SerializeField] private AudioSource sonidoCheckpoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!activado && other.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Checkpoint");
            if(!sonidoCheckpoint.isPlaying)    
                sonidoCheckpoint.Play();

            activado = true;

            SpawnCheckpoint.Instance.GuardarCheckpoint();

        }
    }
}

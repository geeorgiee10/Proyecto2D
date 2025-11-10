using UnityEngine;

public class SpawnCheckpoint : MonoBehaviour
{

    public static SpawnCheckpoint Instance;
    public bool checkpointPillado = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void GuardarCheckpoint()
    {
        checkpointPillado = true;
    }

    public void QuitarCheckpoint()
    {
        checkpointPillado = false;
    }
}

using UnityEngine;

public class BolaPinchosSpawner : MonoBehaviour
{
    public GameObject spikeBallPrefab;  
    public Vector3 areaSize = new Vector3(-125, 0, 5);
    public float spawnInterval = 1.5f;

    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnInterval)
        {
            SpawnBall();
            timer = 0f;
        }
    }

    void SpawnBall()
    {
        Vector3 randomPos = transform.position + new Vector3(
            Random.Range(-areaSize.x / 2, areaSize.x / 2),
            0,
            Random.Range(-areaSize.z / 2, areaSize.z / 2)
        );

        Instantiate(spikeBallPrefab, randomPos, Quaternion.identity);
    }
}

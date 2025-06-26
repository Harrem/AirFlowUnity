using UnityEngine;

public class CloudeSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float spawnInterval = 2f;
    public float minScale = 1f;
    public float maxScale = 4f;
    public float cloudSpeed = 0.5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnCloud();
            timer = 0;
        }
    }

    void SpawnCloud()
    {
        Vector2 topOfScreen = Camera.main.ViewportToWorldPoint(new Vector2(Random.Range(0f, 1f), 1.1f));
        GameObject cloud = Instantiate(cloudPrefab, topOfScreen, Quaternion.identity);

        float randomScale = Random.Range(minScale, maxScale);
        cloud.transform.localScale = Vector3.one * randomScale;

        cloud.AddComponent<CloudMover>().speed = cloudSpeed;
    }
}

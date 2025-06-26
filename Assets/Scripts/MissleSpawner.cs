using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public GameObject missilePrefab;
    public float spawnRate = 2f;
    public float spawnRateDecreaseFactor = 0.1f; // How much spawnRate decreases per second
    public float spawnDistance = 6f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        spawnRate = Mathf.Max(0.5f, spawnRate - (spawnRateDecreaseFactor * Time.deltaTime)); // Decrease spawnRate over time, with a minimum
        if (timer >= spawnRate && Time.timeScale != 0f)
        {
            SpawnMissile();
            timer = 0;
        }
    }

    void SpawnMissile()
    {
        Vector2 spawnDir = Random.insideUnitCircle.normalized;
        Vector2 spawnPos = (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position + spawnDir * spawnDistance;

        Instantiate(missilePrefab, spawnPos, Quaternion.identity);
    }
}

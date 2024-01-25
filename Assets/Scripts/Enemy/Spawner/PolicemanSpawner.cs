using UnityEngine;
using UnityEngine.Serialization;

public class PolicemanSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private float enemyNumberToIncrease = 1f;
    [SerializeField] private float spawnRateIncrease = 0.1f;
    
    [SerializeField] private int initialSpawnCount = 1;
    [SerializeField] private int maxSpawnCount = 10;

    private float timer = 0f;

    private void Start()
    {
        SpawnEnemies(initialSpawnCount);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        IncreaseTimeAndEnemy();
    }

    private void IncreaseTimeAndEnemy()
    {
        if (timer >= spawnInterval)
        {
            enemyNumberToIncrease += spawnRateIncrease;

            int numberOfEnemiesToSpawn = initialSpawnCount + Mathf.FloorToInt(enemyNumberToIncrease);
            
            SpawnEnemies(numberOfEnemiesToSpawn);

            timer = 0f;
        }
    }

    private void SpawnEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(-10f, 10f), Random.Range(-5f, 5f));

            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
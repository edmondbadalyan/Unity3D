using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawn;
    private float spawnRange = 8.0f;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject PowerUpPLZ;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(3);
        Instantiate(PowerUpPLZ, GenerateSpawnPosition(), PowerUpPLZ.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            Instantiate(PowerUpPLZ, GenerateSpawnPosition(), PowerUpPLZ.transform.rotation);
            SpawnEnemyWave(waveNumber);
        }
    }


    void SpawnEnemyWave(int spawEnemy)
    {
        
        for (int i = 0; i < spawEnemy; i++)
        {
            Instantiate(spawn, GenerateSpawnPosition(), spawn.transform.rotation);
        }

    }
    private Vector3 GenerateSpawnPosition() 
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0.2f, spawnPosZ);

        return randomPos;
    }
}

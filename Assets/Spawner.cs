using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public int currWave;
    public int waveValue;
    public int waveValueMultiplier = 10;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    public int spawnIndex;

    public Transform[] spawnLocation;
    public int waveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;

    private void Start()
    {
        GenerateWave();
    }
    public void GenerateWave()
    {

        waveValue = currWave * waveValueMultiplier;
        GenerateEnemies();

        spawnInterval = waveDuration / enemiesToSpawn.Count;
        waveTimer = waveDuration;
    }
    private void FixedUpdate()
    {
        if (spawnTimer <= 0)
        {
            if (enemiesToSpawn.Count > 0)
            {
                Instantiate(enemiesToSpawn[0], spawnLocation[spawnIndex].position, Quaternion.identity);
                enemiesToSpawn.RemoveAt(0);
                spawnTimer = spawnInterval;

                if (spawnIndex + 1 <= spawnLocation.Length - 1)
                {
                    spawnIndex++;
                }
                else
                {
                    spawnIndex = 0;
                }
            }
            else
            {
                waveTimer = 0;
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }
    }
    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0)
        {
            
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if (waveValue - randEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue  -= randEnemyCost;
            }
            else if (waveValue <= 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }
}

[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;
}

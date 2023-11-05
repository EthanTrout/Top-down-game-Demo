using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningSpawner : MonoBehaviour
{
    public GameObject weaponPrefab;
    private float spawnTimer;
    public DetectionZone detectzone;
    public float spawnInterval = 30f;
    public int amountOfEnemyHits = 3;
    int index;

    private void FixedUpdate()
    {
        if (spawnTimer <= 0)
        {
            index = 0;
            while(index <= amountOfEnemyHits && detectzone.detectedObjs.Count>0)
            {
                Instantiate(weaponPrefab, detectzone.detectedObjs[index].gameObject.transform.position, Quaternion.identity);
                spawnTimer = spawnInterval;
                index++;
            }
            
        }

        spawnTimer -= Time.fixedDeltaTime;
    }
    public void UpgradeEnemyHits()
    {
        amountOfEnemyHits++;
    }
    public void DecreaseSpawnInterval()
    {
        spawnInterval =spawnInterval * 0.95f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public static BossController instance;
    public List<GameObject> BossesToSpawn = new List<GameObject>();
    public Transform SpawnPoint;
    public Score score;
    GameObject boss;
    bool isBossSpawned = false;

    public GameObject ChestScreen;
    public bool isChestOpen = false;


    private void Awake()
    {
        instance = this;
    }
    private void FixedUpdate()
    {
        if (isChestOpen)
        {
            ChestScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void SpawnBoss()
    {
        boss = Instantiate(BossesToSpawn[0], SpawnPoint.position, Quaternion.identity);
        isBossSpawned = true;
    }
}

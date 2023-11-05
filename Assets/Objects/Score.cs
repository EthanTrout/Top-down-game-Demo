using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;
    public Spawner spawner;
    public BossController bossController;
    public float currentScore = 0;
    public float scoreToUnlockBoss = 20;
    public TMP_Text scoreText;
    public TMP_Text textTimer;
    public float waveCountDown = 30;

    private float timer;
    private bool isTimerPaused = false;

    public GameObject upgrades;
    public Upgrades upgradesScript;

    public GameObject hammerUpgrades;
    public GameObject lightningUpgrades;
    
    public float upgradeCost = 10;
    public float upgradeIncrement = 2;


    private bool isBossSpawned = false;
    private void Awake()
    {

        instance = this;
    }
    void Start()
    {
        scoreText.text = "SlimeBalls: "+ currentScore.ToString();
        textTimer.text = "WaveCountDown:";
        timer = waveCountDown;
        isBossSpawned = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isTimerPaused)
        {
            timer -= Time.fixedDeltaTime;
        }
        
        if(timer<= 0)
        {
            timer = waveCountDown;
            spawner.currWave++;
            spawner.GenerateWave();
        }
        else
        {
            textTimer.text = "WaveCountDown: " + Mathf.Floor(timer).ToString()+" Wave"+ spawner.currWave.ToString();
        }

        if(currentScore >= upgradeCost )
        {
            upgradeCost = upgradeCost * upgradeIncrement;
            if(!upgradesScript.hammerTree && !upgradesScript.lightningTree)
            {
                OpenUpgradeMenu();
            }
            else if (upgradesScript.hammerTree || upgradesScript.lightningTree)
            {
                OpenSkillTree();
            }
            
        }
        if(currentScore > scoreToUnlockBoss && !isBossSpawned)
        {
            
            bossController.SpawnBoss();
            isBossSpawned = true;

        }
    }
    public void UpdateScore(float scoreIncrement)
    {
        currentScore += scoreIncrement;
        scoreText.text = "SlimeBalls: " + currentScore.ToString();
    }

    public void OpenUpgradeMenu()
    {
        upgrades.SetActive(true);
        Time.timeScale = 0f;
        
    }
    public void CloseUpgradeMenu()
    {
        upgrades.SetActive(false);
        Time.timeScale = 1f;


    }
    public void OpenSkillTree()
    {
        if (upgradesScript.hammerTree)
        {
            hammerUpgrades.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (upgradesScript.lightningTree)
        {
            lightningUpgrades.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void CloseskillTree()
    {
        if (upgradesScript.hammerTree)
        {
            hammerUpgrades.SetActive(false);
            Time.timeScale = 1f;
        }
        else if (upgradesScript.lightningTree)
        {
            lightningUpgrades.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void PauseTimer()
    {
        isTimerPaused = true;
    }
    public void StartTimer()
    {
        isTimerPaused = false;
    }
}

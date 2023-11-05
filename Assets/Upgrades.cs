using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public SwordAttack swordAttack;
    public DamageablePlayer damageablePlayer;
    public float knockbackMultiplier = 1.1f;
    public GameObject Hammerspawner;
    public GameObject lightningspawner;
    public Hammer hammerScript;
    public lightning lightningScript;


    public  bool hammerTree = false;
    public bool lightningTree = false;
    bool healthTree = false;
    public void UpgradeDamage()
    {
        swordAttack.damage++;
    }
    public void UpgradeHealth()
    {
        damageablePlayer.Health++;
    }
    public void UpgradeKnockback()
    {
        swordAttack.knockbackForce = swordAttack.knockbackForce * knockbackMultiplier;
    }

    public void HammerTime()
    {
        if(Hammerspawner.activeInHierarchy == false)
        {
            Hammerspawner.SetActive(true);
            hammerTree = true;
        }
        else
        {
            return;
        }
    }
    public void LightningTime()
    {
        if (lightningspawner.activeInHierarchy == false)
        {
            lightningspawner.SetActive(true);
            lightningTree = true;
        }
        else
        {
            return;
        }
    }
    
    
    
}

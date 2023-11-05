using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreen;
    public void ActivateDeathScreen()
    {
        deathScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    
        
            
        
   
   
}

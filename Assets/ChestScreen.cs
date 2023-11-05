using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScreen : MonoBehaviour
{

    public GameObject chestScreen;
    
    public PlayerController player;

    private void FixedUpdate()
    {
        
        
        
    }

   
    public void CloseChestScreen()
    {
        player.canDash = true;
        player.dashIcon.SetActive(true);
        chestScreen.SetActive(false);
        Time.timeScale = 1f;
        BossController.instance.isChestOpen = false;
    }
}

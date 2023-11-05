using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    Animator anim;
     

    PlayerController player;

    public bool isOpened = false;

    private void Start()
    {
        anim =GetComponent<Animator>();
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("OpenChest", true);
        }
        
    }
    public void OpenChestScreen()
    {
        BossController.instance.isChestOpen = true;
        

    }

}

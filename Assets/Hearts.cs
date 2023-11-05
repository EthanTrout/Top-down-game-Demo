using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    public float health;
    public int numOfHearts = 6;
    public int maxHearts = 10;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public DamageablePlayer player;

    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        health = player.Health;
        if (health > numOfHearts)
        {
            numOfHearts++;
        }
        
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts )
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false ;
            }
        }
    }
}

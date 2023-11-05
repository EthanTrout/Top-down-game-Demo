using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public string tagTarget = "Player";
    public Collider2D col;
    public List<Collider2D> detectedObjs = new List<Collider2D>();

    //adds any collider in range to the list//
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag== tagTarget)
        {
            detectedObjs.Add(collider);
        }
        
    }
    //removes them from the list//
    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == tagTarget)
        {
            detectedObjs.Remove(collider);
        }
    }

}

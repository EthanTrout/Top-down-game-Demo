using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Item : MonoBehaviour
{
    
    public DetectionZone detectionZone;
    public float moveSpeed = 50f;
    public float pickupSize = 0.05f;
    public float scoreIncrement = 1;
    Rigidbody2D rb;
    

    

    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
         

}

    private void FixedUpdate()
    {
        // move toward player//
        if (detectionZone.detectedObjs.Count > 0)
        {
            Vector2 direction = (detectionZone.detectedObjs[0].gameObject.transform.position - transform.position).normalized;

            rb.AddForce(direction * moveSpeed * Time.deltaTime);


           
            

            // destroy item once close to player//
            if (Vector2.Distance(detectionZone.detectedObjs[0].gameObject.transform.position, transform.position)<= pickupSize)
            {
                //add score//
                    Destroy(gameObject);
                    Score.instance.UpdateScore(scoreIncrement);
                    
                
                
            }
           


            
        }
         

        
       
    }
}

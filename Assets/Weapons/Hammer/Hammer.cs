using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public DetectionZone detectionZone;
    Rigidbody2D rb;
    CapsuleCollider2D _collider;
    
    

    public float damage = 1;
    public float knockbackForce = 100f;
    public float moveSpeed = 300f;
    public float speedIncrement = 1.2f;
    public float _hammerBounce = 1;
    
    public float HammerBounce
    {
        get
        {
            return _hammerBounce;
        }
        set
        {
            _hammerBounce = value;
        }
    }
    
    public float hit =0;

   

    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();
        
       
        



    }
    private void FixedUpdate()
    {

        if (detectionZone.detectedObjs.Count > 0)
        {
            Vector2 direction = (detectionZone.detectedObjs[0].gameObject.transform.position - transform.position).normalized;
            //move toward obj//
            
            rb.AddForce(direction * moveSpeed * Time.deltaTime);
            
        }
        else
        {
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        IDamageable damageableObject = collision.collider.GetComponent<IDamageable>();

       


        if (damageableObject != null && collision.gameObject.CompareTag("Enemy"))
        {
            
            // calculate direction between player and slime//


            Vector2 direction = (Vector2)(collision.gameObject.transform.position - transform.position).normalized;

            Vector2 knockback = direction * knockbackForce;

            damageableObject.OnHit(damage, knockback);
            hit++;

            DestroyHammer();
        }


    }
    public void DestroyHammer()
    {
        
            if(hit == HammerBounce)
            {
                Destroy(gameObject);
            }
            
        
        
                
            
        
        
    }

    public void UpgradeHammerSpeed()
    {
        moveSpeed = moveSpeed * speedIncrement;
        HammerBounce++;


    }
    public void UpgradeHammerDamage()
    {
        damage++;
    }

    



}


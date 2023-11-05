using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    
    
    DamageablePlayer damageable;
    

    public float damage = 1;
    public float knockbackForce = 100f;
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageableObject = collision.collider.GetComponent<IDamageable>();

        if (damageableObject != null && collision.gameObject.CompareTag("Player"))
        {
            // calculate direction between player and slime//
            

            Vector2 direction = (Vector2)(collision.gameObject.transform.position - transform.position).normalized;

            Vector2 knockback = direction * knockbackForce;

            damageableObject.OnHit(damage, knockback);
        }
        

    }





}

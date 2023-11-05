using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public DetectionZone detectionZone;
    Rigidbody2D rb;
    DamageablePlayer damageable;
    Animator animator;
    public float moveSpeed = 300f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        damageable = GetComponent<DamageablePlayer>();
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (damageable.Targetable && detectionZone.detectedObjs.Count > 0)
        {
            Vector2 direction = (detectionZone.detectedObjs[0].gameObject.transform.position - transform.position).normalized;
            //move toward obj//
            rb.AddForce(direction * moveSpeed * Time.deltaTime);
            animator.SetBool("is_Moving", true);
        }
        else
        {
            animator.SetBool("is_Moving", false);
        }
    }
}

    
    

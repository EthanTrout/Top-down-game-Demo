using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBoss : MonoBehaviour
{
    public DetectionZone detectionZone;
    Rigidbody2D rb;
    DamageablePlayer damageable;
    Animator animator;
    public float moveSpeed = 300f;

    float timer = 0;
    [SerializeField] float countdownTillAttack = 500f;
    public GameObject projectilePrefab;
    public Vector3[] transforms;
    public Vector2[] directions;
    GameObject[] proj;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        damageable = GetComponent<DamageablePlayer>();
        animator = GetComponent<Animator>();
        timer = countdownTillAttack;
    }
    void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;

        if(timer <= 0)
        {
            
            for (int i = 0; i<transforms.Length; i++)
            {
                print(i);
                proj[i]= Instantiate(projectilePrefab, transforms[i],Quaternion.identity);
                proj[i].GetComponent<ProjectileMovement>().direction = directions[i];
            }
            timer = countdownTillAttack;
        }
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

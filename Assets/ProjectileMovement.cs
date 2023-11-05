using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    // Start is called before the first frame update


   [SerializeField] float damage = 1;
   [SerializeField] float knockbackForce = 300f;
   [SerializeField] float moveSpeed = 1500;
    Rigidbody2D rb;
    public Vector2 direction;

    private void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        direction = new Vector2();
    }

    private void FixedUpdate()
    {
        
        
        rb.AddForce(direction * moveSpeed * Time.deltaTime);
    }

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

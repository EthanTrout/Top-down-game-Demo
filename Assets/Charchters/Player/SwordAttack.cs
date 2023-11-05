using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float damage = 1;
    public float knockbackForce = 500f;
    Vector2 rightAttackOffset;
    public Collider2D swordCollider;
    

    public Vector3 faceRight = new Vector3(0.01f, 0.019f, 0);
    public Vector3 faceLeft= new Vector3(-0.29f, 0.019f, 0);


    void Start()
    {

        rightAttackOffset = transform.position;
        if (swordCollider == null)
        {
            Debug.LogWarning("Sword collider is empty");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageableObject = collision.GetComponent<IDamageable>();

        if(damageableObject != null )
        {
            // calculate direction between player and slime//
            Vector3 parentPos = transform.parent.position;

            Vector2 direction = (Vector2)( collision.gameObject.transform.position - parentPos).normalized;

            Vector2 knockback = direction * knockbackForce;

            damageableObject.OnHit(damage, knockback);
        }
        
        
    }

    
    
    void IsFacingRight(bool isFacingRight)
    {
        if (isFacingRight)
        {
            gameObject.transform.localPosition = faceRight;
        }
        else
        {
            gameObject.transform.localPosition = faceLeft;
        }
    }
}

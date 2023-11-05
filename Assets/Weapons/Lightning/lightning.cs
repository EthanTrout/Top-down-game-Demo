using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightning : MonoBehaviour
{
    public int damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageableObject = collision.GetComponent<IDamageable>();

        if (damageableObject != null)
        {
            damageableObject.OnHit(damage);
        }
    }
    public void EndLightning()
    {
        Destroy(gameObject);
    }
    public void Damage()
    {
        damage++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject weaponPrefab;
    private float spawnTimer;
    public Transform playerPos;
    public float spawnInterval = 30f;
    private void Start()
    {
        Hammer hammerScript = weaponPrefab.GetComponent<Hammer>();
        hammerScript.HammerBounce = 1;
        hammerScript.moveSpeed = 800f;
        hammerScript.damage = 1;
    }
    private void FixedUpdate()
    {
        if (spawnTimer <= 0)
        {
            var hammer =Instantiate(weaponPrefab, playerPos.position, Quaternion.identity);
            
            Physics2D.IgnoreCollision(hammer.GetComponent<Collider2D>(), GetComponentInParent<BoxCollider2D>());
            
            spawnTimer = spawnInterval;
        }

        spawnTimer -= Time.fixedDeltaTime;
    }
}

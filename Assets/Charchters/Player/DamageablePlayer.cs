using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageablePlayer : MonoBehaviour, IDamageable
{

    Rigidbody2D rb;

    Animator animator;

    Collider2D physicsCollider;

    public bool is_Alive = true;

    float invinsibleTimeElapsed = 0f;

    public bool disableSimulation = false;

    public bool canTurnInvinsible = false;

    public bool deathAniFinished = false;

    public float _health = 3;

    public float _damageDelt;

    public bool _targetable = true;

    public bool _invinsible = false;

    public float invinsibleTime = 0.25f;

    public GameObject healthText;

    public GameObject itemDrop;

    public GameObject hitParticle;

    

    

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("is_Alive", is_Alive);
        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
        
    }

    public float DamageDelt
    {
        set
        {
            _damageDelt = value;
        }
        get
        {
            return _damageDelt;
        }
    }
    public float Health
    {
        set
        {
           
            
            if (value < _health)
            {
                Instantiate(hitParticle, (gameObject.transform.position), Quaternion.identity);
                animator.SetTrigger("hit");
                //text hits//

                RectTransform textTransform = Instantiate(healthText).GetComponent<RectTransform>();
                textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                TMP_Text textValue =textTransform.GetComponent<TMP_Text>();
                textValue.text = DamageDelt.ToString();
                







                Canvas canvas = GameObject.FindObjectOfType<Canvas>();
                textTransform.SetParent(canvas.transform);

            }
            _health = value;

            if (_health <= 0)
            {
               
                Targetable = false;
                is_Alive = false;
                Deafeated();
                
                //item drops //
                Instantiate(itemDrop, (gameObject.transform.position), Quaternion.identity);
                

                
                
            }
            
        }
        get
        {
            return _health;
        }
    }

    public bool Targetable
    {
        get
        {
            return _targetable;
        }
        set
        {
            _targetable = value;
            if (disableSimulation)
            {
                rb.simulated = false;
            }

            physicsCollider.enabled = value;
        }
    }

    public bool Invisible
    {
        get
        {
            return _invinsible;
        }
        set
        {
            _invinsible = value;
            if(_invinsible == true)
            {
                invinsibleTimeElapsed = 0;
            }
        }
    }

    

   

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Invisible)
        {
            invinsibleTimeElapsed += Time.fixedDeltaTime;
            
            if (invinsibleTimeElapsed > invinsibleTime)
            {
                Invisible = false;
            }
        }
    }

    void Deafeated()
    {
        animator.SetBool("is_Alive", is_Alive);

    }
    public void OnObjectDestroyed()
    {
        Destroy(gameObject);
    }

    public void OnHit(float damage)
    {
        if (!Invisible)
        {
            Debug.Log("Player Hit for" + damage);
            
            DamageDelt = damage;
            Health -= damage;
            

            if (canTurnInvinsible)
            {
                Invisible = true;
            }
        }
        
    }

    public void OnHit(float damage, Vector2 Knockback)
    {
        if (!Invisible)
        {
            DamageDelt = damage;
            Health -= damage;
            
            
            // add knockback//

            rb.AddForce(Knockback);
            

            if (canTurnInvinsible)
            {
                Invisible = true;
            }
        }

        

    }
    



}


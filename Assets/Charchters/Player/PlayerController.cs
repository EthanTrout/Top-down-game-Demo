using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public bool IsMoving
    {
        set
        {
            isMoving = value;
            animator.SetBool("is_Moving", value);
        }
    }

    public float moveSpeed = 150f;
    public float maxSpeed = 8f;
    public float idleFriction = 0.9f;
    public ContactFilter2D movementFilter;
    public float collisionOffset = 1f;
    public SwordAttack swordAttack;
    public GameObject swordHitBox;




    private bool isMoving = false;

    bool isDashTriggered = false;
    public float dashSpeed = 100000f;
    public float dashCoolDown = 0.5f;
    public bool canDash = false;
    public GameObject dashIcon;

    public DamageablePlayer player;
    Collider2D swordColider;
    Vector2 movementInput =Vector2.zero;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    Animator animator;
    SpriteRenderer spriteRender;
    private bool canMove;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
        swordColider = swordHitBox.GetComponent<Collider2D>();
    }
    

    private void FixedUpdate()
    {
        if(canDash && isDashTriggered)
        {
            StartCoroutine(Dash());
        }
        if (canMove && movementInput != Vector2.zero)
        {

            //rb.velocity = Vector2.ClampMagnitude(rb.velocity + (movementInput * moveSpeed * Time.deltaTime), maxSpeed);//
            rb.AddForce(movementInput * moveSpeed * Time.deltaTime);
            if (rb.velocity.magnitude> maxSpeed)
            {
                

                float limitedSpeed = Mathf.Lerp(rb.velocity.magnitude, maxSpeed, idleFriction);
                rb.velocity = rb.velocity.normalized * limitedSpeed;
            }
            if (movementInput.x < 0)
            {


                spriteRender.flipX = true;
                gameObject.BroadcastMessage("IsFacingRight", false);
                
            }
            else if (movementInput.x > 0)
            {
                spriteRender.flipX = false;
                gameObject.BroadcastMessage("IsFacingRight", true);

            }
            IsMoving = true;
        }
        else
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);
            IsMoving = false;
        }
        
        
    }
    
    private IEnumerator Dash()
    {
        dashIcon.SetActive(false);
        player.Invisible = true;
        canDash = false;
        rb.AddForce(movementInput * dashSpeed * Time.deltaTime);
        
        isDashTriggered = false;
        
        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
        dashIcon.SetActive(true);
    }

    void OnMove(InputValue movementValue)
    {
         movementInput = movementValue.Get<Vector2>();
        
        
    }
    void OnFire()
    {
        if (!PauseMenu.isPaused)
        {
            animator.SetTrigger("Attack");
        }
    }
    
    void OnDash()
    {
        isDashTriggered = true;
    }
    public void StartMove()
    {
        canMove = true;
    }
    public void StopMove()
    {
        canMove = false;
    }
    
    
    

}


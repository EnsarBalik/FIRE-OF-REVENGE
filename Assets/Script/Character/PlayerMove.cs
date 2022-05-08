using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instancee;
    #region Public Class
    public Animator animator;
    public float speed;
    public float jumpForce;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask WhatIsGround;
    public int extraJumpsValue;
    public int Health;
    public GameObject deathEffect;
    public GameObject BleedingEffect;
    public AudioSource HitSound;
    #endregion

    #region Private Class
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;
    private float moveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool isGrounded;
    private int extraJumps;
    private bool IsDead;
    #endregion

    [Header("Dash")]
    public bool canDash = true;
    public float dashingTime;
    public float dashSpeed;
    public float dashJumpIncrease;
    public float timeBtwDashes;

    [Header("JumpAttack")]
    public bool canJumpAtk = true;
    public float timebBtwJatk;

    void Start()
    {
        instancee = this;
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatIsGround);
        if (IsDead == false)
        {
            if (CutScene.instance.isCinematic == false)
            {
                moveInput = Input.GetAxis("Horizontal");
                rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
                animator.SetFloat("Run", Mathf.Abs(moveInput));
                if (facingRight == false && moveInput > 0)
                {
                    Flip();
                }
                else if (facingRight == true && moveInput < 0)
                {
                    Flip();
                }
            }
        }
    }
    void Update()
    {
        if (IsDead == false)
        {
            if (CutScene.instance.isCinematic == false)
            {
                if (isGrounded == true)
                {
                    coyoteTimeCounter = coyoteTime;
                    extraJumps = extraJumpsValue;
                }
                else
                {
                    coyoteTimeCounter -= Time.deltaTime;
                }

                if (Input.GetKeyDown(KeyCode.W))
                {
                    jumpBufferCounter = jumpBufferTime;
                }
                else
                {
                    jumpBufferCounter -= Time.deltaTime;
                }

                if (jumpBufferCounter > 0f && extraJumps > 0 && coyoteTimeCounter > 0f)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    extraJumps--;
                    jumpBufferCounter = 0f;
                }
                else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded == true)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    coyoteTimeCounter = 0f;
                    animator.SetBool("Jump", true);
                }
                if (isGrounded == false)
                {
                    animator.SetBool("Jump", false);
                }
            }
        }
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 6)
        {
            CameraShake.instance.StarterShake(.1f, .1f);
            //Bleeding Effect Here.
            Instantiate(BleedingEffect, transform.position, Quaternion.identity);
            HitSound.Play();
        }
        if (Health <= 0)
        {
            Die();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Health")
        {
            GameManager.instance.HealthHak++;
            Destroy(collision.gameObject);
        }
        if (Health < 10)
        {
            if (collision.gameObject.tag == "Canver")
            {
                Health += 5;
                Destroy(collision.gameObject, 0.1f);
                //collision.GetComponent<MoreHp>().enabled = true;
            }
        }
        else if(Health >= 10)
        {
            Health = 10;
        }
    }
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        animator.SetBool("Death", true);
        IsDead = true;
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void JumpAttack()
    {
        if (isGrounded)
        {
            animator.SetTrigger("JumpAttack");
        }
    }
    public void DashSkill()
    {
        if (canDash)
        {
            StartCoroutine(Dash());
        }
    }
    IEnumerator Dash()
    {
        canDash = false;
        speed = dashSpeed;
        jumpForce = dashJumpIncrease;
        yield return new WaitForSeconds(dashingTime);
        speed = 3;
        jumpForce = 4;
        yield return new WaitForSeconds(timeBtwDashes);
        canDash = true;
    }
}

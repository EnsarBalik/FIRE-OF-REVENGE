using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitEnemy : MonoBehaviour
{
    public static ShitEnemy instatee;
    Rigidbody2D rb;
    #region Public Variables
    public int damage = 1;
    public float speed = 2.5f;
    public float attackRange = 3f;
    public float Health;
    public GameObject deathEffect;
    public GameObject BleedingEffect;
    public bool isFlipped = false;
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance;//Minimum distance for attack
    public float timer;//timer fot cooldown between attacks
    public Animator animator;
    public Transform leftLimit;
    public Transform rightLimit;
    #endregion

    #region Private Variables
    private Transform player;
    private RaycastHit2D hit;
    private Transform target;
    private float distance;//store the distance b/w enemy and player
    private bool attackMode;
    private bool inRange;//check if player is in range
    private bool cooling;//check if enemy is cooling after attack
    private float intTimer;
    #endregion

    void Start()
    {
        instatee = this;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Awake()
    {
        SelectedTarget();
        intTimer = timer; //store the initial value of timer
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!attackMode)
        {
            Move();
        }

        if (!InsideofLimits() && !inRange && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
            SelectedTarget();
        }

        if (inRange)
        {
            AttackRange();
            hit = Physics2D.Raycast(rayCast.position, transform.right, rayCastLength, raycastMask);
            RaycastDebugger();
        }
        if (hit.collider != null)
        {
            enemyLogic();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }
        if (inRange == false)
        {
            StopAttack();
        }
    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        PlayerMove player = trig.GetComponent<PlayerMove>();
        if (trig.gameObject.tag == "Player")
        {
            target = trig.transform;
            inRange = true;
            Flip();
        }
    }

    void enemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if (distance > attackDistance)
        {
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }
        if (cooling)
        {
            cooldown();
            animator.SetBool("Attack1", false);
        }
    }
    public void Move()
    {
        animator.SetBool("canWalk", true);
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
    public void AttackRange()
    {
        animator.SetBool("canWalk", true);
        if (Vector2.Distance(player.position, rb.position) >= attackRange)
        {
            Move();
        }
        else if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            //attack anim

        }
    }

    void Attack()
    {
        timer = intTimer;
        attackMode = true;
        Debug.Log("Attacking");
        animator.SetBool("canWalk", false);
        animator.SetBool("Attack1", true);
        //Anim here
    }

    void cooldown()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && cooling && attackMode)
        {
            animator.SetBool("canWalk", false);
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        //Anim Here
        animator.SetBool("Attack1", false);
    }

    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.green);
        }
    }
    public void TriggerCoolibg()
    {
        cooling = true;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 10)
        {
            //Shake.CamShake();
            CameraShake.instance.StarterShake(.11f, .11f);
            //Bleeding Effect Here.
            Instantiate(BleedingEffect, transform.position, Quaternion.identity);
        }

        if (Health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        animator.SetBool("Dead", true);
        Destroy(gameObject);
    }
    private bool InsideofLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    private void SelectedTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

        if (distanceToLeft > distanceToRight)
        {
            target = leftLimit;
        }
        else
        {
            target = rightLimit;
        }
        Flip();
    }

    private void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }
        transform.eulerAngles = rotation;
    }
}

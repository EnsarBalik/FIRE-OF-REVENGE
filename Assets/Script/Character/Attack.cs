using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator animator;
    public AudioSource Sword;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("AttackPer0");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            HumanClose.instate.TakeDamage(1);
            CameraShake.instance.StarterShake(.11f, .11f);
            Sword.Play();
        }
        if (collision.gameObject.tag == "EnemySkelet2")
        {
            SkeletEnemy2.instatee.TakeDamage(1);
            CameraShake.instance.StarterShake(.11f, .11f);
            Sword.Play();
        }
        if (collision.gameObject.tag == "Shitenemy")
        {
            ShitEnemy.instatee.TakeDamage(1);
            CameraShake.instance.StarterShake(.11f, .11f);
            Sword.Play();
        }
        if(collision.gameObject.tag == "BOSS")
        {
            BOSS.instatee.TakeDamage(1);
            CameraShake.instance.StarterShake(.07f, .07f);
            Sword.Play();
        }
    }
}

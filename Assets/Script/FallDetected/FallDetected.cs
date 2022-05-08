using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetected : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HumanClose.instate.TakeDamage(10);
        }
        if (collision.gameObject.tag == "EnemySkelet2")
        {
            SkeletEnemy2.instatee.TakeDamage(10);
        }
        if (collision.gameObject.tag == "Player")
        {
            HumanClose.instate.TakeDamage(10);
        }
    }
}

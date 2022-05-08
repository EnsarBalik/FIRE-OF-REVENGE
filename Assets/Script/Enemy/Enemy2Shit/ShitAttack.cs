using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerMove.instancee.TakeDamage(1);
        }
    }
}

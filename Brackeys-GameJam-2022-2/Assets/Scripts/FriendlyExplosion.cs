using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyExplosion : MonoBehaviour
{
    [HideInInspector]
    public float Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy")) 
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(Damage);
        }
    }
}

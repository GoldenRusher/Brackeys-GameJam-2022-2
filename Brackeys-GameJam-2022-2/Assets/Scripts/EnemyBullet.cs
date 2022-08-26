using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float Damage;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player")) 
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(Damage);
            Destroy(this.gameObject);
        }
        if(collision.transform.gameObject.layer == LayerMask.NameToLayer("Walls")) 
        {
            Destroy(this.gameObject);
        }
    }
}

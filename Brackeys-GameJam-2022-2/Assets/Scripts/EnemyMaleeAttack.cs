using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaleeAttack : MonoBehaviour
{
    [Header("Distance")]
    public float DistanceToAttack;
    float DistanceToPlayer;
    
    [Header("Damage")]
    public float Damage;
    GameObject Player;
    PlayerHealth health;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        health = Player.GetComponent<PlayerHealth>();
    }

    void FixedUpdate()
    {
        DistanceToPlayer = Vector2.Distance(transform.position, Player.transform.position);

        if(DistanceToPlayer <= DistanceToAttack) 
        {
            health.TakeDamage(Damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, DistanceToAttack);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplode : MonoBehaviour
{

    [Header("Distance")]
    public float DistanceToExplode;
    float DistanceToPlayer;

    [Header("Damage")]
    GameObject Player;

    public GameObject Explosion;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        DistanceToPlayer = Vector2.Distance(transform.position, Player.transform.position);

        if (DistanceToPlayer <= DistanceToExplode)
        {
            Explode();
        }
    }

    public void Explode() 
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}

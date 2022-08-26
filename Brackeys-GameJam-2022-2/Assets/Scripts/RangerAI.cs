using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class RangerAI : MonoBehaviour
{
    public Transform Target;

    public float speed = 200f;
    public float nextWayPointDistance = 3;

    Path path;
    int CurrentWaypoint = 0;

    Seeker seeker;
    Rigidbody2D rb;


    

    [Header("stats")]
    public bool Tier2;
    public bool Tier3;
    public Transform[] FirePoint;
    public float TimeBetweenShots;
    float timer;

    public float DistanceToAttack;
    float distanceToPlayer;

    [Header("Bullet")]
    public GameObject Bullet;
    public float BulletSpeed;

    void Start()
    {
        timer = TimeBetweenShots;

        Target = GameObject.FindGameObjectWithTag("Player").transform;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0, 0.1f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, Target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            CurrentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        distanceToPlayer = Vector2.Distance(Target.position, transform.position);

        if (path == null)
        {
            return;
        }
        if (CurrentWaypoint >= path.vectorPath.Count)
        {
            return;
        }

        if(distanceToPlayer <= DistanceToAttack) 
        {
            if(timer <= 0) 
            {
                Attack();
            }
        }
        else 
        {
            Vector2 Dir = ((Vector2)path.vectorPath[CurrentWaypoint] - rb.position).normalized;
            Vector2 Force = Dir * speed;


            rb.AddForce(Force);
        }

        float distance = Vector2.Distance(rb.position, path.vectorPath[CurrentWaypoint]);

        if (distance < nextWayPointDistance)
        {
            CurrentWaypoint++;
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        Vector2 LookDir = rb.position - (Vector2)Target.position;

        float angle = Mathf.Atan2(LookDir.y, LookDir.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
    }


    void Attack() 
    {
        if(!Tier2 && !Tier3) 
        {
            GameObject a = Instantiate(Bullet, FirePoint[0].position, Quaternion.identity);
            Rigidbody2D rb = a.GetComponent<Rigidbody2D>();
            rb.AddForce(BulletSpeed * -(new Vector2(FirePoint[0].up.x, FirePoint[0].up.y)), ForceMode2D.Impulse);

            timer = TimeBetweenShots;
        }
        if(Tier2 && !Tier3) 
        {
            for (int i = 0; i < FirePoint.Length; i++)
            {
                GameObject a = Instantiate(Bullet, FirePoint[i].position, Quaternion.identity);
                Rigidbody2D rb = a.GetComponent<Rigidbody2D>();
                rb.AddForce(BulletSpeed * -(new Vector2(FirePoint[i].up.x, FirePoint[i].up.y)), ForceMode2D.Impulse);
            }

            timer = TimeBetweenShots;
        }
        if(Tier3 && !Tier2) 
        {
            for (int i = 0; i < FirePoint.Length; i++)
            {
                GameObject a = Instantiate(Bullet, FirePoint[i].position, Quaternion.identity);
                Rigidbody2D rb = a.GetComponent<Rigidbody2D>();
                rb.AddForce(BulletSpeed * -(new Vector2(FirePoint[i].up.x, FirePoint[i].up.y)), ForceMode2D.Impulse);
            }

            timer = TimeBetweenShots;
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, DistanceToAttack);
    }
}

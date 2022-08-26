using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyAI : MonoBehaviour
{
    public Transform Target;

    public float speed = 200f;
    public float nextWayPointDistance = 3;

    Path path;
    int CurrentWaypoint = 0;

    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        
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
        if(path == null) 
        {
            return;
        }
        if(CurrentWaypoint >= path.vectorPath.Count) 
        {
            return;
        }


        Vector2 Dir = ((Vector2)path.vectorPath[CurrentWaypoint] - rb.position).normalized;
        Vector2 Force = Dir * speed;


        rb.AddForce(Force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[CurrentWaypoint]);

        if(distance < nextWayPointDistance) 
        {
            CurrentWaypoint++;
        }
    }

    private void Update()
    {
        Vector2 LookDir = rb.position - (Vector2)Target.position;

        float angle = Mathf.Atan2(LookDir.y, LookDir.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
    }
}

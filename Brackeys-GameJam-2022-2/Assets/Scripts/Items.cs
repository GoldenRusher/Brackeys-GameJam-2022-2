using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    // 1 - Ammo, 2 - Scrap, 3 - Med
    public int Type;
    public int Amount;

    float t;
    bool Reached;


    GameObject Player;
    public float DistaneToPlayer;
    float distance;

    Rigidbody2D rb;
    Points pointsManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        pointsManager = GameObject.FindGameObjectWithTag("PointsManager").gameObject.GetComponent<Points>();
    }
    private void FixedUpdate()
    {
        distance = Vector2.Distance(Player.gameObject.transform.position, transform.position);

        if (distance <= DistaneToPlayer) 
        {
            Vector2 dir = transform.position - Player.transform.position;
            rb.AddForce(-dir * 5f, ForceMode2D.Force);
        }

        if(t < 1) 
        {
            if(Reached == false) 
            {
                t += Time.deltaTime * 3;
            }
        }
        else 
        {
            Reached = true;
        }
        if (Reached) 
        {
            t -= Time.deltaTime * 3;
            if(t <= 0) 
            {
                Reached = false;
            }
        }
        Pulse();
    }

    public void Pulse() 
    {
        transform.localScale = new Vector2(Mathf.Lerp(0.95f, 1.05f,t), Mathf.Lerp(0.95f, 1.05f, t));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player")) 
        {
            PlayerInventory inv = collision.GetComponent<PlayerInventory>();
            if(Type == 1) 
            {
                inv.AddAmmo(Amount);
            }else if(Type == 2) 
            {
                inv.AddScrap(Amount);
                pointsManager.AddScrap(Amount);
            }else if (Type == 3) 
            {
                inv.AddMed(Amount);
                pointsManager.AddMeds(Amount);
            }
            Destroy(this.gameObject);
        }
    }
}

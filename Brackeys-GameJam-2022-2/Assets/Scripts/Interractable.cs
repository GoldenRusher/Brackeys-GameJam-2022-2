using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interractable : MonoBehaviour
{
    [Header("Generator")]
    public bool isGenerator;
    public GameObject[] Lamps;
    public bool TurnedOn;

    public GameObject TurnOn;
    public float Distance;
    public GameObject Player;
    public GameObject gun;

    void Update()
    {
        if(Vector2.Distance(Player.transform.position,transform.position) <= Distance && !isGenerator) 
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                Player.GetComponent<PlayerMovement>().enabled = false;
                gun.SetActive(false);
                TurnOn.SetActive(true);
            }
        }
    }
}

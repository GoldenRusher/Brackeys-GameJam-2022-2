using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interractable : MonoBehaviour
{
    [Header("Generator")]
    public bool isGenerator;
    public GameObject[] Lamps;
    public bool TurnedOn;


    public bool IsWB;
    public GameObject TurnOn;
    public float Distance;
    public GameObject Player;
    public GameObject gun;
    public GameObject InterractShowCase;

    void Update()
    {
        if (IsWB) 
        {
            if (Vector2.Distance(Player.transform.position, transform.position) <= Distance && !isGenerator)
            {
                InterractShowCase.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    Player.GetComponent<PlayerMovement>().enabled = false;
                    gun.SetActive(false);
                    TurnOn.SetActive(true);
                }
            }
            else
            {
                InterractShowCase.SetActive(false);
            }
        }
    }
}

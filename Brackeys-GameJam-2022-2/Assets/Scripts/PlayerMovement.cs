using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Parameters")]
    public float Speed;
    float speed;

    [Header("Components")]
    public GameObject GFX;
    Rigidbody2D Rb;

    Vector2 MousePos;
    Vector2 LookDir;
    void Start()
    {
        speed = Speed;
        Rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        #region Rotation
        MousePos = Input.mousePosition;
        MousePos = Camera.main.ScreenToWorldPoint(MousePos);
        LookDir = Rb.position - MousePos;

        float angle = Mathf.Atan2(LookDir.y, LookDir.x) * Mathf.Rad2Deg -90f;

        Rb.rotation = angle;
        #endregion

        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            speed = Speed * 1.5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) 
        {
            speed = Speed;
        }

        //Movement
        Rb.velocity = MoveInput() * speed;
    }

    Vector2 MoveInput() 
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}

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

    public AudioSource WalkingSound;
    public AudioClip[] FootstepSounds;

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

        if (Input.GetKeyUp(KeyCode.LeftShift)) 
        {
            speed = Speed;
        }

        //Movement
        Rb.velocity = MoveInput() * speed;

        /*
        if(MoveInput() != Vector2.zero && !WalkingSound.isPlaying) 
        {
            int Rand = Random.Range(0, FootstepSounds.Length);
            WalkingSound.clip = FootstepSounds[Rand];

            WalkingSound.pitch = Random.Range(0.8f, 1.2f);
            WalkingSound.volume = Random.Range(0.05f, 0.15f);

            WalkingSound.Play();
        }
        */
    }

    Vector2 MoveInput() 
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}

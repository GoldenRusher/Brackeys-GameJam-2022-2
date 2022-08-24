using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Gun Setup")]
    public bool FullAuto = false;
    GameObject Player;
    public AudioSource AS;

    [Header("Gun Stats")]
    public float timeBetweenShots = 0.1f;
    float timer;
    public float RecoilAmount = 0.05f;

    [Header("Ammo")]
    public int AmmoCapacity;
    public int currentAmmo;
    public PlayerInventory PI;


    public Transform FirePoint;

    [Header("Prefab Shot")]
    public GameObject ShotEffect;
    public GameObject Bullet;
    public float BulletSpeed;
    public float BulletTime;

    RaycastHit2D hit;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        timer = timeBetweenShots;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(currentAmmo > 0) 
        {
            if (!FullAuto)
            {
                if (Input.GetButtonDown("Fire1") && timer <= 0)
                {
                    timer = timeBetweenShots;
                    PrefabShot();
                }
            }
            else
            {
                if (Input.GetButton("Fire1") && timer <= 0)
                {
                    timer = timeBetweenShots;
                    PrefabShot();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            if(PI.Ammo > 0) 
            {
                Reload();
            }
        }
    }
    public void Reload() 
    {
        int NeededAmmo = AmmoCapacity - currentAmmo;
        if(NeededAmmo > PI.Ammo) 
        {
            NeededAmmo = PI.Ammo;
            currentAmmo += NeededAmmo;
            PI.Ammo -= NeededAmmo;
        }
        else 
        {
            currentAmmo = AmmoCapacity;
            PI.Ammo -= NeededAmmo;
        }
    }

    public void PrefabShot()
    {
        currentAmmo--;
        float RandomRecoil = Random.Range(-RecoilAmount, RecoilAmount);
        AS.Play();
        CinemachineShake.Instance.ShakeCamera(3 * PlayerPrefs.GetFloat("ShakeIntensity"), 0.5f);

        GameObject a = Instantiate(Bullet,FirePoint.position,Quaternion.identity);
        Rigidbody2D rb = a.GetComponent<Rigidbody2D>();
        rb.AddForce(BulletSpeed * -(new Vector2(FirePoint.up.x + RandomRecoil, FirePoint.up.y + RandomRecoil)), ForceMode2D.Impulse);

        Instantiate(ShotEffect, FirePoint.position, Player.transform.localRotation);

        Vector2 MousePos = Input.mousePosition;
        MousePos = Camera.main.ScreenToWorldPoint(MousePos);
        Vector2 LookDir = rb.position - MousePos;

        float angle = Mathf.Atan2(LookDir.y, LookDir.x) * Mathf.Rad2Deg;

        rb.rotation = angle;
        
       
        a.GetComponent<Bullet>().dir = Player.transform.localRotation.eulerAngles;

        Destroy(a,BulletTime);
    }
}

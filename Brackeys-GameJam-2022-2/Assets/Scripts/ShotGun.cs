using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    [Header("Gun Setup")]
    public bool FullAuto = false;
    GameObject Player;


    [Header("Gun Stats")]
    public float timeBetweenShots = 0.1f;
    float timer;
    public float RecoilAmount = 0.05f;
    public float ShakeAmount;
    public int AmmoUsage;


    [Header("Ammo")]
    public int AmmoCapacity;
    public int currentAmmo;
    public PlayerInventory PI;

    public Transform[] FirePoint;

    [Header("Prefab Shot")]
    public GameObject ShotEffect;
    public GameObject Bullet;
    public float BulletSpeed;
    public float BulletTime;

    RaycastHit2D hit;

    public FMODUnity.EventReference GunShot;
    public FMODUnity.EventReference NoAmmo;
    public FMODUnity.EventReference ReloadSound;

    public int GunType;
    public FMOD.Studio.EventInstance Gunshot;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        timer = timeBetweenShots;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (currentAmmo > 0)
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
        if (currentAmmo <= 0 && Input.GetButtonDown("Fire1") && timer <= 0)
        {
            timer = timeBetweenShots;
            FMODUnity.RuntimeManager.PlayOneShotAttached(NoAmmo, gameObject);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (PI.Ammo > 0)
            {
                Reload();
                FMODUnity.RuntimeManager.PlayOneShotAttached(ReloadSound, gameObject);
            }
        }
    }
    public void Reload()
    {
        int NeededAmmo = AmmoCapacity - currentAmmo;
        if (NeededAmmo > PI.Ammo)
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
        Gunshot = FMODUnity.RuntimeManager.CreateInstance(GunShot);
        Gunshot.setParameterByName("GunType", GunType);
        Gunshot.start();

        if (currentAmmo - AmmoUsage >= 0)
        {
            currentAmmo -= AmmoUsage;
        }
        else
        {
            currentAmmo = 0;
        }

        for (int i = 0; i < FirePoint.Length; i++)
        {
            float RandomRecoil = Random.Range(-RecoilAmount, RecoilAmount);
            CinemachineShake.Instance.ShakeCamera(ShakeAmount * PlayerPrefs.GetFloat("ShakeIntensity"), 0.5f);

            GameObject a = Instantiate(Bullet, FirePoint[i].position, Quaternion.identity);
            Rigidbody2D rb = a.GetComponent<Rigidbody2D>();
            rb.AddForce(BulletSpeed * -(new Vector2(FirePoint[i].up.x + RandomRecoil, FirePoint[i].up.y + RandomRecoil)), ForceMode2D.Impulse);

            Instantiate(ShotEffect, FirePoint[i].position, Player.transform.localRotation);

            Vector2 MousePos = Input.mousePosition;
            MousePos = Camera.main.ScreenToWorldPoint(MousePos);
            Vector2 LookDir = rb.position - MousePos;

            float angle = Mathf.Atan2(LookDir.y, LookDir.x) * Mathf.Rad2Deg;

            rb.rotation = angle;


            a.GetComponent<Bullet>().dir = Player.transform.localRotation.eulerAngles;
            a.GetComponent<Bullet>().KnockBackDir = a.transform.position - transform.position;

            Destroy(a, BulletTime);
        }
    }
}

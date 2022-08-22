using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunSelector : MonoBehaviour
{
    PlayerSpriteController Psc;
    PlayerInventory PI;
    public GameObject CurrentGun;
    bool UsingGun = false;
    public Text AmmoText;
    public GameObject AmmoDisplay;
    public Text AmmoSupply;

    private void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        PI = Player.GetComponent<PlayerInventory>();
        Psc = Player.GetComponent<PlayerSpriteController>();
    }

    private void Update()
    {
        if (UsingGun == false && Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            UsingGun = true;
        }
        else if (UsingGun == true && Input.GetKeyDown(KeyCode.Alpha1))
        {
            UsingGun = false;
        }
    }

    void FixedUpdate()
    {
        if (UsingGun) 
        {
            AmmoDisplay.SetActive(true);
            AmmoSupply.text = PI.Ammo.ToString();
            AmmoText.text = CurrentGun.GetComponent<GunInfo>().UsingGun.GetComponent<Gun>().currentAmmo.ToString() + " / " + CurrentGun.GetComponent<GunInfo>().UsingGun.GetComponent<Gun>().AmmoCapacity.ToString();
            CurrentGun.SetActive(true);
            if (CurrentGun.GetComponent<GunInfo>().ShortGun) 
            {
                Psc.state = PlayerSpriteController.GunState.ShortWeapon;
            }
            else 
            {
                Psc.state = PlayerSpriteController.GunState.LongWeapon;
            }
        }
        else 
        {

            AmmoDisplay.SetActive(false);
            CurrentGun.SetActive(false);
            Psc.state = PlayerSpriteController.GunState.NoWeapon;
        }
    }

    public void ChangeCurrentGun(GameObject gun) 
    {
        CurrentGun.SetActive(false);
        CurrentGun = gun;
        CurrentGun.SetActive(true);
    }
}

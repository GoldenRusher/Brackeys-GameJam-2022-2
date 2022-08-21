using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelector : MonoBehaviour
{
    public PlayerSpriteController Psc;
    public GameObject CurrentGun;
    public bool UsingGun = false;

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
            CurrentGun.SetActive(false);
            Psc.state = PlayerSpriteController.GunState.NoWeapon;
        }
    }
}

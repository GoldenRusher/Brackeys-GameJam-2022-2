using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInfo : MonoBehaviour
{
    // if false it means its a long gun
    public bool ShortGun;
    public GameObject UsingGun;

    private void FixedUpdate()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).gameObject.activeSelf == true)
            {
                UsingGun = gameObject.transform.GetChild(i).gameObject;
            }
        }
    }
}

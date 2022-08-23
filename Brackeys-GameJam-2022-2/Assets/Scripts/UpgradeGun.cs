using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeGun : MonoBehaviour
{
    public GameObject[] GunUpgrades;
    public int CurrentUpgrade;

    void Update()
    {
        if (CurrentUpgrade - 2 >= 0)
        {
            GunUpgrades[CurrentUpgrade - 2].SetActive(false);
        }
        if (CurrentUpgrade - 1 >= 0) 
        {
            GunUpgrades[CurrentUpgrade - 1].SetActive(false);
        }
        GunUpgrades[CurrentUpgrade].SetActive(true);
    }

    public void Upgrade() 
    {
        if(CurrentUpgrade + 1 <= GunUpgrades.Length) 
        {
            CurrentUpgrade += 1;
        }
    }
}

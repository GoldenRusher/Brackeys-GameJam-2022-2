using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeShop : MonoBehaviour
{
    public UpgradeGun Up;
    public int Price;
    public Text PriceText;

    PlayerInventory PI;
    public void Start()
    {
        PriceText.text = Price.ToString() + " Scrap";

        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        PI = Player.GetComponent<PlayerInventory>();
    }

    public void Upgradegun() 
    {
        if(PI.Scrap >= Price) 
        {
            PI.Scrap -= Price;
            Up.Upgrade();
        }
    }
}

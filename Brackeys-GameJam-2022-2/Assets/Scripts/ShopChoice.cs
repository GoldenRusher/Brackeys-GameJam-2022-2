using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopChoice : MonoBehaviour
{
    public GameObject ShowedGun;
    public GunSelector GS;
    public int Price;
    PlayerInventory PI;
    public Text Pricetag;
    public GameObject Lock;
    public bool IsStarter;

    public void EquipGun() 
    {
        GS.ChangeCurrentGun(ShowedGun);
    }

    private void Start()
    {
        if (!IsStarter)
        {
            Pricetag.text = Price.ToString() + " Scrap";
        }
      

        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        PI = Player.GetComponent<PlayerInventory>();
    }

    public void BuyGun() 
    {
        if(PI.Scrap >= Price) 
        {
            PI.Scrap -= Price;
            Lock.SetActive(false);
        }
    }
}

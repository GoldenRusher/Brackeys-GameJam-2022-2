using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public int Ammo = 7;
    public int Scrap = 0;
    public int HealingSupplies = 1;

    public Text ScrapText;
    public Text MedText;
    public Text AmmoText;

    public void FixedUpdate()
    {
        ScrapText.text = Scrap.ToString();
        MedText.text = HealingSupplies.ToString();
        AmmoText.text = Ammo.ToString();
    }


    public void AddScrap(int amount) 
    {
        Scrap += amount;
    }
    public void AddMed(int amount)
    {
        HealingSupplies += amount;
    }
    public void AddAmmo(int amount)
    {
        Ammo += amount;
    }
}

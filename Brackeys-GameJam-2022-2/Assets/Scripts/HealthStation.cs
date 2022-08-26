using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthStation : MonoBehaviour
{
    GameObject Player;
    PlayerInventory inv;
    PlayerHealth health;

    public Text PriceTag;

    public int Price;
    public int PriceAddition;

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        inv = Player.GetComponent<PlayerInventory>();
        health = Player.GetComponent<PlayerHealth>();

        PriceTag.text = Price.ToString() + " Meds";
    }

    

    public void Heal() 
    {
        if (Price <= inv.HealingSupplies) 
        {
            health.Heal();
            inv.HealingSupplies -= Price;
        }
    }

    public void AddMaxHealth() 
    {
        if (Price <= inv.HealingSupplies)
        {
            health.AddMaxHealth();
            inv.HealingSupplies -= Price;
            Price += PriceAddition;
            PriceTag.text = Price.ToString() + " Meds";
        }
    }
}

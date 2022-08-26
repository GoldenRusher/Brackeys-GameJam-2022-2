using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth;
    public float currentHealth;

    public Slider HealthBar;


    public float ImmunityAfterHit;
    float timer;

    public Hurt h;

    public FMODUnity.EventReference Hit;

    public GameObject DeathMenu;

    void Start()
    {
        currentHealth = MaxHealth;
    }

    void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;

        HealthBar.minValue = 0;
        HealthBar.value = currentHealth;
        HealthBar.maxValue = MaxHealth;

        if(currentHealth < 0) 
        {
            DeathMenu.SetActive(true);
        }

        if(currentHealth > MaxHealth) 
        {
            currentHealth = MaxHealth;
        }
    }

    public void TakeDamage(float Damage) 
    {
        if(timer <= 0) 
        {
            FMODUnity.RuntimeManager.PlayOneShotAttached(Hit, gameObject);
            h.ChangeColor();
            currentHealth -= Damage;
            timer = ImmunityAfterHit;
        }
          
    }

    public void AddMaxHealth() 
    {
        MaxHealth += 20;
    }

    public void Heal() 
    {
        currentHealth += 50;
    }
}

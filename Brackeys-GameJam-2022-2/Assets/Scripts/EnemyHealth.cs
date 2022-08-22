using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float MaxHealth;
    public float currentHealth;
    public GameObject Bleeding;


    void Start()
    {
        currentHealth = MaxHealth;
    }

    void Update()
    {
        if(currentHealth <= MaxHealth*0.25f) 
        {
            Bleeding.SetActive(true);
        }
        if(currentHealth < 0) 
        {
            Bleeding.GetComponent<ParticleSystem>().Stop();
            Bleeding.transform.parent = null;
            Destroy(Bleeding, 10f);
            Die();
        }
    }

    void Die() 
    {
        Destroy(this.gameObject);
    }

    public void TakeDamage(float Damage) 
    {
        currentHealth -= Damage;
    }
}

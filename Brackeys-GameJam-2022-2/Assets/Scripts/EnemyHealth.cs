using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float MaxHealth;
    public float currentHealth;
    public GameObject Bleeding;

    public float DifficultyMultiplier = 1;

    DropItems DI;
    public bool IsExploder;
    public bool IsSplitter;

    Points PointsManager;

    void Start()
    {
        PointsManager = GameObject.FindGameObjectWithTag("PointsManager").gameObject.GetComponent<Points>();
        DI = GetComponent<DropItems>();
        currentHealth = MaxHealth * (DifficultyMultiplier * 0.75f);
        if (IsExploder) 
        {
            GetComponent<ExploderHealth>().DifficultyMultiplier = DifficultyMultiplier;
        }
        if (IsSplitter) 
        {
            GetComponent<SplitterHealth>().DifficultyMultiplier = DifficultyMultiplier;
        }
    }

    void Update()
    {
        if(currentHealth <= MaxHealth*0.25f && !IsExploder && !IsSplitter) 
        {
            Bleeding.SetActive(true);
        }
        if(currentHealth < 0 && !IsExploder && !IsSplitter) 
        {
            Bleeding.GetComponent<ParticleSystem>().Stop();
            Bleeding.transform.parent = null;
            Destroy(Bleeding, 10f);
            Die();
        }

        
    }

    void Die() 
    {
        PointsManager.AddKills(1);
        DI.Dropitems();
        Destroy(this.gameObject);
    }

    public void TakeDamage(float Damage) 
    {
        currentHealth -= Damage;
        if (IsExploder) 
        {
            GetComponent<ExploderHealth>().TakeDamage(Damage);
        }
        if (IsSplitter)
        {
            GetComponent<SplitterHealth>().TakeDamage(Damage);
        }
    }
}

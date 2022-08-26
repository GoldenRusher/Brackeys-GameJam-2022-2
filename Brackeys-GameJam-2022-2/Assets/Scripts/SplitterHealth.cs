using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitterHealth : MonoBehaviour
{
    public float MaxHealth;
    public float currentHealth;
    public GameObject Bleeding;

    public float DifficultyMultiplier = 1;

    DropItems DI;
    public int SplitAmount;
    public GameObject SplitZombie;

    Points PointsManager;

    void Start()
    {
        PointsManager = GameObject.FindGameObjectWithTag("PointsManager").gameObject.GetComponent<Points>();
        DI = GetComponent<DropItems>();
        currentHealth = MaxHealth * (DifficultyMultiplier * 0.75f);
    }
    //a
    void Update()
    {
        if (currentHealth <= MaxHealth * 0.25f)
        {
            Bleeding.SetActive(true);
        }
        if (currentHealth < 0)
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
        Split(SplitAmount);
        Destroy(this.gameObject);
    }

    public void TakeDamage(float Damage)
    {
        currentHealth -= Damage;
    }

    void Split(int b) 
    {
        for (int i = 0; i < b; i++)
        {
            float Rand = Random.Range(-0.2f, 0.2f);

            Instantiate(SplitZombie,(Vector2)transform.position + new Vector2(Rand,Rand),Quaternion.identity);
        }
    }
}

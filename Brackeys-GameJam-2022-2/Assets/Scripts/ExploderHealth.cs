using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploderHealth : MonoBehaviour
{
    public float MaxHealth;
    public float currentHealth;
    public GameObject Fire;
    public GameObject Explosion;

    public float DifficultyMultiplier = 1;

    DropItems DI;
    Points PointsManager;

    void Start()
    {
        PointsManager = GameObject.FindGameObjectWithTag("PointsManager").gameObject.GetComponent<Points>();
        DI = GetComponent<DropItems>();
        currentHealth = MaxHealth * (DifficultyMultiplier * 0.75f);
    }

    void Update()
    {
        if (currentHealth < 0)
        {
            Fire.GetComponent<ParticleSystem>().Stop();
            Fire.transform.parent = null;
            Destroy(Fire, 10f);
            Die();
        }
    }

    void Die()
    {
        DI.Dropitems();
        PointsManager.AddKills(1);
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    public void TakeDamage(float Damage)
    {
        currentHealth -= Damage;
    }
}

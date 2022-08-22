using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletDamage;
    public bool ReapThrough;

    public GameObject[] Impacts;
    public GameObject[] Blood;

    public Vector3 dir;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.gameObject.layer == LayerMask.NameToLayer("Walls")) 
        {
            GameObject a = Instantiate(Impacts[0], transform.position, Quaternion.Euler(dir));
            Destroy(a, 5f);
            if (!ReapThrough)
            {
                Destroy(this.gameObject);
            }
        }
        else if (collision.transform.CompareTag("Enemy"))
        {
            GameObject a = Instantiate(Impacts[1], transform.position, Quaternion.Euler(dir));
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(BulletDamage);

            int rand = Random.Range(1, 4);
            if(rand == 1) 
            {
                rand = Random.Range(1, 4);
                GameObject b = Instantiate(Blood[rand], transform.position, Quaternion.Euler(transform.localRotation.eulerAngles));
                Destroy(b, 200f);
            }



            if (!ReapThrough) 
            {
                Destroy(this.gameObject);
            }
            Destroy(a, 5f);
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.gameObject.layer == LayerMask.NameToLayer("Walls"))
        {
            GameObject a = Instantiate(Impacts[0], transform.position, Quaternion.Euler(dir));
            Destroy(a, 5f);
            if (!ReapThrough)
            {
                Destroy(this.gameObject);
            }
        }
        else if (collision.transform.CompareTag("Enemy"))
        {
            GameObject a = Instantiate(Impacts[1], transform.position, Quaternion.Euler(dir));
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(BulletDamage);

            int rand = Random.Range(1, 4);
            if (rand == 1)
            {
                rand = Random.Range(1, 4);
                GameObject b = Instantiate(Blood[rand], transform.position, Quaternion.Euler(transform.localRotation.eulerAngles));
                Destroy(b, 200f);
            }



            Destroy(a, 5f);
            if (!ReapThrough)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

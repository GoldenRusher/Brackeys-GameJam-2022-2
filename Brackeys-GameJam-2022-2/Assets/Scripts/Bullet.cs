using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Bullet : MonoBehaviour
{
    public float BulletDamage;
    public bool ReapThrough;
    public bool ExplodeOnImpact = false;

    public GameObject[] Impacts;
    public GameObject[] Blood;
    public GameObject BloodParticles;
    public GameObject Explosion;

    public Vector3 dir;

    public Vector2 KnockBackDir;
    public float KnockBackForce;

    public FMODUnity.EventReference ExplosionSound;
    public FMODUnity.EventReference ImpactSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.gameObject.layer == LayerMask.NameToLayer("Walls")) 
        {
            if (!ExplodeOnImpact) 
            {
                GameObject a = Instantiate(Impacts[0], transform.position, Quaternion.Euler(dir));
                FMODUnity.RuntimeManager.PlayOneShotAttached(ImpactSound, gameObject);
                Destroy(a, 5f);
            }
            else
            {
                GameObject a = Instantiate(Explosion, transform.position, Quaternion.identity);
                a.GetComponent<FriendlyExplosion>().Damage = BulletDamage;
                CinemachineShake.Instance.ShakeCamera(7 * PlayerPrefs.GetFloat("ShakeIntensity"), 0.5f);
                FMODUnity.RuntimeManager.PlayOneShotAttached(ExplosionSound, gameObject);

            }
            if (!ReapThrough)
            {
                Destroy(this.gameObject);
            }
        }
        if (collision.transform.CompareTag("Enemy"))
        {
            if (!ExplodeOnImpact)
            {
                FMODUnity.RuntimeManager.PlayOneShotAttached(ImpactSound, gameObject);
                GameObject a = Instantiate(Impacts[0], transform.position, Quaternion.Euler(dir));
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(BulletDamage);
                Destroy(a, 5f);
            }
            else
            {
                GameObject a = Instantiate(Explosion, transform.position, Quaternion.identity);
                a.GetComponent<FriendlyExplosion>().Damage = BulletDamage;
                CinemachineShake.Instance.ShakeCamera(7 * PlayerPrefs.GetFloat("ShakeIntensity"), 0.5f);
                FMODUnity.RuntimeManager.PlayOneShotAttached(ExplosionSound, gameObject);
            }
            



            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(KnockBackDir * KnockBackForce, ForceMode2D.Impulse);


            int rand = Random.Range(1, 4);
            if(rand == 1) 
            {
                rand = Random.Range(1, 4);
                GameObject b = Instantiate(Blood[rand], transform.position, Quaternion.Euler(transform.localRotation.eulerAngles));
                GameObject c = Instantiate(BloodParticles, transform.position, Quaternion.Euler(transform.localRotation.eulerAngles));
                Destroy(c, 50f);
                Destroy(b, 200f);
            }



            if (!ReapThrough) 
            {
                Destroy(this.gameObject);
            }            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.gameObject.layer == LayerMask.NameToLayer("Walls"))
        {
            if (!ExplodeOnImpact)
            {
                GameObject a = Instantiate(Impacts[0], transform.position, Quaternion.Euler(dir));
                Destroy(a, 5f);
                FMODUnity.RuntimeManager.PlayOneShotAttached(ImpactSound, gameObject);
            }
            else
            {
                GameObject a = Instantiate(Explosion, transform.position, Quaternion.identity);
                a.GetComponent<FriendlyExplosion>().Damage = BulletDamage;
                CinemachineShake.Instance.ShakeCamera(7 * PlayerPrefs.GetFloat("ShakeIntensity"), 0.5f);
                FMODUnity.RuntimeManager.PlayOneShotAttached(ExplosionSound, gameObject);
            }
            if (!ReapThrough)
            {
                Destroy(this.gameObject);
            }
        }
        if (collision.transform.CompareTag("Enemy"))
        {
            if (!ExplodeOnImpact)
            {
                GameObject a = Instantiate(Impacts[0], transform.position, Quaternion.Euler(dir));
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(BulletDamage);
                Destroy(a, 5f);
                FMODUnity.RuntimeManager.PlayOneShotAttached(ImpactSound, gameObject);
            }
            else
            {
                
                GameObject a = Instantiate(Explosion, transform.position, Quaternion.identity);
                a.GetComponent<FriendlyExplosion>().Damage = BulletDamage;
                CinemachineShake.Instance.ShakeCamera(7 * PlayerPrefs.GetFloat("ShakeIntensity"), 0.5f);
                FMODUnity.RuntimeManager.PlayOneShotAttached(ExplosionSound, gameObject);
            }
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(KnockBackDir * KnockBackForce, ForceMode2D.Impulse);

            int rand = Random.Range(1, 4);
            if (rand == 1)
            {
                rand = Random.Range(1, 4);
                GameObject b = Instantiate(Blood[rand], transform.position, Quaternion.Euler(transform.localRotation.eulerAngles));
                GameObject c = Instantiate(BloodParticles, transform.position, Quaternion.Euler(transform.localRotation.eulerAngles));
                Destroy(c, 150f);
                Destroy(b, 200f);
            }

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

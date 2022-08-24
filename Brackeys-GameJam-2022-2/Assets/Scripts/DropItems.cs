using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    public bool RandomDrops = true;

    [Header("Scrap")]
    public GameObject ScrapItemPrefab;
    public int ScrapAmout;
    public int MinScrap;
    public int MaxScrap;

    [Header("Ammo")]
    public GameObject AmmoItemPrefab;
    public int AmmoAmount;
    public int MinAmmo;
    public int MaxAmmo;

    [Header("Meds")]
    public GameObject MedItemPrefab;
    public int MedAmount;
    public int MinMeds;
    public int MaxMeds;


    public void Dropitems()
    {
        if (RandomDrops) 
        {
            ScrapAmout = Random.Range(MinScrap,MaxScrap);
            AmmoAmount = Random.Range(MinAmmo, MaxAmmo);
            MedAmount = Random.Range(MinMeds, MaxMeds);
        }

        if((ScrapAmout > 0)) 
        {
            Vector2 randompos = new Vector2(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f));

            GameObject a = Instantiate(ScrapItemPrefab, (Vector2)transform.position + randompos,Quaternion.identity);
            a.GetComponent<Items>().Amount = ScrapAmout;
        }
        if ((AmmoAmount > 0))
        {
            Vector2 randompos = new Vector2(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f));

            GameObject a = Instantiate(AmmoItemPrefab, (Vector2)transform.position + randompos, Quaternion.identity);
            a.GetComponent<Items>().Amount = AmmoAmount * WaveManager.DifficultyMultiplier;
        }
        if ((MedAmount > 0))
        {
            Vector2 randompos = new Vector2(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f));

            GameObject a = Instantiate(MedItemPrefab, (Vector2)transform.position + randompos, Quaternion.identity);
            a.GetComponent<Items>().Amount = MedAmount;
        }

    }
}

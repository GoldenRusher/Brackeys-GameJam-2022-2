using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using FMODUnity;
using UnityEngine.UI;
public class WaveManager : MonoBehaviour
{
    [Header("ChangeColor")]
    public Color nightColor;
    public Color DayColor;
    public Light2D GlobalLight;
    float duration = 1.5f;
    private float t = 0;

    //DayNight Cycle
    [Header("Day_Night")]
    public int[] WavesinANight;
    public float[] TimeOfDay;
    int currentWaveInNight;
    bool isDay;
    int Night;

    [Header("Spawning")]
    public List<Enemy> Tier0enemies = new List<Enemy>();
    public List<Enemy> Tier1enemies = new List<Enemy>();
    public List<Enemy> Tier2enemies = new List<Enemy>();
    public List<Enemy> Tier3enemies = new List<Enemy>();
    int currentWave;
    int waveValue;

    List<GameObject> enemiesToSpawn = new List<GameObject>();
    List<GameObject> CurrentEnemies = new List<GameObject>();

    public Transform[] spawnLocation;

    public float SpawnInterval;
    private float SpawnTimer;

    public static int DifficultyMultiplier = 1;

    public Text NightText;
    public Text WaveText;

    float NightT;
    float WaveT;

    public Color StartC;
    public Color EndC;

    [Header("Sound")]
    public FMODUnity.EventReference WaveStart;
    public FMODUnity.EventReference NightStart;
    public FMODUnity.EventReference GameStart;
    private void Start()
    {
        NightT = 1;
        WaveT = 1;

        currentWave = 1;
        SpawnTimer = SpawnInterval;
        Night = 0;
        StartCoroutine(Day());
    }

    public IEnumerator Day() 
    {
        t = 0;
        isDay = true;
        if(Night <= TimeOfDay.Length - 1) 
        {
            yield return new WaitForSeconds(TimeOfDay[Night]);
        }
        else 
        {
            currentWave = 1;
            SpawnTimer = SpawnInterval;
            Night = 0;
            DifficultyMultiplier++;
            yield return new WaitForSeconds(TimeOfDay[Night]);
        }
        
        StartNight();
    }

    public void StartNight() 
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(NightStart, gameObject);
        NightT = 0;
        t = 0;
        isDay = false;
        currentWaveInNight = WavesinANight[Night];
        GenerateWave();
    }

    void FixedUpdate()
    {
        WaveT += Time.fixedDeltaTime;
        NightT += Time.deltaTime;

        NightText.text = "Night " + Night.ToString();
        WaveText.text = "Wave " + currentWave.ToString();

        NightText.color = Color.Lerp(StartC, EndC, NightT);
        WaveText.color = Color.Lerp(StartC, EndC, WaveT);

        if (t < 1) 
        {
            t += Time.deltaTime / duration;
        }

        if (isDay) 
        {
            GlobalLight.color = Color.Lerp(nightColor, DayColor, t);
        }
        else 
        {
            GlobalLight.color = Color.Lerp(DayColor, nightColor, t);
        }

        for (var i = CurrentEnemies.Count - 1; i > -1; i--)
        {
            if (CurrentEnemies[i] == null)
                CurrentEnemies.RemoveAt(i);
        }

        if (SpawnTimer <= 0 && !isDay) 
        {
            if(enemiesToSpawn.Count > 0) 
            {
                int Rand = Random.Range(0, spawnLocation.Length);
                GameObject a = Instantiate(enemiesToSpawn[0], spawnLocation[Rand].position, Quaternion.identity);
                a.GetComponent<EnemyHealth>().DifficultyMultiplier = DifficultyMultiplier;
                CurrentEnemies.Add(a);
                enemiesToSpawn.RemoveAt(0);
                SpawnTimer = SpawnInterval;
            }
            else 
            {
                if(CurrentEnemies.Count <= 0) 
                {
                    currentWave++;
                    currentWaveInNight--;
                    if (currentWaveInNight > 0)
                    {
                        GenerateWave();
                    }
                    else
                    {
                        Night++;
                        StartCoroutine(Day());
                    }
                }
            }
        }
        else 
        {
            SpawnTimer -= Time.fixedDeltaTime;
        }
    }

    public void GenerateWave() 
    {
        WaveT = 0;
        FMODUnity.RuntimeManager.PlayOneShotAttached(WaveStart, gameObject);
        CurrentEnemies.Clear();
        if(DifficultyMultiplier > 1) 
        {
            waveValue = currentWave * 10 * DifficultyMultiplier / 2;
        }
        else 
        {
            waveValue = currentWave * 10;
        }
        
        GenerateEnemies();
    }
    public void GenerateEnemies() 
    {
        List<GameObject> generatedEnemies = new List<GameObject>();

        while(waveValue> 0) 
        {
            if (currentWave <= 2)
            {
                int RandomEnemyID = Random.Range(0, Tier0enemies.Count);
                int EnemyCost = Tier0enemies[RandomEnemyID].cost;

                if (waveValue - EnemyCost >= 0)
                {
                    generatedEnemies.Add(Tier0enemies[RandomEnemyID].EnemyPrefab);
                    waveValue -= EnemyCost;
                }
                else if (waveValue <= 0)
                {
                    break;
                }
            }
            if (currentWave > 2) 
            {
                int RandomEnemyID = Random.Range(0, Tier1enemies.Count);
                int EnemyCost = Tier1enemies[RandomEnemyID].cost;

                if (waveValue - EnemyCost >= 0)
                {
                    generatedEnemies.Add(Tier1enemies[RandomEnemyID].EnemyPrefab);
                    waveValue -= EnemyCost;
                }
                else if (waveValue <= 0)
                {
                    break;
                }
            }

            if (currentWave > 7)
            {
                int RandomEnemyID = Random.Range(0, Tier2enemies.Count);
                int EnemyCost = Tier2enemies[RandomEnemyID].cost;

                if (waveValue - EnemyCost >= 0)
                {
                    generatedEnemies.Add(Tier2enemies[RandomEnemyID].EnemyPrefab);
                    waveValue -= EnemyCost;
                }
                else if (waveValue <= 0)
                {
                    break;
                }
            }

            if (currentWave > 15)
            {
                int RandomEnemyID = Random.Range(0, Tier2enemies.Count);
                int EnemyCost = Tier2enemies[RandomEnemyID].cost;

                if (waveValue - EnemyCost >= 0)
                {
                    generatedEnemies.Add(Tier2enemies[RandomEnemyID].EnemyPrefab);
                    waveValue -= EnemyCost;
                }
                else if (waveValue <= 0)
                {
                    break;
                }
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;

    }
}

[System.Serializable]
public class Enemy 
{
    public GameObject EnemyPrefab;
    public int cost;
}

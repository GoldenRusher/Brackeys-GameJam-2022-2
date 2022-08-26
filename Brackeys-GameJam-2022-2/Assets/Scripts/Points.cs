using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public int points;
    public int Kills;
    public int Scrap;
    public int Meds;
    public int HighScore = 0;
    public int OldHighScore = 0;

    private void Start()
    {
        OldHighScore = PlayerPrefs.GetInt("Points");
        HighScore = PlayerPrefs.GetInt("Points");
    }

    public void Update()
    {
        points = ((Kills * 100) + (Scrap * 15) + (Meds * 50)) * WaveManager.DifficultyMultiplier;

        if(points > HighScore) 
        {
            HighScore = points;
            PlayerPrefs.SetInt("Points", points);
        }
    }

    public void AddScrap(int Amount) 
    {
        Scrap += Amount;
    }
    public void AddKills(int Amount)
    {
        Kills += Amount;
    }
    public void AddMeds(int Amount)
    {
        Meds += Amount;
    }
}

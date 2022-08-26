using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    public Color StartC;
    public Color EndC;
    public Color TextC;

    public float t;
    public float othert;
    public float othert2;
    public float othert3;
    public float othert4;

    public Image Line1;
    public Image Line2;

    public Text YouDied;
    public Text Kills;
    public Text ScrapGathered;
    public Text MedsGathered;
    public Text DifficultyMultiplier;

    public Text TotalScore;
    public Text HighScore;
    public GameObject NewHighScore;

    public GameObject PlayerGFX;
    public GameObject GunSelector;
    public PlayerMovement PM;

    public Points points;

    public Image Mainmenu;
    public Image Retry;
    public Text MMtext;
    public Text Rtext;

    void Start()
    {
        PlayerGFX.SetActive(false);
        GunSelector.SetActive(false);
        PM.enabled = false;

        t = 0;
        othert = -1;
        othert2 = -2;
        othert3 = -3;
        othert4 = -4;
    }


    void Update()
    {
        t += Time.deltaTime;
        othert += Time.deltaTime;
        othert2 += Time.deltaTime;
        othert3 += Time.deltaTime;
        othert4 += Time.deltaTime;
        
        GetComponent<Image>().color = Color.Lerp(StartC, EndC, t);


        YouDied.color = Color.Lerp(StartC, TextC, othert);

        Line1.color = Color.Lerp(StartC, TextC, othert2);
        Line2.color = Color.Lerp(StartC, TextC, othert2);

        Kills.text = "Kills: " + points.Kills.ToString();
        ScrapGathered.text = "Scrap Gathered: " + points.Scrap.ToString();
        MedsGathered.text = "Meds Gathered: " + points.Meds.ToString();
        DifficultyMultiplier.text = "Difficulty Multiplier: " + WaveManager.DifficultyMultiplier.ToString();

        TotalScore.text = "Total Score: " + points.points.ToString();
        HighScore.text = "High Score: " + points.HighScore.ToString();

        if(points.points > points.OldHighScore) 
        {
            NewHighScore.SetActive(true);
        }

        Kills.color = Color.Lerp(StartC, TextC,othert2);
        ScrapGathered.color = Color.Lerp(StartC, TextC, othert2);
        MedsGathered.color = Color.Lerp(StartC, TextC, othert2);
        DifficultyMultiplier.color = Color.Lerp(StartC, TextC, othert2);

        TotalScore.color = Color.Lerp(StartC, TextC, othert3);
        HighScore.color = Color.Lerp(StartC, TextC, othert3);

        Mainmenu.color = Color.Lerp(StartC, TextC, othert4);
        Retry.color = Color.Lerp(StartC, TextC, othert4);
        MMtext.color = Color.Lerp(StartC, EndC, othert4);
        Rtext.color = Color.Lerp(StartC, EndC, othert4);
    }

    public void Restart() 
    {
        StartCoroutine(RestartScene());
    }

    public void MainMenuButton()
    {
        StartCoroutine(MainMenu());
    }

    IEnumerator RestartScene() 
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }

    IEnumerator MainMenu()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Play() 
    {
        StartCoroutine(PlayNow());
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void BackToMainMenu() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    IEnumerator PlayNow() 
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject Player;
    public bool IsPaused;
    public GameObject Inv;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && IsPaused == false) 
        {
            Inv.SetActive(true);
            PauseMenu.SetActive(true);
            Player.SetActive(false);
            StartCoroutine(PauseNow());
        }
        if (Input.GetKeyDown(KeyCode.Escape) && IsPaused == true)
        {
            UpPause();
        }
    }

    public void UpPause() 
    {
        IsPaused = false;
        Inv.SetActive(false);
        PauseMenu.SetActive(false);
        Player.SetActive(true);
        Time.timeScale = 1;
    }

    IEnumerator PauseNow()
    {
        yield return new WaitForSeconds(0.1f);
        IsPaused = true;
        Time.timeScale = 0;
    }
}

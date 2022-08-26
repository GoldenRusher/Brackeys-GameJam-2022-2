using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text text;


    private void Start()
    {
        text = GetComponent<Text>();
    }
    void Update()
    {
        if(PlayerPrefs.GetInt("Points") > 0) 
        {
            text.text = "High Score: " + PlayerPrefs.GetInt("Points").ToString();
        }
        else 
        {
            text.text = "";
        }
        
    }
}

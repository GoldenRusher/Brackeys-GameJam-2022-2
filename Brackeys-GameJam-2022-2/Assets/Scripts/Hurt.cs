using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hurt : MonoBehaviour
{
    public Color StartC;
    public Color EndC;

    float t ;

    Image img;
    void Start()
    {
        img = GetComponent<Image>();
        t = 1;
    }

    
    void Update()
    {
        t += Time.deltaTime;
        img.color = Color.Lerp(EndC, StartC, t);
    }

    public void ChangeColor() 
    {
        t = 0;
    }
}

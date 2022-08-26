using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject img;
    public Color startc;
    public Color EndC;
    //a
    float t;
    bool shouldbeActive = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player")) 
        {
            shouldbeActive = true;
            t = 0;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            shouldbeActive = false;
            t = 0;
        }
    }

    private void Update()
    {
        t += Time.deltaTime * 3;
        if (shouldbeActive) 
        {
            img.GetComponent<Text>().color = Color.Lerp(startc, EndC, t);
        }
        else 
        {
            img.GetComponent<Text>().color = Color.Lerp(EndC, startc, t);
        }
    }
}

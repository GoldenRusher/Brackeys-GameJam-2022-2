using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public GameObject[] ShopChoices;
    public GameObject[] ShopPoints;

    public GameObject RightButton;
    public GameObject LeftButton;

    public int CurrentShopPoint = 0;

    void Update()
    {
        if((CurrentShopPoint - 1) < 0) 
        {
            LeftButton.SetActive(false);
        }
        else 
        {
            LeftButton.SetActive(true);
        }

        if(CurrentShopPoint + 4 <= ShopChoices.Length) 
        {
            RightButton.SetActive(true);
        }
        else 
        {
            RightButton.SetActive(false);
        }

        if (!((CurrentShopPoint - 1) < 0))
        {
            ShopChoices[CurrentShopPoint - 1].SetActive(false);
        }
        if(((CurrentShopPoint + 3) < ShopChoices.Length)) 
        {
            ShopChoices[CurrentShopPoint + 3].SetActive(false);
        }

        ShopChoices[CurrentShopPoint].SetActive(true);
        ShopChoices[CurrentShopPoint + 1].SetActive(true);
        ShopChoices[CurrentShopPoint + 2].SetActive(true);

        ShopChoices[CurrentShopPoint].transform.position = ShopPoints[0].transform.position;
        ShopChoices[CurrentShopPoint + 1].transform.position = ShopPoints[1].transform.position;
        ShopChoices[CurrentShopPoint + 2].transform.position = ShopPoints[2].transform.position;
    }

    public void GoLeft() 
    {
        if(!((CurrentShopPoint - 1) < 0)) 
        {
            CurrentShopPoint--;
        }
    }
    public void GoRight()
    {
        if (((CurrentShopPoint + 1) <= ShopChoices.Length))
        {
            CurrentShopPoint++;
        }
    }
}

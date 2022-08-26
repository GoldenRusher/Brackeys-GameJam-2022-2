using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using FMODUnity;

public class UIButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    [SerializeField]
    public FMODUnity.EventReference MouseHover;
    [SerializeField]
    public FMODUnity.EventReference MouseClick;

    public void OnPointerEnter(PointerEventData eventData)
    {
         FMODUnity.RuntimeManager.PlayOneShotAttached(MouseHover, gameObject);   
    }



    public void OnPointerDown(PointerEventData eventData)
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(MouseClick, gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

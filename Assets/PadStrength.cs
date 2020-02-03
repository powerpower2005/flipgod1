using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PadStrength : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{


    public Bottle bottle;
    private bool isTouch = false;
    public bool isJumped { get; set; }
    public int strength_time { get; set; }
    public int addStrength = 3;
    
    void Start()
    {
    }


    void Update()
    {
        if (isTouch)
        {
            strength_time += addStrength;
        }
    }

   
    public void OnPointerDown(PointerEventData eventData)
    {
        strength_time = 0;
        isTouch = true;
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch = false;
        isJumped = true;
        bottle.Jump();
    }
}

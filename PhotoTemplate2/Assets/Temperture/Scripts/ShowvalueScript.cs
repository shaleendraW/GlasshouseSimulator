﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class ShowvalueScript : MonoBehaviour
{
    
    public GameObject objectToDisable1;
    public static bool disabled = false;
    public int slidervalue;
    
    Text celciusText;

    void Start()
    {
        celciusText = GetComponent<Text>();

    }
    // Update is called once per frame
    public void textUpdate(float value)
    {
        slidervalue = Mathf.RoundToInt(value) + 25;
        celciusText.text = slidervalue + "°c";
    }
    void Update()
    {
            
            if (slidervalue == 30)
            {
                objectToDisable1.SetActive(true);
              
             }
            else
            {
                objectToDisable1.SetActive(false);

            }

    }

  
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class showvalueScript_Light : MonoBehaviour
{

    
    public static bool disabled = false;
    public int slidervalue;
    public int optiumluxlevel=calculate_lux_level.GetOptimumLevel();
    public int actualResult;


    Text celciusText;
    void Start()
    {
        celciusText = GetComponent<Text>();

    }
    // Update is called once per frame
    public void textUpdate(float value)
    {
        slidervalue = Mathf.RoundToInt(value);
        actualResult = slidervalue * 1000 + optiumluxlevel;
        celciusText.text = actualResult + "lux";
    }
    void Update()
    {
        print(slidervalue);
        if (slidervalue >= 2 )
        {

            bulbActive.setactivate = true;
          

        }
        else
        {
            bulbActive.setactivate = false;
        }

    }



}

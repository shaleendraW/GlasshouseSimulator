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
    public int optiumluxlevel;
    public int actualResult;
    string luxVal;


    Text celciusText;
    void Start()
    {
        luxVal = calculate_lux_level.GetOptimumLevel().ToString();
        celciusText = GetComponent<Text>();
        celciusText.text = luxVal+"lux";
        print("-----------");

    }

    public void changeTextValue() {
        luxVal = calculate_lux_level.GetOptimumLevel().ToString();
        celciusText.text = luxVal+"lux";
    }

    // Update is called once per frame
    public void textUpdate(float value)
    {

        slidervalue = Mathf.RoundToInt(value);
        actualResult = slidervalue * 1000 + calculate_lux_level.GetOptimumLevel();
        celciusText.text = actualResult + "lux";
    }
    void Update()
    {
        print(slidervalue);
        if (slidervalue >= 2 )
        {
            Activate_colour_pallet_light.activatelightcolourpallet = true;
            bulbActive.setactivate = true;
            
          

        }
        else 
        {
            bulbActive.setactivate = false;
            Activate_colour_pallet_light.activatelightcolourpallet = false;
        }

    }



}

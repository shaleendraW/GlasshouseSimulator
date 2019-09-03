using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class ShowvalueScript : MonoBehaviour
{

    
    public static bool disabled = false;
    public int slidervalue;
    string celciusvalue="";
    public int actualResult;


    Text celciusText;

    void Start() 
    {

        celciusvalue = Set_Temp_optimum_level.GetOptimumLevel().ToString();
        celciusText = GetComponent<Text>();
        celciusText.text = celciusvalue + "°c";
    }


    public void changeTempTextValue()
    {
        celciusvalue = Set_Temp_optimum_level.GetOptimumLevel().ToString();
        celciusText.text = celciusvalue + " °c";
    }
    // Update is called once per frame
    public void textUpdate(float value)
    {
        slidervalue = Mathf.RoundToInt(value);
        actualResult = slidervalue + Set_Temp_optimum_level.GetOptimumLevel();
        celciusText.text = actualResult + " °c";
    }
    void Update()
    {
        print(slidervalue);
        if (slidervalue>1)
        {

            //activate_sensoreadings.activateBool = true;
            fanRotate_temp.rotatebool = true;
            activate_distribution.activateBool = true;
            activate_Colorpalet.activatefancolourpallet = true;
            activate_Colorpalet.activateheatercolourpallet = false;



        }
        else if (slidervalue<-1)
        {
            setactivate.activateBool = true;
            activate_Colorpalet.activateheatercolourpallet = true;
            activate_Colorpalet.activatefancolourpallet = false;
        }
        else
        {
            setactivate.activateBool = false;
            fanRotate_temp.rotatebool = false;
            activate_sensoreadings.activateBool = false;
            activate_distribution.activateBool = false;
            activate_Colorpalet.activateheatercolourpallet = false;
            activate_Colorpalet.activatefancolourpallet = false;

        }

    }



}

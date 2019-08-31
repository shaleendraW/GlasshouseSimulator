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
        print(slidervalue);
        if (slidervalue == 30)
        {

            activate_sensoreadings.activateBool = true;
            fanRotate_temp.rotatebool = true;
            activate_distribution.activateBool = true;



        }
        else if (slidervalue == 15)
        {
            setactivate.activateBool = true;
        }
        else
        {
            setactivate.activateBool = false;
            fanRotate_temp.rotatebool = false;
            activate_sensoreadings.activateBool = false;
            activate_distribution.activateBool = false;

        }

    }



}

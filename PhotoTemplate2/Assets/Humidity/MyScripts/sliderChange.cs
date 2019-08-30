using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderChange : MonoBehaviour
{
    // Start is called before the first frame update
    public float RHslider;
    Text humidtydisplay;
    void Start()
    {
        humidtydisplay = GetComponent<Text>();
    }

    // Update is called once per frame
    public void sliderobj(float speed)
    {
        RHslider = speed;
        humidtydisplay.text = speed + "RH%";
       
    }
    void Update()
    {

        if (RHslider > 80)
        {
            fanRotate.rotatebool = true;
            enableSmoke.enablesmoke = false;
            fanRotate.speed = -1500.0f;

        }
        else if(RHslider > 70)
        {
            fanRotate.rotatebool = true;
            enableSmoke.enablesmoke = false;
            fanRotate.speed = -1000.0f;
        }
        else if (RHslider > 60)
        {
            fanRotate.rotatebool = true;
            enableSmoke.enablesmoke = false;
            fanRotate.speed = -500.0f;
        }
        else if(RHslider > 20 && RHslider < 60)
        {
            enableSmoke.enablesmoke = true;
        }
        else
        {
            fanRotate.rotatebool = false;
            enableSmoke.enablesmoke = false;
        }
    }
}

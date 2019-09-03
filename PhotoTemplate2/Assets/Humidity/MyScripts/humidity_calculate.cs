using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class humidity_calculate : MonoBehaviour
{
    public InputField witdh;
    public InputField hight;
    public Text result;
    public Text waterfall;
  
    public static double RHslider =50;

    double optimal= 90;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            double H = Convert.ToDouble(witdh.text);   //10
            double W = Convert.ToInt32(hight.text);     //1
            double area = W * H;    //10*1 =10
            double spAria = 2 * 3.14 * 1;  //6.28
            double noOfSp = area / spAria;   //10/6.28 = 1.59
            result.text = Convert.ToInt16(noOfSp).ToString(); //1.59

            double diffRH = optimal - RHslider;  //90-50 = 40
            double greenhouseVolume = W * H * 5;    //1*1*5 = 5

            double reqWaterVolume = (100 * greenhouseVolume) * (diffRH / 100); //100*5 * 40/100   = 200
            double rainfall = reqWaterVolume / Convert.ToInt32(noOfSp);   //200/1
                                                                          // waterfall.text = Convert.ToInt16(RHslider).ToString();  //200
            waterfall.text = Convert.ToInt16(rainfall).ToString();  //200
        }
        catch(Exception ex)
        {
            print(ex.ToString());
        }
            
    }
    public void sliderobj(float speed)
    {
        RHslider = speed;
       

    }
    public void NoOfSp()
    {

    }
}

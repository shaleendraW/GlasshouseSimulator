using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class calculate_lux_level : MonoBehaviour
{
    // Start is called before the first frame update

    public static int TOMATO_OPTIMUM_LUX_LEVEL=19111;
    public static int STRAWBERRY_OPTIMUM_LUX_LEVEL = 13704; 
    public static int LETTUCE_OPTIMUM_LUX_LEVEL = 12000;

    public static bool IsclickTomato = false;
    public static bool Isclickstawberry = false;
    public static bool Isclicklettues = false;

    public static int BULB_LUX_LEVEL = 1500;


    public Text optimum_lux,num_of_bulb;

    public void Set_Cul_TomatoOptimumluxlevel() {

        optimum_lux.text = TOMATO_OPTIMUM_LUX_LEVEL.ToString() + " lux";
        num_of_bulb.text = (TOMATO_OPTIMUM_LUX_LEVEL / BULB_LUX_LEVEL).ToString()+" bulbs";
        IsclickTomato = true;
        Isclickstawberry = false;
        Isclicklettues = false;
    }

    public void setStrawberryOptimumluxlevel()
    {


        optimum_lux.text = STRAWBERRY_OPTIMUM_LUX_LEVEL.ToString() + " lux";
        num_of_bulb.text = (STRAWBERRY_OPTIMUM_LUX_LEVEL / BULB_LUX_LEVEL).ToString() + " bulbs";
        Isclickstawberry = true;
        IsclickTomato = false;
        Isclicklettues = false;

    }

    public void SetLettuceOptimumluxlevel()
    {
        optimum_lux.text = LETTUCE_OPTIMUM_LUX_LEVEL.ToString() + " lux";
        num_of_bulb.text = (LETTUCE_OPTIMUM_LUX_LEVEL / BULB_LUX_LEVEL).ToString() + " bulbs";
        Isclicklettues = true;
        Isclickstawberry = false;
        IsclickTomato = false;

    }

    public static int GetOptimumLevel()
    {
        if (IsclickTomato)
            return TOMATO_OPTIMUM_LUX_LEVEL;
        else if (Isclickstawberry)
            return STRAWBERRY_OPTIMUM_LUX_LEVEL;
        else if (Isclicklettues)
            return LETTUCE_OPTIMUM_LUX_LEVEL;
        else
            return 15000;
    }
}

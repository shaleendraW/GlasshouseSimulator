using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Set_Temp_optimum_level : MonoBehaviour
{
    // Start is called before the first frame update

    public static int CARROT_OPTIMUM_TEMP_LEVEL=18;
    public static int CUCUMBER_OPTIMUM_TEMP_LEVEL = 25; 
    public static int CABBAGE_OPTIMUM_TEMP_LEVEL = 17;

    public static bool Isclickcarrot = false;
    public static bool Isclickcucumber = false;
    public static bool Isclickcabbage = false;

    public Text optimum_Temp;

    public void Set_carrotOptimumTemplevel() {

        optimum_Temp.text = CARROT_OPTIMUM_TEMP_LEVEL.ToString() + "°c";
        Isclickcarrot = true;
        Isclickcucumber = false;
        Isclickcabbage = false;
    }

    public void setcucumberOptimumTemplevel()
    {


        optimum_Temp.text = CUCUMBER_OPTIMUM_TEMP_LEVEL.ToString() + " °c";

        Isclickcarrot = false;
        Isclickcucumber =true;
        Isclickcabbage = false;

    }

    public void SetCabbageOptimumTemplevel()
    {
        optimum_Temp.text = CABBAGE_OPTIMUM_TEMP_LEVEL.ToString() + " °c";

        Isclickcarrot = false;
        Isclickcucumber = false;
        Isclickcabbage = true;

    }

    public static int GetOptimumLevel()
    {
        if (Isclickcarrot)
            return CARROT_OPTIMUM_TEMP_LEVEL;
        else if (Isclickcucumber)
            return CUCUMBER_OPTIMUM_TEMP_LEVEL;
        else if (Isclickcabbage)
            return CABBAGE_OPTIMUM_TEMP_LEVEL;
        else
            return 20;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate_Colorpalet : MonoBehaviour
{
    public GameObject ColourpaletFan, ColourpaletHeater;
    public static bool activatefancolourpallet = false;
    public static bool activateheatercolourpallet = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activatefancolourpallet)
        
            ColourpaletFan.SetActive(true);
           
        
        else if(activateheatercolourpallet)

            ColourpaletHeater.SetActive(true);

        else
        {
            ColourpaletFan.SetActive(false);
            ColourpaletHeater.SetActive(false);
        }
    }
}

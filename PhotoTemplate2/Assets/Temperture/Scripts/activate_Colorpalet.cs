using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate_Colorpalet : MonoBehaviour
{
    public GameObject ColourpaletFanCucumber, ColourpaletFanCarrot, ColourpaletFanCabbage, ColourpaletHeaterCucumber, ColourpaletHeaterCarrot, ColourpaletHeaterCabbage;
    public static bool activatefancolourpallet = false;
    public static bool activateheatercolourpallet = false;

    public static bool Isclickcarrot = false;
    public static bool Isclickcucumber = false;
    public static bool Isclickcabbage = false;

    public void SetIsclickCucumber()
    {
        Isclickcarrot = false;
        Isclickcucumber = true;
        Isclickcabbage = false;
    }

    public void SetIsclickCarrot()
    {
        Isclickcarrot = true;
        Isclickcucumber = false;
        Isclickcabbage = false;
    }

    public void SetIsclickCabbage()
    {
        Isclickcarrot = false;
        Isclickcucumber = false;
        Isclickcabbage = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activatefancolourpallet)
        {
            if(Isclickcucumber)
                ColourpaletFanCucumber.SetActive(true);
            else if(Isclickcarrot)
                ColourpaletFanCarrot.SetActive(true);
            else if(Isclickcabbage)
                ColourpaletFanCabbage.SetActive(true);

          
        
        }
        else if (activateheatercolourpallet)
        {
            if (Isclickcucumber)
                ColourpaletHeaterCucumber.SetActive(true);
            else if (Isclickcarrot)
                ColourpaletHeaterCarrot.SetActive(true);
            else if (Isclickcabbage)
                ColourpaletHeaterCabbage.SetActive(true);
            
          

        }
        else
        {
            ColourpaletFanCucumber.SetActive(false);
            ColourpaletFanCarrot.SetActive(false);
            ColourpaletFanCabbage.SetActive(false);
            ColourpaletHeaterCucumber.SetActive(false);
            ColourpaletHeaterCarrot.SetActive(false);
            ColourpaletHeaterCabbage.SetActive(false);
           
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_colour_pallet_light : MonoBehaviour
{
    public GameObject Colorpaletlight;
    public static bool activatelightcolourpallet = false;

    public void setactivatelightcolourpallet()
    {
        activatelightcolourpallet = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activatelightcolourpallet)

            Colorpaletlight.SetActive(true);

        else

            Colorpaletlight.SetActive(false);
            
        

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_colour_pallet_light : MonoBehaviour
{
    public GameObject Colorpaletlight;
    public static bool activatelightcolourpallet = false;
    // Start is called before the first frame update

    public void set_value_activatelightcolourpallet()
    {
        activatelightcolourpallet = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        try {
            if (activatelightcolourpallet)

                Colorpaletlight.SetActive(true);

            else

                Colorpaletlight.SetActive(false);

            }
        catch (System.Exception e)
        {

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilHidePnl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;


    bool count1;
    void Start()
    {
        count1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hidepannel()
    {
        if (count1 == true)
        {
            panel.gameObject.SetActive(false);
            enablesoilImage.count3 = true;
            enableSoilwaterdrop.count2 = true;
            count1 = false;
        }
        else
        {
            panel.gameObject.SetActive(true);
            enablesoilImage.count3 = false;
            enableSoilwaterdrop.count2 = false;
            count1 = true;

        }
    }
    }

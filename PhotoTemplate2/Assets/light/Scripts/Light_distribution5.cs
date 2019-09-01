using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_distribution5 : MonoBehaviour
{
    public GameObject hologram, bulb, plane;
    bool activate = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activate)
        {
            hologram.SetActive(true);
            bulb.SetActive(true);
            plane.SetActive(true);
        }
        else
        {
            hologram.SetActive(false);
            bulb.SetActive(false);
            plane.SetActive(false);
        }

    }
}

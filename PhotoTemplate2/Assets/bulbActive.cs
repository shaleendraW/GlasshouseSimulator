using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulbActive : MonoBehaviour
{
    public GameObject bulb;
    public static bool setactivate=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (setactivate)
            bulb.SetActive(true);
        else
            bulb.SetActive(false);
        
    }
}

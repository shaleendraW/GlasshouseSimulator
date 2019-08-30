using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableSlider : MonoBehaviour
{
    public GameObject slider1;
    bool status;
    // Start is called before the first frame update
    void Start()
    {
        status = true;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void enableslider()
    {
        if (status == true)
        {
            slider1.gameObject.SetActive(true);
            status = false;
        }
        else
        {
            slider1.gameObject.SetActive(false);
            status = true;

        }
    }
}

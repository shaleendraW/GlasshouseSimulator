using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableSoilwaterdrop : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject waterdrop;
    public static bool count2;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (count2 == true)
        {
            waterdrop.gameObject.SetActive(true);
      
        }
        else
        {

            waterdrop.gameObject.SetActive(false);
     

        }
    }

    //public void hidepannel()
    //{
    //    if (count2 == true)
    //    {
    //        waterdrop.gameObject.SetActive(true);

    //        count2 = false;
    //    }
    //    else
    //    {

    //        waterdrop.gameObject.SetActive(false);

    //        count2 = true;

    //    }
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enablesoilImage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject soilImage;

    public static bool count3;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (count3 == true)
        {
            soilImage.gameObject.SetActive(true);

       
        }
        else
        {

            soilImage.gameObject.SetActive(false);

         

        }
    }

    //public void hidepannel()
    //{
    //    if (count3 == true)
    //    {
    //        soilImage.gameObject.SetActive(true);

    //        count3 = false;
    //    }
    //    else
    //    {

    //        soilImage.gameObject.SetActive(false);

    //        count3 = true;

    //    }
    //}
}

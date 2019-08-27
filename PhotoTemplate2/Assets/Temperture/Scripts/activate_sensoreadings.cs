using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate_sensoreadings : MonoBehaviour
{
    public GameObject SensorReadingText;
    public static bool  activateBool = false;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if(activateBool)
            SensorReadingText.SetActive(true);
        else
            SensorReadingText.SetActive(false);
    }

    // get distance between two object
    float getDistance(GameObject obj1 , GameObject obj2) {
        return Vector3.Distance(obj1.transform.position,obj2.transform.position);
    }
}

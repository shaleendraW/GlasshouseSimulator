using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setactivate : MonoBehaviour
{
    public GameObject Heaterpanel,simulationModel;
  
    public static bool  activateBool = false;
    // Start is called before the first frame update
    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
        if (activateBool)
        {
            Heaterpanel.SetActive(true);
            simulationModel.SetActive(true);
        }
        else
        {
            Heaterpanel.SetActive(false);
            simulationModel.SetActive(true);

        }
    }

    // get distance between two object
    float getDistance(GameObject obj1 , GameObject obj2) {
        return Vector3.Distance(obj1.transform.position,obj2.transform.position);
    }
}

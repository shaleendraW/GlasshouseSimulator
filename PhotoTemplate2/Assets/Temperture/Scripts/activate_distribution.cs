using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate_distribution : MonoBehaviour
{
    public GameObject Distribution;
    public static bool activateBool = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activateBool)
            Distribution.SetActive(true);
        else
            Distribution.SetActive(false);

    }
}

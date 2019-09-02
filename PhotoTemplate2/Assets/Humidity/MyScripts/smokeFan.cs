using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokeFan : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fanSmoke;
    public static bool enaFanSmoke = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enaFanSmoke)
            fanSmoke.gameObject.SetActive(true);
        else
            fanSmoke.gameObject.SetActive(false);
    }
}

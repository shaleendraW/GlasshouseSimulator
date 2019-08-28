using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanRotate_temp : MonoBehaviour
{
    public float spinspeed = -1000.0f;
    public static bool rotatebool = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotatebool)
        transform.Rotate(0, spinspeed * Time.deltaTime, 0);
    }
}

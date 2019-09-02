using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanRotate : MonoBehaviour
{
    public float spinspeed = -1000.0f;
    public static bool rotatebool = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public static float speed = -1000.0f;
    
    // Update is called once per frame
    void Update()
    {
        spinspeed = speed;
        if (rotatebool)
            transform.Rotate(0, 0, spinspeed * Time.deltaTime);
        else
            transform.Rotate(0, 0, -1 * Time.deltaTime);
    }
}

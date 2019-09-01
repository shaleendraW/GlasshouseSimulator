using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huRotateFan : MonoBehaviour
{
    public float spinspeed = -0.0050f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spinspeed * Time.deltaTime, 0 , spinspeed * Time.deltaTime);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class humidity_calculate : MonoBehaviour
{
    public InputField witdh;
    public InputField hight;
    public Text result;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NoOfSp()
    {
        int H = Convert.ToInt32(witdh.text);
        int W = Convert.ToInt32(hight.text);
        int area = W * H;

        int noOfSp =area / 3;
        result.text = noOfSp.ToString();

    }
}

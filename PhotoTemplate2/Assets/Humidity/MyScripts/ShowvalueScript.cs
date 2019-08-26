using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowvalueScript : MonoBehaviour
{


    Text celciusText;

    void Start()
    {
        celciusText = GetComponent<Text>();
    }

    // Update is called once per frame
   public void textUpdate( float value)
    {
        celciusText.text = Mathf.RoundToInt(value)+25+"°c";
    }
}

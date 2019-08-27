using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnClick : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;

    bool count;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
     public void hidepannel()
    {
        if (count == true)
        {
            panel.gameObject.SetActive(false);
            count = false;
        }
        else
        {
            panel.gameObject.SetActive(true);
            count = true;

        }
    }


}

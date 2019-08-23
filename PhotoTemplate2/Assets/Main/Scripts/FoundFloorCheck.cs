using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundFloorCheck : MonoBehaviour
{
    public bool hasFoundFloor = false;
    public GameObject hand;
    public GameObject TopPanel;
    public GameObject BottomPanel;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        LineRenderer[] allLines = GetComponentsInChildren<LineRenderer>();
        if (allLines.Length > 0)
        {
            hasFoundFloor = true;
        }


        if (hasFoundFloor == true)
        {

            hand.SetActive(false);
            TopPanel.SetActive(true);
            BottomPanel.SetActive(true);
            Destroy(this);
        }

    }

}
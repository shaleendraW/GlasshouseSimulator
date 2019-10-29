using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulbActive : MonoBehaviour
{
    public GameObject gameobject_bulb;
    public GameObject gameobject_hologram;
    public GameObject gameobject_plane;
    public GameObject gameobject_spotlight;
    public static bool setactivate=false;

    public void Setsetactivate()
    {
        setactivate = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (setactivate)
        {
            gameobject_bulb.SetActive(true);
            gameobject_hologram.SetActive(true);
            gameobject_plane.SetActive(true);
            gameobject_spotlight.SetActive(true);
        }
        else
        {
            gameobject_bulb.SetActive(false);
            gameobject_hologram.SetActive(false);
            gameobject_plane.SetActive(false);
            gameobject_spotlight.SetActive(false);

        }

    }
}

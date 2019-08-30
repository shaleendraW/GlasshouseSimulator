using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableSmoke : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject smoke;
    public static bool enablesmoke =false;

    void Start()
    {

     
    }

    // Update is called once per frame
    void Update()
    {
       if(enablesmoke)
        smoke.gameObject.SetActive(true);
       else
            smoke.gameObject.SetActive(false);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPickUpTouch : MonoBehaviour {


    public LayerMask itemLayer;
    public ItemTouchConnection buttonConnection;
    EventTrigger.Entry entry;
    public bool isRotationAllowed = false;
    //public Vector3 OriginalChildPos;
    public bool isAutoRotateOn = true;
	// Use this for initialization
	void Start () {
        isAutoRotateOn = true;

	}

	//private void OnEnable()
	//{
        //OriginalChildPos = transform.GetChild(0).transform.localPosition;

	//}

	// Update is called once per frame
	void Update () {


        if (EventSystem.current.IsPointerOverGameObject() ||
           EventSystem.current.currentSelectedGameObject != null)
        {

            //Debug.Log(" BLOCK UI PICKUPTOUCH STOP ITEM");

            return;
        }

        foreach (Touch touch in Input.touches)
        {
            int id = touch.fingerId;
            if (EventSystem.current.IsPointerOverGameObject(id))
            {

                return;
            }
        }



        if (Application.isEditor)
        {

            if (Input.GetMouseButtonDown(0))
            {
 
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 500f, itemLayer))
                {
                    if(hit.collider.GetComponentInParent<ItemPickUpTouch>() == this){
                        hit.collider.GetComponentInParent<ItemPickUpTouch>().ReconnectToButton();
                    }
                     
                }
                else
                {
 
                }

            }

            if (Input.GetMouseButtonUp(0))
            {
                EndConnectToButton();

            }

        }
        else
        {

            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);


                if (touch.phase == TouchPhase.Began)
                {

                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit, 500f, itemLayer))
                    {
                        Debug.Log(" RECOONNECT BUTTON DOWN " + gameObject.name);
                        if (hit.collider.GetComponentInParent<ItemPickUpTouch>() == this)
                        {
                            hit.collider.GetComponentInParent<ItemPickUpTouch>().ReconnectToButton();
                        }
                    }
                    else
                    {
 
                    }
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    EndConnectToButton();
                }
            }else if (Input.touchCount == 2){
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Ended)
                {
                    EndConnectToButton();
                }
            }


        }
	}

    /// <summary>
    /// http://wiki.unity3d.com/index.php/DetectTouchMovement
    /// </summary>
    void LateUpdate()
    {
        if (isRotationAllowed == true)
        {
            if (buttonConnection.TouchPlaceScript.ItemTouchController != null)
            {
                // is this the current object selected in the TouchPlaceItem
                if (buttonConnection.TouchPlaceScript.ItemTouchController.ItemToSetIntoPlacer == this.gameObject)
                {
                    float pinchAmount = 0;
                    Quaternion desiredRotation = transform.rotation;

                    DetectTouchMovement.Calculate();

                    if (Mathf.Abs(DetectTouchMovement.pinchDistanceDelta) > 0)
                    { // zoom
                        pinchAmount = DetectTouchMovement.pinchDistanceDelta;
                    }

                    if (Mathf.Abs(DetectTouchMovement.turnAngleDelta) > 0)
                    { // rotate
                        Vector3 rotationDeg = Vector3.zero;
                        rotationDeg.y = -DetectTouchMovement.turnAngleDelta;
                        desiredRotation *= Quaternion.Euler(rotationDeg);
                    }

                    if (Input.touchCount == 2)
                    {
                        isAutoRotateOn = false;
                    }
                   

                    desiredRotation.x = 0;
                    desiredRotation.z = 0;
                    transform.rotation = desiredRotation;
                    pinchAmount = pinchAmount * 0.001f;
                    Vector3 newScale = transform.localScale;
                    newScale += pinchAmount * transform.localScale;
                    if (newScale.x > 0.5 && newScale.x < 2)
                    {
                        transform.localScale = newScale;
                    }
                }
            }
        }

    }

    public void ReconnectToButton(){
        transform.GetChild(0).transform.localPosition = Vector3.zero;

        if(buttonConnection.ItemToSetIntoPlacer==null){

            buttonConnection.ItemToSetIntoPlacer = this.gameObject;
            buttonConnection.SetItemToPlace();
        }


    }

    public void EndConnectToButton()
    {

        buttonConnection.PressUp();

    }

}

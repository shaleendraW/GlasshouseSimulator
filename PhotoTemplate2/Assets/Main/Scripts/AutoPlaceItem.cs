using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class AutoPlaceItem : MonoBehaviour {


    public ItemPlacerConnection ItemPlacedController;

    ARSessionOrigin m_SessionOrigin;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    public LayerMask layerMask;

    public GameObject[] TestingGround;

    public float speed = 3f;

    public bool isPlacing = false;

    public Vector3 LastPlacementPos;

    public Material planeMaterial;

    void Awake()
    {
        if (Application.isEditor)
        {
            for (int i = 0; i < TestingGround.Length; i++)
            {
                TestingGround[i].SetActive(true);
            }

        }else{

            for (int i = 0; i < TestingGround.Length; i++)
            {
                TestingGround[i].SetActive(false);
            }

        }

        SetPlaneOn(true);
        m_SessionOrigin = GetComponent<ARSessionOrigin>();
    }
 
    public void GameCode(Vector3 newPos){
        if (ItemPlacedController != null)
        {
            if (ItemPlacedController.hasItemBeenPlaced == false)
            {
                isPlacing = true;
                LastPlacementPos = newPos;
                ItemPlacedController.GetGameObjectToPlace().SetActive(true);
                ItemPlacedController.GetGameObjectToPlace().transform.parent = null;
                //GameObjectToPlace.transform.position = newPos;
                ItemPlacedController.GetGameObjectToPlace().transform.position = Vector3.Lerp(ItemPlacedController.GetGameObjectToPlace().transform.position, newPos, Time.deltaTime * speed);


                Vector3 CameraFlatPos = new Vector3(Camera.main.transform.position.x,newPos.y,Camera.main.transform.position.z);

                ItemPlacedController.GetGameObjectToPlace().transform.LookAt(CameraFlatPos);

                if (!ItemPlacedController.GetGameObjectToPlace().activeSelf)
                {
                    ItemPlacedController.GetGameObjectToPlace().SetActive(true);
                }
            }
        }
    }


    void Update()
    {
        if (ItemPlacedController != null)
        {
            if (Application.isEditor)
            {

                Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth * 0.5f, Camera.main.pixelHeight * 0.5f, 0f));
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 500f, layerMask))
                {
                    GameCode(hit.point);
                    //ItemPlacedController.GetGameObjectToPlace().transform.rotation = Quaternion.identity;


                }


            }
            else
            {

                if (m_SessionOrigin.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)), s_Hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = s_Hits[0].pose;
                    GameCode(hitPose.position);
                    //ItemPlacedController.GetGameObjectToPlace().transform.rotation = hitPose.rotation;


                }

            }

            if (isPlacing == false && ItemPlacedController.hasItemBeenPlaced == false)
            {
                HideItem();

            }else{

                CheckTouchType();

            }

            isPlacing = false;
        }

    }

    public void CheckTouchType(){


        if(EventSystem.current.IsPointerOverGameObject() ||
            EventSystem.current.currentSelectedGameObject !=null)
        {

            return;
        }



        if(Application.isEditor){

            if(Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if(Physics.Raycast(ray,out hit, 500f, layerMask))
                {
                    TapHasOccured();
                }

            }

        }else{

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (m_SessionOrigin.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = s_Hits[0].pose;
                    TapHasOccured();
                }
            }


        }


    }


    public void SetPlaneOn(bool isOn){

        Color color = planeMaterial.color;


        if(isOn==true){
            color.a = 0.3f;

        }else{

            color.a = 0;
            LineRenderer[] allLines = GetComponentsInChildren<LineRenderer>();
            for (int i = 0; i < allLines.Length; i++)
            {
                Destroy(allLines[i]);
            }

        }

        planeMaterial.color = color;

    }

    public void TapHasOccured(){

        if (ItemPlacedController.hasItemBeenPlaced == false)
        {
            ItemPlacedController.hasItemBeenPlaced = true;
            ItemPlacedController.GetGameObjectToPlace().transform.position = LastPlacementPos;
            SetPlaneOn(false);
        }

    }


    public void SetNewGameObjectToPlace(ItemPlacerConnection ItemPlacedController){
 
        ShouldWeHideIt();
        //GameObjectToPlace = newItem;
        this.ItemPlacedController = ItemPlacedController;
        SetPlaneOn(true);
    }

    public void ShouldWeHideIt(){
        if (ItemPlacedController != null)
        {
            if (ItemPlacedController.hasItemBeenPlaced == false)
            {
                HideItem();
            }
        }

    }

    public void HideItem(){
        if (ItemPlacedController != null)
        {
            ItemPlacedController.GetGameObjectToPlace().SetActive(false);
            ItemPlacedController.GetGameObjectToPlace().transform.parent = Camera.main.transform;
            ItemPlacedController.GetGameObjectToPlace().transform.localPosition = Vector3.zero;
        }
    }

    public void RemoveItemToPlace(){
        ItemPlacedController = null;
        SetPlaneOn(false);

    }
}

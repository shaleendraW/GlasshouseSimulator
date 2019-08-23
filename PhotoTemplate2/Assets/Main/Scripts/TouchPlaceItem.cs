using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class TouchPlaceItem : MonoBehaviour
{
    public ItemTouchConnection ItemTouchController;

    ARSessionOrigin m_SessionOrigin;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    public LayerMask layerMask;

    public GameObject[] TestingGround;

    public float speed = 3f;

    public bool isPlacing = false;

    public Vector3 LastPlacementPos;

    public Material planeMaterial;

    private AudioSource buttonSound;

    public ParticleSystem spotColour;

    void Awake()
    {
        buttonSound = GetComponent<AudioSource>();

        if (Application.isEditor)
        {
            for (int i = 0; i < TestingGround.Length; i++)
            {
                TestingGround[i].SetActive(true);
            }

        }
        else
        {

            for (int i = 0; i < TestingGround.Length; i++)
            {
                TestingGround[i].SetActive(false);
            }

        }

        SetPlaneOn(true);
        m_SessionOrigin = GetComponent<ARSessionOrigin>();
    }

    public void GameCode(Vector3 newPos)
    {
        if (ItemTouchController!= null)
        {
            if (ItemTouchController.hasItemBeenPlaced == false)
            {
                
                if (ItemTouchController.GetGameObjectToPlace() != null)
                {

                    if (isPlacing == false)
                    {
                        Animator anim = ItemTouchController.GetGameObjectToPlace().GetComponentInChildren<Animator>();
                        if (anim != null)
                        {
                            anim.ResetTrigger("Land");
                            anim.SetTrigger("PickUp");
                        }
                    }
                    isPlacing = true;
                    LastPlacementPos = newPos;
                    ItemTouchController.GetGameObjectToPlace().SetActive(true);
                    ItemTouchController.GetGameObjectToPlace().transform.parent = null;

                    ItemTouchController.RestartIcon();

                    Vector3 CameraFlatPos = new Vector3(Camera.main.transform.position.x, newPos.y, Camera.main.transform.position.z);
                    if (ItemTouchController.GetItemAutoRotate() ==true)
                    {
                        ItemTouchController.GetGameObjectToPlace().transform.position = Vector3.Lerp(ItemTouchController.GetGameObjectToPlace().transform.position, newPos, Time.deltaTime * speed);
                        if (ItemTouchController.GetCanRotate() == false)
                        {
                            ItemTouchController.GetGameObjectToPlace().transform.LookAt(CameraFlatPos);
                        }

                    }else{
                        ItemTouchController.GetGameObjectToPlace().transform.position = new Vector3(ItemTouchController.GetGameObjectToPlace().transform.position.x,newPos.y,ItemTouchController.GetGameObjectToPlace().transform.position.z);

                    }

                    if (!ItemTouchController.GetGameObjectToPlace().activeSelf)
                    {
                        ItemTouchController.GetGameObjectToPlace().SetActive(true);
                    }
                }
            }
        }
    }




    void Update()
    {
        //https://stackoverflow.com/questions/33301344/in-unity3d-how-detect-touch-on-ui-or-not


        if (EventSystem.current.IsPointerOverGameObject() ||
            EventSystem.current.currentSelectedGameObject != null)
        {

            HideItem();

            return;
        }

        foreach (Touch touch in Input.touches)
        {
            int id = touch.fingerId;
            if (EventSystem.current.IsPointerOverGameObject(id))
            {
                // ui touched
                HideItem();
                return;
            }
        }



        if (ItemTouchController != null)
        {
            if (Application.isEditor)
            {

                if (Input.GetMouseButton (0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit, 500f, layerMask))
                    {
                        GameCode(hit.point);
                    }

                }

            }
            else
            {

                if (Input.touchCount >0)
                {
                    Touch touch = Input.GetTouch(0);

                        if (m_SessionOrigin.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
                        {
                            Pose hitPose = s_Hits[0].pose;
                            GameCode(hitPose.position);
                        }
                }


            }

            CheckTouchType();


            if (isPlacing == false && ItemTouchController != null)
            {

                HideItem();

            }


            isPlacing = false;
        }

    }

    public void ButtonPressedSound(){

        buttonSound.Play();
    }

    public void CheckTouchType()
    {


        if (EventSystem.current.IsPointerOverGameObject() ||
            EventSystem.current.currentSelectedGameObject != null)
        {
            HideItem();
            ItemTouchController = null;
            return;
        }



        if (Application.isEditor)
        {

            if ( Input.GetMouseButtonUp(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 500f, layerMask))
                {
                    TapHasOccured();
                }else{

                        ItemTouchController.PressUp(); // this removes icon bug
                        HideItem();
                        if (ItemTouchController != null)
                        {
                            ItemTouchController.NullOldClone();
                        }

                }

            }

        }
        else
        {

            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);


                if (touch.phase == TouchPhase.Ended)
                {
                    if (m_SessionOrigin.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
                    {
                        Pose hitPose = s_Hits[0].pose;
                        TapHasOccured();
                    }else{

                            ItemTouchController.PressUp();
                            HideItem();
                            ItemTouchController.NullOldClone();

                    }
                }
            }


        }


    }


    public void SetPlaneOn(bool isOn)
    {

        Color color = planeMaterial.color;


        if (isOn == true)
        {
            color.a = 0.3f;

        }
        else
        {
            
            color.a = 0;
            LineRenderer[] allLines = GetComponentsInChildren<LineRenderer>();
            for (int i = 0; i < allLines.Length; i++)
            {
                Destroy(allLines[i]);
            }

        }

        planeMaterial.color = color;

    }

    public void TapHasOccured()
    {

        if (ItemTouchController.hasItemBeenPlaced == false)
        {
            Debug.Log("tap occured");
            ItemTouchController.PlayAudio();

            ItemTouchController.hasItemBeenPlaced = true;
            if (ItemTouchController.GetItemAutoRotate() == true)
            {
                ItemTouchController.GetGameObjectToPlace().transform.position = LastPlacementPos;
            }

            Animator anim = ItemTouchController.GetGameObjectToPlace().GetComponentInChildren<Animator>();
            if(anim!=null){
                anim.ResetTrigger("PickUp");
                anim.SetTrigger("Land");
            }
            Quaternion fixedRotataion = Quaternion.Euler(0,ItemTouchController.GetGameObjectToPlace().transform.eulerAngles.y,0);
            ItemTouchController.GetGameObjectToPlace().transform.rotation = fixedRotataion;
            SetPlaneOn(false);
            ItemTouchController.CanRotate();
            ItemTouchController.SetItemAutoRotate(true);
            ItemTouchController.ItemToSetIntoPlacer=null;
            ItemTouchController = null;
        }

    }


    public void SetNewGameObjectToPlace(ItemTouchConnection ItemTouchController)
    {

        ShouldWeHideIt();
        this.ItemTouchController = ItemTouchController;
        SetPlaneOn(true);
    }

    public void ShouldWeHideIt()
    {
        if (ItemTouchController != null)
        {
            if (ItemTouchController.hasItemBeenPlaced == false)
            {
                HideItem();
            }
        }

    }

    public void HideItem()
    {
        if (ItemTouchController != null)
        {
            
            if (ItemTouchController.GetGameObjectToPlace() != null)
            {
                if (ItemTouchController.GetItemAutoRotate() == true)
                {
                    ItemTouchController.GetGameObjectToPlace().SetActive(false);
                    ItemTouchController.GetGameObjectToPlace().transform.parent = Camera.main.transform;
                    ItemTouchController.GetGameObjectToPlace().transform.localPosition = Vector3.zero;
                }
            }

        }
    }

    public void RemoveItemToPlace()
    {

        ItemTouchController = null;
        SetPlaneOn(false);


    }
}

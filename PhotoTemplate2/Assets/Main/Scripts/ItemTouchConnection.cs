using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemTouchConnection : MonoBehaviour 
{

    public bool hasItemBeenPlaced = false;

    public GameObject ItemToClone;

    public GameObject ItemToSetIntoPlacer;
    //public AutoPlaceItem PlacerScript;

    public GameObject UiImage;
    public Vector3 UiImagePos;
    public TouchPlaceItem TouchPlaceScript;

    public bool hasBeenPressedDown = false;

    public Text debugText;

    public AudioClip[] audioClips;
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        RestartIcon();

    }

    // Update is called once per frame
    void Update()
    {


        if (EventSystem.current.IsPointerOverGameObject() ||
           EventSystem.current.currentSelectedGameObject != null)
        {

            isOver = true;
            if (Input.GetMouseButtonUp(0))
            {

                PressUp();
            }


        }
        else
        {
            
            isOver = false;
        }


        foreach (Touch touch in Input.touches)
        {
            int id = touch.fingerId;
            if (EventSystem.current.IsPointerOverGameObject(id))
            {
                // ui touched
                SetOverBool(true);

            }
            else
            {
                SetOverBool(false);
            }
        
        }


        PointerMove();
    }


    public bool GetItemAutoRotate(){

        return ItemToSetIntoPlacer.GetComponent<ItemPickUpTouch>().isAutoRotateOn;
    }

    public bool GetCanRotate()
    {

        return ItemToSetIntoPlacer.GetComponent<ItemPickUpTouch>().isRotationAllowed;
    }

    public void CanRotate()
    {
        ItemToSetIntoPlacer.GetComponent<ItemPickUpTouch>().isRotationAllowed = true;
    }

    public void SetItemAutoRotate(bool isAutoOn)
    {

        ItemToSetIntoPlacer.GetComponent<ItemPickUpTouch>().isAutoRotateOn=isAutoOn;
    }

    public void NullOldClone(){
        Destroy(ItemToSetIntoPlacer);
        ItemToSetIntoPlacer = null;

    }
     
    public void PressDown(){
        ItemToSetIntoPlacer = null;
        ItemToSetIntoPlacer = Instantiate(ItemToClone, ItemToClone.transform.position, ItemToClone.transform.rotation);
        UiImage.SetActive(true); 
        SetItemToPlace();
        TouchPlaceScript.ButtonPressedSound();

    }
    public void SetItemToPlace(){

        hasBeenPressedDown = true;
        hasItemBeenPlaced = false;

        TouchPlaceScript.SetNewGameObjectToPlace(this);
    }


    public bool isOver = false;

    public void SetOverBool(bool isOn){
        Debug.Log("SEEING ISOVER BOOL IS " + isOn);
        isOver = isOn;


    }
 
    public void PointerMove(){
        if (hasBeenPressedDown == true)
        {
            
            if(UiImage.transform.position!=UiImagePos){
                UiImage.SetActive(true);  
            }

            if (Application.isEditor)
            {
                UiImage.transform.position = new Vector3(Input.mousePosition.x, (Input.mousePosition.y + UiImage.GetComponent<RectTransform>().rect.height * 0.55f), 0);
            }else{
                if (Input.touchCount ==1)
                {
                    Touch touch = Input.GetTouch(0);
                    UiImage.transform.position = new Vector3(touch.position.x,(touch.position.y+UiImage.GetComponent<RectTransform>().rect.height*0.55f),0);
                }
            }

        }

    }

    public void RestartIcon(){
        UiImage.SetActive(false);
        UiImage.transform.position = UiImagePos;
    }



    public void PressUp()
    {

        RestartIcon();
        hasBeenPressedDown = false;



        if (isOver == true)
        {

            //Debug.Log("PRESS UP BLock");
            //Destroy(ItemToSetIntoPlacer);
            NullOldClone();
            TouchPlaceScript.RemoveItemToPlace();

        }


    }


    public void PlayAudio(){

        AudioClip newAudio = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.clip = newAudio;
        audioSource.Play();
    }


    public GameObject GetGameObjectToPlace(){
        return ItemToSetIntoPlacer;
    }

}

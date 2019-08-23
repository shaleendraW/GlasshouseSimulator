using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPlacerConnection : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool hasItemBeenPlaced = false;
    public GameObject ItemToSetIntoPlacer;
    public AutoPlaceItem PlacerScript;


    // Use this for initialization
    void Start()
    {
        if (hasItemBeenPlaced == false)
        {

            ItemToSetIntoPlacer.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Do this when the mouse is clicked over the selectable object this script is attached to.
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was Clicked.");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was Clicked.");
    }

    public void ButtonClicked(){

        if(hasItemBeenPlaced == false){

            if(PlacerScript.ItemPlacedController!=this){
                PlacerScript.SetNewGameObjectToPlace(this);

            }else{

                PutItemAway();
            }






        }else{
            PutItemAway();
        }


    }

    public GameObject GetGameObjectToPlace(){
        return ItemToSetIntoPlacer;
    }


    public void PutItemAway(){
        PlacerScript.SetNewGameObjectToPlace(this);
        hasItemBeenPlaced = false;
        PlacerScript.HideItem();
        PlacerScript.RemoveItemToPlace();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

    public Button[] allButtons;
    public Button firstSelection;
    private AudioSource ButtonSound;
	// Use this for initialization
	void Start () {
        ButtonSound = GetComponent<AudioSource>();
        ButtonPressed(firstSelection);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ButtonPressed(Button button){
        ButtonSound.Play();
        for (int i = 0; i < allButtons.Length; i++)
        {

            if(allButtons[i]!=button){

                allButtons[i].GetComponent<Image>().color = new Color32(255,255,255,155);
            }else{
                allButtons[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }

        }

    }
}

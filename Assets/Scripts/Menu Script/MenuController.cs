using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public int indexOfButton = -1;
    [SerializeField] bool keydown;
    [SerializeField] int maxNumOfButton;
    [SerializeField] MenuButton menuButton;

    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start() {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update() {   
        //Debug.Log(menuButton.checkMouse_over());

        //if(!menuButton.checkMouse_over()){
            if(Input.GetAxis("Vertical") != 0) {
                if(!keydown) {
                    if(Input.GetAxis("Vertical") < 0) {
                        if(indexOfButton < maxNumOfButton) {
                            indexOfButton++;
                        } else {
                            indexOfButton = 0;
                        }
                    } else if (Input.GetAxis("Vertical") > 0) {
                        if (indexOfButton > 0) {
                            indexOfButton--;
                        } else {
                            indexOfButton = maxNumOfButton;
                        }
                    }
                    keydown = true;
                }
            } else {
                keydown = false;
            }
    }

    public void resetIndexOfButton(){
        indexOfButton = -2;
    }

    public void showMouse(){
        Cursor.visible = true;
    }
}


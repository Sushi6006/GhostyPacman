﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    [SerializeField] MenuController menuController;
    [SerializeField] Animator animator;
    [SerializeField] MenuAnimationControl menuAnimationControl;
    [SerializeField] GameObject MainMenu;
    [SerializeField] int thisIndex;
    [SerializeField] bool mouse_over = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the player use the mouse to choose
        if(mouse_over){
            menuController.resetIndexOfButton();
            animator.SetBool ("selected", true);
            if(Input.GetAxis("Submit") == 1 || Input.GetMouseButton(0)){
                animator.SetBool("Click", true);
            
            }else if(animator.GetBool("Click")){
                animator.SetBool("Click", false);
                menuAnimationControl.disableOnce = true;
                mouse_over = false;
            }else if(!mouse_over){
                animator.SetBool("selected",false);
            }

        }else{
            if(menuController.indexOfButton == thisIndex){
                animator.SetBool ("selected", true);

                if(Input.GetAxis("Submit") == 1){
                    animator.SetBool("Click", true);
                    

                }else if(animator.GetBool("Click")){
                    animator.SetBool("Click", false);
                    menuAnimationControl.disableOnce = true;
                }
            }else{
                animator.SetBool("selected", false);
            }
        }
        if(!MainMenu.active){
            mouse_over = false;       
        
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
     {
         mouse_over = true;
     }
 
     public void OnPointerExit(PointerEventData eventData)
     {
         mouse_over = false;
         
     }


    public void switchtoMainScene(){
        SceneManager.LoadScene("MainScene");
    }

    public void switchtoMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void changeMouse(){
        mouse_over = false;
    }


    public void EndGame(){
        //Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}


    
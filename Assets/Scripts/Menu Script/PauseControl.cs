using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    
    public GameObject puaseMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        if(Input.GetKeyDown("escape")){
            Pause();
        }

        
    }

    public void Resume(){
        puaseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        
    }

    public void Pause(){
        puaseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;



    }
}

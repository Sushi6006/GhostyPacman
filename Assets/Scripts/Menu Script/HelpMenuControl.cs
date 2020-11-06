using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenuControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject HelpMenu;
    public GameObject MainMenu;
    void Start()
    {
        HelpMenu.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
        

    public void backToMain(){
        HelpMenu.SetActive(false);
        MainMenu.SetActive(true);

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseButton : MonoBehaviour
{
    [SerializeField] bool mouse_over = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showMouse(){
        Cursor.visible = true;
    }

    public void dontShowMouse(){
        Cursor.visible = false;
    }
}

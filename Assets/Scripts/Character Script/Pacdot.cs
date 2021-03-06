﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacdot : MonoBehaviour
{   

    //reborn clock
    private float reborn = 30f;
    //current time
    private float time = 0f;
    //whether is hide
    public bool isHide = false;

    //the owner of the script
    private GameObject pacdot;

    // Start is called before the first frame update
    void Start()
    {
        pacdot = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {   
        //reborn after reborn time
        if (isHide)
        {   
            time -= Time.deltaTime;
            if (time < 0f)
            {   
                pacdot.GetComponent<Renderer>().enabled = true;
                isHide = false;
            }
        }
    }
    
    /*when the object be eaten*/
    //hide the object when be eaten
    public void beEaten()
    {   
        if (!isHide)
        {
            pacdot.GetComponent<Renderer>().enabled = false;
            isHide = true;
            time = reborn;
        }
    }

}

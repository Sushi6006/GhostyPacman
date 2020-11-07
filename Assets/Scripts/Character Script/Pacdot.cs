﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacdot : MonoBehaviour
{   
    private float reborn = 30f;
    private float time = 0f;
    public bool isHide = false;

    private GameObject pacdot;

    // Start is called before the first frame update
    void Start()
    {
        pacdot = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {   
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
    
    public void beEaten()
    {   
        if (!isHide)
        {
            pacdot.GetComponent<Renderer>().enabled = false;
            isHide = true;
            time = reborn;
        }
    }

    public void testHid(bool test)
    {
        test = isHide;
    }

}

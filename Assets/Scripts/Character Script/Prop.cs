using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{   

    //reborn clock
    private float reborn = 60f;
    //current time
    private float time = 0f;
    //whether is hide
    public bool isHide = false;

    //float
    private float floatSpeed = 2f;
    //floating scale
    private float floatScale = 0.005f;

    //this owner of this script
    private GameObject prop;

    // Start is called before the first frame update
    void Start()
    {
        prop = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {   
        floatMove();

        //reborn after reborn time
        if (isHide)
        {   
            time -= Time.deltaTime;
            if (time < 0f)
            {   
                prop.GetComponent<Renderer>().enabled = true;
                isHide = false;
            }
        }
    }

    /*make it float*/
    private void floatMove()
    {
        transform.position += Vector3.up * Mathf.Cos(Time.time * floatSpeed) * floatScale;
    }
    
    /*when the object be eaten*/
    //hide the object when be eaten
    public void beEaten()
    {   
        if (!isHide)
        {
            prop.GetComponent<Renderer>().enabled = false;
            isHide = true;
            time = reborn;
        }
    }
}

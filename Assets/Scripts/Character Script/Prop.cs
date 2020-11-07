using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{   

    private float reborn = 60f;
    private float time = 0f;
    public bool isHide = false;

    //float
    private float floatSpeed = 2f;
    //floating scale
    private float floatScale = 0.001f;

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

    private void floatMove()
    {
        transform.position += Vector3.up * Mathf.Cos(Time.time * floatSpeed) * floatScale;
    }
    
    public void beEaten()
    {   
        if (!isHide)
        {
            prop.GetComponent<Renderer>().enabled = false;
            isHide = true;
            time = reborn;
        }
    }

    public void testHid(bool test)
    {
        test = isHide;
    }

}

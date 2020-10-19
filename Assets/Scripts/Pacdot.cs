using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacdot : MonoBehaviour
{   
    //初始生成时间5秒钟

    float times = 5f;

   //物体
    public GameObject pacdot;
    GameObject targert = null; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {   
        if (collider.name == "ghost")
        {   
            Destroy(gameObject);
        }
    }
}

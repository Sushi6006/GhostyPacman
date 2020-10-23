using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float rotateSpeed = 5f;
    Vector3 landScapeCentre = new Vector3(0f, 0f, 0f);
    Vector3 originPoint = new Vector3(0f, 100f, 0f);
    Vector3 originRotation = new Vector3(90f, 0f, 0f);

    // Update is called once per frame
    void Update() {

        selfRotation();

        /*
        //reset sun when press space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            resetSun();
        }
        */
    
    }

    void selfRotation()
    {
        transform.RotateAround(landScapeCentre, Vector3.right, rotateSpeed * Time.deltaTime);
    }

    /*
    void resetSun()
    {   
        transform.position = originPoint;
        transform.rotation = Quaternion.Euler(originRotation);
    }
    */
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
  private Vector3 transformFirst = new Vector3(0f, 0f, 10f);
  private Vector3 rotationFirst = new Vector3(10f, 0f, 0f);

  private Vector3 transformThird = new Vector3(0f, 100f, -150f);
  private Vector3 rotationThird = new Vector3(20f, 0f, 0f);

  private bool isFirst = false;

  //switch view's cooldown
  private float times = 0.25f;
  private float cooldown = 0.25f;
    void Start(){

    }

    void Update()
    { 
      times -= Time.deltaTime;
      if (Input.GetKey("v") && times < 0)
      { 
        if (isFirst)
        { 
          transform.localPosition = transformThird;
          transform.localEulerAngles = rotationThird;
          isFirst = false;
          times = cooldown;
        }
        else
        {
          transform.localPosition = transformFirst;
          transform.localEulerAngles = rotationFirst;
          isFirst = true;
          times = cooldown;
        }
      }
    }
 }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{ 
  /*prevent the camera from acrossing wall*/
  public GameObject target;
  public Camera camera;
  public float m_distanceAway = 4.5f;

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
      cameraHitCheck();

      //the time check the view's switch cooldown
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

    /*avoid the camera across the wall*/
    void cameraHitCheck()
    {
      //the line between camera and the object in the view of camera
      RaycastHit hit;

      if (Physics.Linecast(target.transform.position + Vector3.up, camera.transform.position, out hit))
      {
        string name = hit.collider.gameObject.tag;
        if (name != "MainCamera")
        {
          //get the distance between camera and player
          float currentDistance = Vector3.Distance(hit.point, target.transform.position);
          
          //zoom camera while the hitted object is wall
          if (currentDistance < m_distanceAway)
          {
            camera.transform.position = hit.point;
          }
        }
      }
    }
 }

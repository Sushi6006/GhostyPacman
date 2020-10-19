﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacman : MonoBehaviour
{   
    //movement attributes
    //the controller of pacman
    private CharacterController controller;
    //the speed of pacman's movement
    private float movementSpeed = 10f;
    //mouse sensitivity
    public float rotateSpeed = 4f;
    //gravity
    private float gravity = 20.0f;
    //the direction of pacman
    private Vector3 moveDirec;
    //floating speed
    private float floatSpeed = 5f;
    //floating scale
    private float floatScale = 0.05f;

    //pacdot attributes
    //pacdot is the object will be generated
    public GameObject pacdot;
    //the gap between generating
    private float generatingTime = 2.0f;
    private float times = 2.0f;
    //maximum number of pacdot
    private int maximumPacdot = 3;
    //current pacdot's number
    private int currentNumPacdot = 0;

    //player's score
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {   
        Move();
        PacdotGenerate();
        print(score);
    }

    // Move controller 
    void Move()
    {   
        //level shift
        moveDirec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirec = transform.TransformDirection(moveDirec);

        //direction control by mouse
        float mouseX = Input.GetAxis("Mouse X") * rotateSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotateSpeed;
        transform.localRotation = transform.localRotation * Quaternion.Euler(0, mouseX, 0);
        //gravity calculation
        //moveDirec.y = moveDirec.y - gravity * Time.deltaTime;

        //make pacman float
        moveDirec += Vector3.up * Mathf.Cos(Time.time * floatSpeed) * floatScale;
        controller.Move(moveDirec * Time.deltaTime * movementSpeed);
    }

    //generate new pacdot
    void PacdotGenerate()
    {
        times -= Time.deltaTime; 
        if (times < 0)
        {   
            if (currentNumPacdot < maximumPacdot)
            {
                //generate a new pacdot
                GameObject obj = (GameObject)Instantiate(pacdot);

                //position the new pacdot in the map
                int ni = Random.Range(0, 65);
                int nt = Random.Range(0, 65);
                obj.transform.position = new Vector3(ni, 0, nt);

                //increase number of current existing pacdot
                currentNumPacdot ++;
                //reset generating time
            }
            times = generatingTime;
        }
    }

    //eat the pacdot
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.tag == "pacdot")
        {   
            currentNumPacdot --;
            Destroy(hit.collider.gameObject);
            score ++;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pacmanController : MonoBehaviour{   

    //movement attributes
    //the controller of pacman
    private CharacterController controller;
    //the speed of pacman's movement
    private float movementSpeed = 3.0f;
    //
    private float rotateSpeed = 4f;
    //gravity
    private float gravity = 20.0f;
    //the direction of pacman
    private Vector3 moveDirec;
    

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {   
        move();
    }

    // Move controller 
    void move()
    {   
        //level shift
        moveDirec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirec = transform.TransformDirection(moveDirec);
        //direction control
         float mouseX = Input.GetAxis("Mouse X") * rotateSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotateSpeed;
        Camera.main.transform.localRotation = Camera.main.transform.localRotation * Quaternion.Euler(-mouseY, 0, 0);
        //gravity calculation
        //moveDirec.y = moveDirec.y - gravity * Time.deltaTime;

        transform.localRotation = transform.localRotation * Quaternion.Euler(0, mouseX, 0);
        controller.Move(moveDirec * Time.deltaTime * movementSpeed);
    }
}

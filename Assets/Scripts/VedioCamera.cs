using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VedioCamera : MonoBehaviour
{   
    private CharacterController controller;
    public float movementSpeed = 10f;
    public float rotateSpeed = 4f;
    private Vector3 moveDirec;
    private float flySpeed = 5f;
    // Start is called before the first frame update

    private float x = 0f;
    private float z = 0f;
    private float y = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {   
        moveDirec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirec = transform.TransformDirection(moveDirec);

        //direction control by mouse
        float mouseX = Input.GetAxis("Mouse X") * rotateSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotateSpeed;
        transform.localRotation = transform.localRotation * Quaternion.Euler(0, mouseX, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {   
            y ++;
            controller.Move(new Vector3(0, y, 0) * Time.deltaTime * flySpeed);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            y --;
            controller.Move(new Vector3(0, y, 0) * Time.deltaTime * flySpeed);
        }

        if (Input.GetKey("i"))
        {   
            x -= 3;
        }

        if (Input.GetKey("k"))
        {
            x += 3;
        }

        if (Input.GetKey("j"))
        {
            z -= 3;
        }

        if (Input.GetKey("l"))
        {
            z += 3;
        }

        transform.rotation=Quaternion.Euler(x, z, 0);
        controller.Move(moveDirec * Time.deltaTime * movementSpeed);
    }

}

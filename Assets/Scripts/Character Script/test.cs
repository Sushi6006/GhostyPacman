using UnityEngine;

public class test : MonoBehaviour
{
    public float turnspeed = 10;
    private CharacterController controller;
    private Vector3 moveDirec;
    private float movementSpeed = 5f;
    float ver = 0;
    float hor = 0;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {   
        moveDirec = this.transform.forward;
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        if (hor != 0 || ver != 0)
        {
            //转身            
            Rotate(hor, ver);
        }
        controller.Move(moveDirec * Time.deltaTime * movementSpeed);
    }

    void FixedUpdate()
    {
    }
    void Rotate(float hor, float ver)
    {
        //获取方向        
        Vector3 dir = new Vector3(hor, 0, ver);
        //将方向转换为四元数        
        Quaternion quaDir = Quaternion.LookRotation(dir, Vector3.up);
        //缓慢转动到目标点        
        transform.rotation = Quaternion.Lerp(transform.rotation, quaDir, Time.fixedDeltaTime * turnspeed);
    }
}

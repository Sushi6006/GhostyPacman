using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour{

        //the target we are following
        public Transform target;
        //the target we are looking
        public Transform lookAtTarget;
        private Vector3 lookAtOffset;
        
        //original position of camera
        private Vector3 originVector;
        private Vector3 lastFrameTargetRoation;

        //sensitivity
        public float mouseTurnedSpeed = 0.3f;
        //鼠标右键控制镜头旋转的代码
        private bool rightButtonDonwed;

        // Use this for initialization
        void Start() {
        //获取当前的distance和height
            originVector =new Vector3(target.position.x-transform.position.x,target.position.y-transform.position.y,target.position.z-transform.position.z);
            rightButtonDonwed = false;
            lastFrameTargetRoation = target.rotation.eulerAngles;
        }

        // Update is called once per frame
        void Update()
        {           

            //zooming
            float changeDistance = Input.GetAxis ("Mouse ScrollWheel") ;
            float currentDistance = originVector.magnitude;
            Vector3 miniVector = originVector.normalized;
            originVector = miniVector*(currentDistance-changeDistance*Time.deltaTime*100);


            //记录鼠标右键是否按下的状态
            if (Input.GetMouseButton (1) && Input.GetMouseButtonDown (1)) {
                rightButtonDonwed = true;
            }
            if (Input.GetMouseButtonUp (1)) {
                rightButtonDonwed = false;  
            }
            transform.position = target.position - originVector;
            print (rightButtonDonwed);
            if (rightButtonDonwed) {
                //获取鼠标旋转的度数 横轴
                float rotationAmount = Input.GetAxis ("Mouse X") * mouseTurnedSpeed * Time.deltaTime;
                //最终的旋转读书
                transform.RotateAround (target.position, Vector3.up, rotationAmount*360);
                //人物也旋转 保证镜头始终对着人物背面
                target.RotateAround(target.position, Vector3.up, rotationAmount*360);

                //纵轴
                float rotationAmountY = Input.GetAxis ("Mouse Y") * mouseTurnedSpeed * Time.deltaTime;
                Vector3 yCenter = new Vector3 (-originVector.z / originVector.x, target.position.y, 1);
                transform.RotateAround (target.position,yCenter,rotationAmountY*360);
            } else {
                transform.RotateAround(target.position,Vector3.up,target.rotation.eulerAngles.y -  lastFrameTargetRoation.y);

            }



            lastFrameTargetRoation = target.rotation.eulerAngles;
            originVector =new Vector3(target.position.x-transform.position.x,target.position.y-transform.position.y,target.position.z-transform.position.z);
         }
 }



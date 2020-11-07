using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Pacman : MonoBehaviour
{   
    /*movement attributes*/
    //the controller of pacman
    private CharacterController controller;
    //the speed of pacman's movement
    public float movementSpeed = 5f;
    //mouse sensitivity
    public float rotateSpeed = 4f;
    //standard movement speed
    private float standardMovementSpeed = 5f;
    //the direction of pacman
    private Vector3 moveDirec;
    //floating speed
    private float floatSpeed = 5f;
    //floating scale
    private float floatScale = 0.05f;

    //fps controller
    private bool isFPS = false;
    //classic controller
    private bool isClassic = false;
    //the last change's record of switching between fps and classic
    private float manipulateTime = 0f;
    private float coolDown = 0.25f;
    //the last change's record of classic wasd
    private float lastChange = 0f;
    //turn-back speed
    public float turnspeed = 3.5f;
    //the direction of rotation
    Quaternion quaDir;

    /*gravity check
    private float gravity = 0;
    //standard gravity
    private float standardGravity = -10f;
    //gravity acceleration
    private float acceleration = -9.8f;
    */
    
    /*UI part*/
    //player's score
    private int score = 0;
    public TextMeshProUGUI scoreText;
    //player's health
    public int health = 100;
    private bool isDead = false;
    public DeadMenuControl deadMenuControl;
    

    /*particle part*/
    //Effect part
    public GameObject MainDeathEffect;
    public GameObject PatrolDeathEffect;
    public GameObject ChasingDeathEffect;
    public GameObject AssDeathEffect;
    public GameObject objectToDisappear;
    public GameObject power_Ring;
    private bool effectRun = false;


    //sfx
    public AudioSource eatSfx;
    public AudioSource gameDie;
    public AudioSource eatShield;
    public AudioSource eatPower;
    public AudioSource eatAcceleration;


    /*prop*/
    //powerPacdot
    private bool isInvincible = false;
    private float invincibleTime = 0f;
    private float invincibleKeepTime = 5f;
    private GameObject powerRing;
    //speed up dot
    private bool isSpeedUp = false;
    private float acceleratedSpeed = 10f;
    private float speedUpTime = 0f;
    private float speedUpKeepTime = 5f;
    //shield pacdot
    private bool equipShield = false;
    public GameObject shieldPrefab;
    private GameObject currentShield = null;



    // Start is called before the first frame update
    void Start()
    {   
        controller = GetComponent<CharacterController>();
        isClassic = true;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {    
        if (!isDead){
            
            lastChange -= Time.deltaTime;
            manipulateTime -= Time.deltaTime;
            
            //switch the manipulate approach
            if (Input.GetKey("r") && manipulateTime < 0)
            {
                if (isFPS)
                {
                    isFPS = false;
                    isClassic = true;
                }
                else
                {
                    isFPS = true;
                    isClassic = false;
                }
                manipulateTime = coolDown;
            }

            Move();

            scoreText.text = "SCORE:" + score.ToString();

            //calculate invincible time
            if (isInvincible)
            {   
                powerRing.transform.position = this.transform.position;
                invincibleTime -= Time.deltaTime;
                if (invincibleTime <= 0)
                {
                    isInvincible = false;
                    Destroy(powerRing);
                } 
            }

            //calculate acceleration time
            if (isSpeedUp)
            {
                speedUpTime -= Time.deltaTime;
                if (speedUpTime <= 0)
                {
                    isSpeedUp = false;
                    movementSpeed = standardMovementSpeed;
                } 
            }

            //move shield with pacman
            if (equipShield)
            {
                currentShield.transform.position = this.transform.position;
            }

        }else{

            //Run the particle effect only once
            if(!effectRun){
                gameDie.Play();
                Instantiate(MainDeathEffect, transform.position, transform.rotation);
                effectRun = true;
            }

            scoreText.enabled = false;
            Cursor.visible = true;
            deadMenuControl.toggleDeadMenu(score);

            //hide the pacman
            objectToDisappear.GetComponent<Renderer>().enabled = false;
              
        }
        
    }

    public bool checkDead(){
        return isDead;
    }

    // Move controller 
    void Move()
    {   
        /*
        //check gravity
        if (!controller.isGrounded)
        {   
            //Simulate real falling with acceleration
            gravity += acceleration * Time.deltaTime;
            if (gravity < standardGravity)
            {
                gravity = standardGravity;
            }
        }
        moveDirec.y += gravity;
        */
        
        //make pacman float
        //moveDirec += Vector3.up * Mathf.Cos(Time.time * floatSpeed) * floatScale;

        //fps controller
        if (isFPS)
        {
            //level shift
            moveDirec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirec = transform.TransformDirection(moveDirec);

            //direction control by mouse
            float mouseX = Input.GetAxis("Mouse X") * rotateSpeed;
            //float mouseY = Input.GetAxis("Mouse Y") * rotateSpeed;
            transform.localRotation = transform.localRotation * Quaternion.Euler(0, mouseX, 0);
        }
        
        //classic controller
        else if (isClassic)
        {   
            //move forward
            moveDirec = this.transform.forward;
            if (lastChange < 0){
                //control the direction
                if (Input.GetKey("w") )
                {
                    //transform.localRotation = transform.localRotation * Quaternion.Euler(0, 0, 0);
                }
                if (Input.GetKey("s"))
                {   
                    quaDir = transform.localRotation * Quaternion.Euler(0, 180, 0);
                    lastChange = coolDown;
                }
                if (Input.GetKey("a"))
                {   
                    quaDir = transform.localRotation * Quaternion.Euler(0, -90, 0);
                    lastChange = coolDown;
                }
                if (Input.GetKey("d"))
                {
                
                    quaDir = transform.localRotation * Quaternion.Euler(0, 90, 0);
                    lastChange = coolDown;
                }
            }
            transform.rotation = Quaternion.Lerp(transform.rotation, quaDir, Time.fixedDeltaTime * turnspeed);
        }   
        controller.Move(moveDirec * Time.deltaTime * movementSpeed);
    }


    //collision test
    void OnTriggerEnter(Collider hit)
    {      
        GameObject target = hit.gameObject;
        propCollision(target);
        ghostCollision(target);
    }

    /*collide with props*/
    void propCollision(GameObject target)
    {
        //eat the pacdot
        if (target.tag == "pacdot" && !target.GetComponent<Pacdot>().isHide)
        {      
            eatSfx.Play();
            target.SendMessage("beEaten");
            score ++;
        }

        //eat the power pacdot
        if (target.tag == "PowerPacdot" && !target.GetComponent<Prop>().isHide)
        {   
            eatPower.Play();
            target.SendMessage("beEaten");
            isInvincible = true;
            invincibleTime = invincibleKeepTime;
            //generate the power ring
            powerRing = Instantiate(power_Ring);
        }

        //eat the speed up pacdot
        if (target.tag == "SpeedUp" && !target.GetComponent<Prop>().isHide)
        {   
            eatAcceleration.Play();
            target.SendMessage("beEaten");
            isSpeedUp = true;
            speedUpTime = speedUpKeepTime;
            movementSpeed = acceleratedSpeed;
        }

        //eat the shield
        if (target.tag == "Shield" && !target.GetComponent<Prop>().isHide)
        {   
            eatShield.Play();
            target.SendMessage("beEaten");
            equipShield = true;
            //generate the shield around pacman
            GameObject newShield = (GameObject)Instantiate(shieldPrefab);
            currentShield = newShield;
        }
    }

    /*collide with ghost*/
    void ghostCollision(GameObject target)
    {
        //invincible status
        if (isInvincible)
        {
            if (target.tag == "PatrolGhost"){
                
                Instantiate(PatrolDeathEffect, target.transform.position, target.transform.rotation); 
                Destroy(target);

                score += 10;
            
            }else if(target.tag == "ChasingGhost"){
                Instantiate(ChasingDeathEffect, target.transform.position, target.transform.rotation); 
                Destroy(target);
                score += 10;

            }else if(target.tag == "AssaultGhost"){
                Instantiate(AssDeathEffect, target.transform.position, target.transform.rotation); 
                Destroy(target);
                score += 10;    
            }
        }
        //with shield, defend ghost's attack
        else if (equipShield)
        {   
            if (target.tag == "PatrolGhost" || target.tag == "ChasingGhost" || target.tag == "AssaultGhost")
            {   
                Destroy(currentShield);
                eatShield.Play();
                equipShield = false;
            }
        }

        //not in invincible status
        else 
        {   
            if (target.tag == "PatrolGhost" || target.tag == "ChasingGhost" || target.tag == "AssaultGhost")
            {
                isDead = true;
            }
            /*
            //chasing
            if (target.tag == "ChasingGhost")
            {   
                isDead = true;
                //ChasingGhost ghostScript = (ChasingGhost)target.GetComponent(typeof(ChasingGhost));
                //ghostScript.attackPacman();
            }
            //patrol
            if (target.tag == "PatrolGhost")
            {   
                isDead = true;
                //GameObject.Find("PatrolGhost_A").GetComponent<PatrolGhostA>().attackPacman();
                //ghostScript.attackPacman();
            }
            */
        }
    }






    /*
    //pacdot attributes
    //pacdot is the object will be generated
    public GameObject pacdot;
    //the gap between generating
    private float generatingTime = 2.0f;
    private float times = 2.0f;
    //maximum number of pacdot
    private int maximumPacdot = 20;
    //current pacdot's number
    private int currentNumPacdot = 0;
    //generate new pacdot

    void PacdotGenerate()
    {
        times -= Time.deltaTime; 
        if (times < 0)
        {   
            if (currentNumPacdot < maximumPacdot)
            {
                //generate a new pacdot
                GameObject newPacdot = (GameObject)Instantiate(pacdot);

                //position the new pacdot in the map
                float ni = Random.Range(-32.5f, 32.5f);
                float nt = Random.Range(-32.5f, 32.5f);

                newPacdot.transform.position = new Vector3(ni, 2, nt);

                //increase number of current existing pacdot
                currentNumPacdot ++;
                //reset generating time
            }
            times = generatingTime;
        }
    }
    */

}

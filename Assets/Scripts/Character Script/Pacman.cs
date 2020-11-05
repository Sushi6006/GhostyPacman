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
    public bool isFPS = false;
    //classic controller
    public bool isClassic = false;
    private float coolDown = 0.25f;
    private float lastChange = 0f;
    public float turnspeed = 3.5f;
    //the direction of rotation
    Quaternion quaDir;

    /*gravity check*/
    private float gravity = 0;
    //standard gravity
    private float standardGravity = -10f;
    //gravity acceleration
    private float acceleration = -9.8f;


    /*UI part*/
    //player's score
    private int score = 0;
    public TextMeshProUGUI scoreText;
    //player's health
    public int health = 100;
    private bool isDead = false;
    public DeadMenuControl deadMenuControl;
    public MenuButton menuButton;


    // sfx
    public AudioSource eatSfx;


    /*prop*/
    //powerPacdot
    private bool isInvincible = false;
    private float invincibleTime = 0f;
    private float invincibleKeepTime = 5f;
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
        Cursor.visible = false;
        isClassic = true;
    }

    // Update is called once per frame
    void Update()
    {   
        if (!isDead){
            lastChange -= Time.deltaTime;

            Move();

            scoreText.text = "SCORE:" + score.ToString();

            //calculate invincible time
            if (isInvincible)
            {
                invincibleTime -= Time.deltaTime;
                if (invincibleTime <= 0)
                {
                    isInvincible = false;
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
            scoreText.enabled = false;
            Cursor.visible = true;
            deadMenuControl.toggleDeadMenu(score);
        }
    }

    // Move controller 
    void Move()
    {   
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
        
        //make pacman float
        moveDirec += Vector3.up * Mathf.Cos(Time.time * floatSpeed) * floatScale;

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
        if (target.tag == "pacdot")
        {   
            eatSfx.Play();
            Destroy(target);
            score ++;
        }

        //eat the power pacdot
        if (target.tag == "PowerPacdot")
        {
            Destroy(target);
            isInvincible = true;
            invincibleTime = invincibleKeepTime;
        }

        //eat the speed up pacdot
        if (target.tag == "SpeedUp")
        {
            Destroy(target);
            isSpeedUp = true;
            speedUpTime = speedUpKeepTime;
            movementSpeed = acceleratedSpeed;
        }

        //eat the shield
        if (target.tag == "Shield")
        {
            Destroy(target);
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
            if (target.tag == "Ghost")
            {
                Destroy(target);
                score += 10;
            }
        }
        //with shield, defend ghost's attack
        else if (equipShield)
        {   
            print(target.tag);
            if (target.tag == "Ghost")
            {   
                Destroy(currentShield);
                equipShield = false;
            }
        }

        //not in invincible status
        else 
        {   
            if (target.tag == "Ghost")
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

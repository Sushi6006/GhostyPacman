using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultGhost : MonoBehaviour
{
     //target is the pacman
    public GameObject target;

    //patrol position
    Vector3 pointA = new Vector3(4f, 6f, 25f);
    Vector3 pointB = new Vector3(43f, 6f, 0f);
    Vector3 pointC = new Vector3(5f, 6f, -20f);
    Vector3 currentPoint;

    //chase pacman
    public float chaseRadius = 8f;
    private float diatanceToPlayer;
    private bool isChasing = false;

    //check whether the ghost exist somewhere
    Collider box;

    //attack
    private Pacman pacmanScript;
    //cooldown
    private float times = 0f;
    private float attackCooldown = 2;
    public int damage = 50;

    //agent helps the pathfinding
    private UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {   
        //get the pacman
        pacmanScript = (Pacman)target.GetComponent(typeof(Pacman));
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        box = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {   
        chaseCheck();
        times -= Time.deltaTime;
        if (isChasing)
        {   
            chasePacman();
        }
        else
        {
            patrol();
        }
    }

    public void attackPacman()
    {
        if (times <= 0)
        {   
            pacmanScript.health -= damage;
            times = attackCooldown;
        }
    }

    private void patrol()
    {   
        if (box.bounds.Contains(pointA) && Vector3.Distance(agent.destination, pointB) > 10)
        {   
            currentPoint = pointB;
            agent.destination = pointB;
        }
        else if (box.bounds.Contains(pointB) && Vector3.Distance(agent.destination, pointC) > 10)
        {   
            currentPoint = pointC;
            agent.destination = pointC;
        }
        else if (box.bounds.Contains(pointC) && Vector3.Distance(agent.destination, pointA) > 10)
        {   
            currentPoint = pointA;
            agent.destination = pointA;
        }
    }

    /*chase the pacman*/
    private void chasePacman()
    {  
        agent.destination = target.transform.position;
    }

    /*check wether the pacman in the attacking radius*/
    private void chaseCheck()
    {   
        if (Vector3.Distance(agent.transform.position, target.transform.position) < chaseRadius)
        {   
            isChasing = true;
        }
        else
        {   
            isChasing = false;
            agent.destination = currentPoint;
        }
    }
}

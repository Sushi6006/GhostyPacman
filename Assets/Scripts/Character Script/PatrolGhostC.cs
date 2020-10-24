using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolGhostC : MonoBehaviour
{
    //target is the pacman
    public GameObject target;

    //patrol position
    Vector3 pointA = new Vector3(18f, 2f, -18f);
    Vector3 pointB = new Vector3(-18f, 2f, -18f);
    Vector3 pointC = new Vector3(-18f, 2f, 18f);
    Vector3 pointD = new Vector3(18f, 2f, 18f);

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
        times -= Time.deltaTime;
        patrol();
    }

    /*
    public void attackPacman()
    {
        if (times <= 0)
        {   
            pacmanScript.health -= damage;
            times = attackCooldown;
        }
    }
    */

    private void patrol()
    {   
        if (box.bounds.Contains(pointA) && Vector3.Distance(agent.destination, pointB) > 10)
        {   
            agent.destination = pointB;
        }
        else if (box.bounds.Contains(pointB) && Vector3.Distance(agent.destination, pointC) > 10)
        {   
            agent.destination = pointC;
        }
        else if (box.bounds.Contains(pointC) && Vector3.Distance(agent.destination, pointD) > 10)
        {   
            agent.destination = pointD;
        }
        else if (box.bounds.Contains(pointD) && Vector3.Distance(agent.destination, pointA) > 10)
        {   
            agent.destination = pointA;
        }
    }
}

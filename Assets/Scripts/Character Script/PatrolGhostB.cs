using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolGhostB : MonoBehaviour
{
    //target is the pacman
    public GameObject target;

    //patrol position
    Vector3 pointA = new Vector3(44.3f, 6f, 24.3f);
    Vector3 pointB = new Vector3(23.8f, 6f, 5.1f);
    Vector3 pointC = new Vector3(3f, 6f, 25f);

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

    //float
    private float floatSpeed = 3f;
    //floating scale
    private float floatScale = 0.2f;

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

        //float
        transform.position += Vector3.up * Mathf.Cos(Time.time * floatSpeed) * floatScale;
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
        else if (box.bounds.Contains(pointC) && Vector3.Distance(agent.destination, pointA) > 10)
        {   
            agent.destination = pointA;
        }
    }
}

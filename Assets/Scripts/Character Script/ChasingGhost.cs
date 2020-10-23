using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingGhost : MonoBehaviour
{   
    //target is the pacman
    public GameObject target;
    private Pacman pacmanScript;

    //agent helps the pathfinding
    private NavMeshAgent agent;
    
    //attack part
    private float times = 0f;
    //cooldown
    private float attackCooldown = 2;
    public int damage = 25;
   
    void Start()
    {   
        pacmanScript = (Pacman)target.GetComponent(typeof(Pacman));
        agent = GetComponent<NavMeshAgent>();
    }
 
  
    void Update()
    {   
        times -= Time.deltaTime; 
        agent.destination = target.transform.position;
    }

    public void attackPacman()
    {
        if (times <= 0)
        {   
            pacmanScript.health -= damage;
            times = attackCooldown;
        }
    }
}

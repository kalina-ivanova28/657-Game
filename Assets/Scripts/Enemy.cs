using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent Mob;
    public GameObject Player;
    public float mobDistanceRun = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        Mob = GetComponent<NavMeshAgent>(); 
    
    }

    // Update is called once per frame
    void Update()
    {
        //distance is the mob and distance of player
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        //run toawrds player if distance is less than mobDistanceRun
        if (distance < mobDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position - dirToPlayer;

            Mob.SetDestination(newPos);
        }
        
    }
}

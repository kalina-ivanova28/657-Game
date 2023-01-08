using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using TMPro;

public class openDoor : MonoBehaviour
{
    public Transform[] waypointArray;

    NavMeshAgent agent1;

    Vector3 target;

    void Update(){
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            Open();   
        }
    }
    void Open(){
        target = waypointArray[0].position; //set our target to our current waypoint

        agent1.SetDestination(target); 
    }
}

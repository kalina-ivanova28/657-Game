using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using TMPro;


public class MovementAI : MonoBehaviour
{

    NavMeshAgent agent;

    public Transform[] waypoints;   //array of waypoints

    public int waypointIndex;  //index for choosing the waypoints
    Vector3 target;
    //Creating the game objects
    public GameObject click;
    public GameObject instructions;

    //Creating the string values
    public string click_value;
    public string instructions_value;
    public string empty;

    //Text Components
    TextMeshProUGUI textMeshPro_click;
    TextMeshProUGUI textMeshPro_instructions;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro_click = click.GetComponent<TextMeshProUGUI>();
        textMeshPro_instructions = instructions.GetComponent<TextMeshProUGUI>();
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination(); 
    }

    // Update is called once per frame
    void Update()
    {
        //agent.speed = 750 * Time.deltaTime;
        //agent.acceleration = 750 * Time.deltaTime;

        if(Vector3.Distance(transform.position, target) < 1) //if our distance to the target is less than 1 meter,
        {
            
            if (waypointIndex < 2)        //if waypoint index is 0 or 1
            {
                IterateWaypointIndex();         //we are going to increase the waypoint index by 1
                UpdateDestination();            //updates the destination waypoint
                
            }
            else if(waypointIndex == 2){                                              //Entrance choice
                if(Input.GetKeyDown(KeyCode.Space)){    //NEEDS GUI INSTRUCTIONS
                    waypointIndex = 3;
                    IterateWaypointIndex();         //+1 to waypoint index
                    UpdateDestination();
                }
            }
            else if(waypointIndex == 5)                                               //First Choice after entering
            {
                    textMeshPro_click.text = click_value;
                    textMeshPro_instructions.text = instructions_value;
                    if (Input.GetKeyDown(KeyCode.Alpha1))              //CHOICE 1 - going to the left -> waypointIndex = 7
                    {
                        textMeshPro_click.text = empty;
                        textMeshPro_instructions.text = empty;
                        waypointIndex = 6;
                        IterateWaypointIndex();
                        UpdateDestination();
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha2))         //CHOICE 2 - going to the right -> waypointIndex = 17
                    {
                        textMeshPro_click.text = empty;
                        textMeshPro_instructions.text = empty;
                        waypointIndex = 16;
                        IterateWaypointIndex();
                        UpdateDestination();
                    }
            }
            else if(waypointIndex == 7)                                               //waypoint 6
            {
                
                    textMeshPro_click.text = click_value;
                    textMeshPro_instructions.text = instructions_value;
                    if (Input.GetKeyDown(KeyCode.Alpha1))              //CHOICE 1 - going straight-> waypointIndex = 9    
                    {
                        textMeshPro_click.text = empty;
                        textMeshPro_instructions.text = empty;
                        waypointIndex = 8;
                        IterateWaypointIndex();
                        UpdateDestination();
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha2))         //CHOICE 2 - going to the right -> waypointIndex = 12
                    {
                        textMeshPro_click.text = empty;
                        textMeshPro_instructions.text = empty;
                        waypointIndex = 11;
                        IterateWaypointIndex();
                        UpdateDestination();
                    }
            }
            else if(waypointIndex == 12)                                               //
            {
                 textMeshPro_click.text = click_value;
                    textMeshPro_instructions.text = instructions_value;
                    if (Input.GetKeyDown(KeyCode.Alpha1))
                    {
                        textMeshPro_click.text = empty;
                        textMeshPro_instructions.text = empty;
                        waypointIndex = 13;
                        IterateWaypointIndex();
                        UpdateDestination();
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha2))
                    {
                        textMeshPro_click.text = empty;
                        textMeshPro_instructions.text = empty;
                        waypointIndex = 15;
                        IterateWaypointIndex();
                        UpdateDestination();
                    }
            }
            else if(waypointIndex == 17)     
            {
                Debug.Log("Juts a function to prevent OutOFBoundsIndex Error");
            }
            else{                       //mainly for reversing back to a specific waypoint
                IterateWaypointIndex();
                UpdateDestination();
            }
        }
    }


    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position; //set our target to our current waypoint

        //target = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].position, Time.deltaTime * 10); //set our target to our current waypoint

        agent.SetDestination(target);               //set the nav mesh agent's destination to target
    }

    void IterateWaypointIndex()
    {
        waypointIndex++;
      
    }
}




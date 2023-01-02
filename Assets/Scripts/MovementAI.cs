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
    public GameObject Outcome;

    //Creating the string values
    public string click_value;
    public string instructions_value;
    public string empty;
    public string wrong;
    public string correct;

    //Text Components
    TextMeshProUGUI textMeshPro_click;
    TextMeshProUGUI textMeshPro_instructions;
    TextMeshProUGUI textMeshPro_outcome;

    //Random numbers for Puzzle 1
    bool flag=false;
    float number;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro_click = click.GetComponent<TextMeshProUGUI>();
        textMeshPro_instructions = instructions.GetComponent<TextMeshProUGUI>();
        textMeshPro_outcome= Outcome.GetComponent<TextMeshProUGUI>();
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
            else if(waypointIndex == 4)                                               //First Choice after entering
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
                        //IterateWaypointIndex();
                        UpdateDestination();
                    }
            }
            // else if(waypointIndex == 16){
            //     number= Random.Range(0,9);
            //     while(flag==false){
            //         if(Input.GetKeyDown(KeyCode.Alpha0) && number == 0){
            //             flag=true;
            //         }
            //         else if(Input.GetKeyDown(KeyCode.Alpha1) && number == 1){
            //             flag=true;
            //         }
            //         else if(Input.GetKeyDown(KeyCode.Alpha2) && number == 2){
            //             flag=true;
            //         }
            //         else if(Input.GetKeyDown(KeyCode.Alpha3) && number == 3){
            //             flag=true;
            //         }
            //         else if(Input.GetKeyDown(KeyCode.Alpha4) && number == 4){
            //             flag=true;
            //         }
            //         else if(Input.GetKeyDown(KeyCode.Alpha5) && number == 5){
            //             flag=true;
            //         }
            //         else if(Input.GetKeyDown(KeyCode.Alpha6) && number == 6){
            //             flag=true;
            //         }
            //         else if(Input.GetKeyDown(KeyCode.Alpha7) && number == 7){
            //             flag=true;
            //         }
            //         else if(Input.GetKeyDown(KeyCode.Alpha8) && number == 8){
            //             flag=true;
            //         }
            //         else if(Input.GetKeyDown(KeyCode.Alpha9) && number == 9){
            //             flag=true;
            //         }
            //         else{
            //             textMeshPro_outcome.text=wrong;
            //         }
            //     }
            //     textMeshPro_outcome.text=correct;
            //     IterateWaypointIndex();
            //     UpdateDestination();
            // }
            else if(waypointIndex == 7)                                               //waypoint 6
            {
                
                    textMeshPro_click.text = click_value;
                    textMeshPro_instructions.text = instructions_value;
                    if (Input.GetKeyDown(KeyCode.Alpha1))              //CHOICE 1 - going straight-> waypointIndex = 9    LOSE
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
                        waypointIndex = 10;
                        IterateWaypointIndex();        //This sometimes skips some waypoints...not ndeed in every if statement
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
            // else if(waypointIndex == 15)     
            // {
            //     Debug.Log("Just a function to prevent OutOFBoundsIndex Error...TBC...");
            // }
            // else if(waypointIndex == 17)     
            // {
            //     Debug.Log("Just a function to prevent OutOFBoundsIndex Error...TBC...");
            // }
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




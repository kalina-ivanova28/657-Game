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
    public GameObject WeaponMenuChoice1, WeaponMenuChoice2, ConfirmWeapon;
    public GameObject MovingWall;

    //Creating the string values
    public string click_value;
    public string instructions_value;
    public string empty;
    public string wrong;
    public string correct;
    public float position;

    //Weapon Display GUI
    public string weapon_1, weapon_2, confirm;

    //Text Components
    TextMeshProUGUI textMeshPro_click;
    TextMeshProUGUI textMeshPro_instructions;
    TextMeshProUGUI textMeshPro_outcome;
    TextMeshProUGUI textMeshPro_Weapon_1;
    TextMeshProUGUI textMeshPro_Weapon_2;
    TextMeshProUGUI confirmWeapon;

    //Random numbers for Puzzle 1
    public bool flag = false;
    float number;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro_click = click.GetComponent<TextMeshProUGUI>();
        textMeshPro_instructions = instructions.GetComponent<TextMeshProUGUI>();
        textMeshPro_outcome = Outcome.GetComponent<TextMeshProUGUI>();
        agent = GetComponent<NavMeshAgent>();
        number = Random.Range(0,9);
        

        //Weapon GUI
        textMeshPro_Weapon_1 = WeaponMenuChoice1.GetComponent<TextMeshProUGUI>();
        textMeshPro_Weapon_2 = WeaponMenuChoice2.GetComponent<TextMeshProUGUI>();
        confirmWeapon = ConfirmWeapon.GetComponent<TextMeshProUGUI>();
        UpdateDestination(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target) < 1) //if our distance to the target is less than 1 meter,
        {
            
            if (waypointIndex < 2)        //if waypoint index is 0 or 1
            {
                IterateWaypointIndex();         //we are going to increase the waypoint index by 1
                UpdateDestination();            //updates the destination waypoint
                agent.speed = 7;
            }
            else if(waypointIndex == 2){                                              //Entrance choice
                textMeshPro_Weapon_1.text = weapon_1;
                textMeshPro_Weapon_2.text = weapon_2;
                confirmWeapon.text = confirm;
                if(Input.GetKeyDown(KeyCode.Space)){    //After selecting a weapon or none and heading into the building
                    waypointIndex = 3;
                    textMeshPro_Weapon_1.text = empty;
                    textMeshPro_Weapon_2.text = empty;
                    confirmWeapon.text = empty;
                    IterateWaypointIndex();         
                    UpdateDestination();
                    agent.speed = 10;
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
                        agent.speed = 12;
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha2))         //CHOICE 2 - going to the right -> waypointIndex = 17
                    {
                        textMeshPro_click.text = empty;
                        textMeshPro_instructions.text = empty;
                        waypointIndex = 15;
                        //IterateWaypointIndex();
                        UpdateDestination();
                        agent.speed = 12;
                    }
            }
            else if(waypointIndex == 7)                                               //waypoint 6
            {
                
                    textMeshPro_click.text = click_value;
                    textMeshPro_instructions.text = instructions_value;
                    if (Input.GetKeyDown(KeyCode.Alpha1))              //CHOICE 1 - going straight-> waypointIndex = 9    LOSE
                    {
                        textMeshPro_click.text = empty;
                        textMeshPro_instructions.text = empty;
                        waypointIndex = 8;
                        //IterateWaypointIndex();
                        UpdateDestination();
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha2))         //CHOICE 2 - going to the right -> waypointIndex = 12
                    {
                        textMeshPro_click.text = empty;
                        textMeshPro_instructions.text = empty;
                        waypointIndex = 10;
                        IterateWaypointIndex();        //This sometimes skips some waypoints...not needed in every if statement
                        UpdateDestination();
                    }
            }
            else if(waypointIndex == 12)                                               
            {
                textMeshPro_click.text = click_value;
                textMeshPro_instructions.text = instructions_value;
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    textMeshPro_click.text = empty;
                    textMeshPro_instructions.text = empty;
                    waypointIndex = 13;
                    //IterateWaypointIndex();
                    UpdateDestination();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    textMeshPro_click.text = empty;
                    textMeshPro_instructions.text = empty;
                    waypointIndex = 16;
                    //IterateWaypointIndex();
                    UpdateDestination();
                }
            }
            else if (waypointIndex == 22){
                textMeshPro_click.text = click_value;
                textMeshPro_instructions.text = instructions_value;
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    textMeshPro_click.text = empty;
                    textMeshPro_instructions.text = empty;
                    waypointIndex=23;
                    // IterateWaypointIndex();
                    UpdateDestination();
                    //Debug.Log("Got here I think");
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    textMeshPro_click.text = empty;
                    textMeshPro_instructions.text = empty;
                    waypointIndex = 24;
                    //IterateWaypointIndex();
                    UpdateDestination();
                    //Debug.Log("The problem is here");
                }
            }
            else if(waypointIndex == 26){
                //Debug.Log("Here");
                textMeshPro_click.text = click_value;
                textMeshPro_instructions.text = instructions_value;
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    textMeshPro_click.text = empty;
                    textMeshPro_instructions.text = empty;
                    waypointIndex = 27;
                    // IterateWaypointIndex();
                    UpdateDestination();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    textMeshPro_click.text = empty;
                    textMeshPro_instructions.text = empty;
                    waypointIndex = 28;
                    //IterateWaypointIndex(); //need to comment this out otherwise it will skip the puzzlegame
                    UpdateDestination();
                }
            }
            else if (waypointIndex == 27){
                waypointIndex = 21;
                UpdateDestination();
            }
            else if(waypointIndex == 28){
                Debug.Log("Waypoint 28 reached");
                GuessingGame();
            }
            else if(waypointIndex == 30){
                Debug.Log("End of waypoints reached");
            }
            else{                       //if there is no input required... it will follow any remaining waypoints 
                Debug.Log("Else statement initiated");
                IterateWaypointIndex();
                UpdateDestination();
            }
        }
        //else {Debug.Log("Waypoint not in reaching distance...");}
    }


    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position; //set our target to our current waypoint

        agent.SetDestination(target);               //set the nav mesh agent's destination to target
    }

    void IterateWaypointIndex()
    {
        waypointIndex++;
      
    }
    void GuessingGame()
    {
        //number = Random.Range(0,9);
        Debug.Log("Number generated: " + number);
        textMeshPro_instructions.text = "Choose a number between 0 - 9";
        if (flag == false)
            {
                if(Input.GetKeyDown(KeyCode.Alpha0) && number == 0){
                    flag=true;
                    textMeshPro_instructions.text = empty;
                    Debug.Log("Correct!");
                    MoveWall();
                    IterateWaypointIndex();
                    UpdateDestination();
                }
                else if(Input.GetKeyDown(KeyCode.Alpha1) && number == 1){
                    flag=true;
                    textMeshPro_instructions.text = empty;
                    Debug.Log("Correct!");
                    MoveWall();
                    IterateWaypointIndex();
                    UpdateDestination();
                }
                else if(Input.GetKeyDown(KeyCode.Alpha2) && number == 2){
                    flag=true;
                    textMeshPro_instructions.text = empty;
                    Debug.Log("Correct!");
                    MoveWall();
                    IterateWaypointIndex();
                    UpdateDestination();
                }
                else if(Input.GetKeyDown(KeyCode.Alpha3) && number == 3){
                    flag=true;
                    textMeshPro_instructions.text = empty;
                    Debug.Log("Correct!");
                    MoveWall();
                    IterateWaypointIndex();
                    UpdateDestination();
                }
                else if(Input.GetKeyDown(KeyCode.Alpha4) && number == 4){
                    flag=true;
                    textMeshPro_instructions.text = empty;
                    Debug.Log("Correct!");
                    MoveWall();
                    IterateWaypointIndex();
                    UpdateDestination();
                }
                else if(Input.GetKeyDown(KeyCode.Alpha5) && number == 5){
                    flag=true;
                    textMeshPro_instructions.text = empty;
                    Debug.Log("Correct!");
                    MoveWall();
                    IterateWaypointIndex();
                    UpdateDestination();
                }
                else if(Input.GetKeyDown(KeyCode.Alpha6) && number == 6){
                    flag=true;
                    textMeshPro_instructions.text = empty;
                    Debug.Log("Correct!");
                    MoveWall();
                    IterateWaypointIndex();
                    UpdateDestination();
                }
                else if(Input.GetKeyDown(KeyCode.Alpha7) && number == 7){
                    flag=true;
                    textMeshPro_instructions.text = empty;
                    Debug.Log("Correct!");
                    MoveWall();
                    IterateWaypointIndex();
                    UpdateDestination();
                }
                else if(Input.GetKeyDown(KeyCode.Alpha8) && number == 8){
                    flag=true;
                    textMeshPro_instructions.text = empty;
                    Debug.Log("Correct!");
                    MoveWall();
                    IterateWaypointIndex();
                    UpdateDestination();
                }
                else if(Input.GetKeyDown(KeyCode.Alpha9) && number == 9){
                    flag=true;
                    textMeshPro_instructions.text = empty;
                    Debug.Log("Correct!");
                    MoveWall();
                    IterateWaypointIndex();
                    UpdateDestination();
                }
            }
    }

    void MoveWall()
    {
        Vector3 x = new Vector3();
        Vector3 y = new Vector3();
        x.z = 8;
        y.z = 13;
        MovingWall.transform.position = Vector3.Lerp(x, y, 5);
    }
}




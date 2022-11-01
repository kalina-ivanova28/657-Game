using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayNightSystem : MonoBehaviour
{
    /*Properties publicly to modify*/
    public float dayLengthMinutes;
    public float currentTime;
    public TextMeshProUGUI timeText;


    public float showTestTime;


    /*Private variables not visiblw*/
    private float rotationSpeed;
    private float midday;
    private float translateTime;
    string AMPM = "AM";


    // Start is called before the first frame update
    void Start()   /*Runs as soon as the game starts*/
    {
        rotationSpeed = 360 / dayLengthMinutes / 60;     /*Gives us 12 in this example*/
        midday = dayLengthMinutes * 60 / 2;            /*(midday value) seconds to complete a 12-hour in-game cycle - (15)*/
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;     /*Time.deltaTime = time interval between last and current frame -> Increments*/

        translateTime = (currentTime / (midday * 2));

        float t = translateTime * 24f;      /*f = floor -> returns integer <= f*/
        float hours = Mathf.Floor(t);

        showTestTime = hours; /*Test public value*/

        /*Displaying UI text on screen*/

        string displayHours = hours.ToString();
        if (hours == 0) {
            displayHours = "12";
        }
        else if (hours > 12){
            displayHours = (hours - 12).ToString();
        }



        if (currentTime >= midday) {
            if (AMPM != "PM"){
                AMPM = "PM";
            }
        }
        if (currentTime >= midday * 2){
            if (AMPM != "AM") {
                AMPM = "AM";
            }
            currentTime = 0;
        }

        t *= 60;
        float minutes = Mathf.Floor(t % 60);

        string displayMinutes = minutes.ToString();
        if (minutes < 10) {
            displayMinutes = "0" + minutes.ToString();
        }

        string displayTime = displayHours + ":" + displayMinutes + " " +  AMPM;
        timeText.text = displayTime;



        transform.Rotate(new Vector3(1, 0, 0) * rotationSpeed * Time.deltaTime);
    }
}

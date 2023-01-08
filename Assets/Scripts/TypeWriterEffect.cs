using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour
{


    public float delay = 0.1f; //speed at which it will show new character

    //what will be shown when text has been completely displayed

    private readonly string fullText = "A new Internet trend has become a hit sensation with indie livestreamers all over the world.\n\n " +
        ".........\n\nChatmaster has returned after being cancelled by the netizens.\n\n" +
        "He has decided to challenge the infamous abandoned asylum in his home town in hopes to reclaim his fame.\n\n" +
        "........\n\n and only the Chat can tell him what to do.\n\n........\n\n" +
        "This might be his only shot at redemption.";

    private string currentText = "";


    // Start is called before the first frame update
    void Start()
    {
       
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()  //makes a loop to wait sometime before showing next character
    {


       

        for (int i = 0; i < fullText.Length+1; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            //var text = GetComponent<Text>();
            //if (text == null)
            //{
            //    Debug.LogWarning("expected text was null!");

            //}
            yield return new WaitForSeconds(delay);
        }

     
    }
}
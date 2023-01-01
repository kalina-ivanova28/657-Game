using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour
{


    public float delay = 0.1f; //speed at which it will show new character

    //what will be shown when text has been completely displayed

    private readonly string fullText = "A new Internet trend has become a hit sensation with small live streamers.\n " +
        "........., a controversial Twitch live streamer, is trying to make a comback after being cancelled.\n" +
        "He has decided to take part in the What Do I Do?! challenge at an infamous abandoned asylum in his home town.\n" +
        "........ will have to ask his stream's chat on what he should do at the asylum and go through with whatever the chat agrees on.\n\n" +
        "This might be be only shot at redemption....";

    private string currentText = "";


    // Start is called before the first frame update
    void Start()
    {
       
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()  //makes a loop to wait sometime before showing next character
    {
        for(int i = 0; i < fullText.Length+1; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
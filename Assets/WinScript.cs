using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{

    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < 1)
        {
            Debug.Log("Win!");
            //Transition to Lose screen
            SceneManager.LoadScene("WinScene");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectPlayer : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < 1)
        {
            Debug.Log("Dead!");
            //Transition to Lose screen
            SceneManager.LoadScene("GameOverScene");
        }
    }
}

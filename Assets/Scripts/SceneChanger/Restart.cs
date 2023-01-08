using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void Update(){
        if (Input.GetKeyDown(KeyCode.S)){
            SceneManager.LoadScene("MainGame");
        }
    }
}
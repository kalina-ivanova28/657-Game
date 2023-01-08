using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeViaTriggerLOSE : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");
        SceneManager.LoadScene("GameOverScene");
    }
}

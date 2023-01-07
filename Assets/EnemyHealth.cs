using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public GameObject healthBarUI;
    public Slider slider;

    public Target currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        health = currentHealth.health;
        slider.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateHealth();

        if (health <= 0){
            Debug.Log("Destroyed");
        }
    }

    float CalculateHealth()
    {
        return currentHealth.health / maxHealth ;
    }
}

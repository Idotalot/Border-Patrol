using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    // Start is called before the first frame update

    // Game settings defineren
    public GameObject generalScripts;
    private GameInitializationSettings gameInitializationSettings;

    void Start()
    {
        currentHealth = maxHealth;
        gameInitializationSettings = generalScripts.GetComponent<GameInitializationSettings>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce health by the amount of damage taken
        Debug.Log("Current border health = " + currentHealth.ToString());

        if (currentHealth <= 0)
        {
            Die(); // If health drops to or below zero, destroy the enemy
        }
    }

    private void Die()
    {
        gameInitializationSettings.roundInProgress = false;
        gameInitializationSettings.playerDied = true;
    }
}

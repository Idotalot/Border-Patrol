/*
 * Jordy Perret - IO3S1AV
 * Border Patrol Alienist
 * 14-11-2023
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BorderController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    // Start is called before the first frame update

    // Game settings defineren
    public GameObject generalScripts;
    private GameInitializationSettings gameInitializationSettings;
    public TextMeshProUGUI borderHealthText;

    void Start()
    {
        currentHealth = maxHealth;
        gameInitializationSettings = generalScripts.GetComponent<GameInitializationSettings>();
        borderHealthText.text = currentHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce health by the amount of damage taken
        Debug.Log("Current border health = " + currentHealth.ToString());
        borderHealthText.text = currentHealth.ToString();

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

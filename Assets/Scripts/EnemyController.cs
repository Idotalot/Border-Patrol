using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 3; // Maximum health of the enemy
    private int currentHealth; // Current health of the enemy
    public float speed = 2f;
    public GameObject scoreCountObject;
    public GameObject ammoCountObject;

    void Start()
    {
        currentHealth = maxHealth; // Set initial health
    }

    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime); // Beweging van de kogel
    }

    public void AssignGameObjects(GameObject scoreObject, GameObject ammoObject) // Scripts toevoegen aan de enemy nadat ze ingespawned zijn.
    {
        scoreCountObject = scoreObject;
        ammoCountObject = ammoObject;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce health by the amount of damage taken

        if (currentHealth <= 0)
        {
            if (gameObject.name != "gigaMarcel(Clone)")
            {
                ScoreCount scoreCount = scoreCountObject.GetComponent<ScoreCount>();
                scoreCount.AddScore();

                AmmoCountController ammoCountController = ammoCountObject.GetComponent<AmmoCountController>();
                ammoCountController.AddAmmo(5);
            }
            Die(); // If health drops to or below zero, destroy the enemy
        }
    }

    void Die()
    {
        // Perform any death-related actions here (e.g., play death animation, drop items, etc.)
        Destroy(gameObject); // Destroy the enemy object
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        BorderController border = other.GetComponent<BorderController>(); // Assuming the enemy script is called EnemyController


        if (border != null)
        {
            border.TakeDamage(currentHealth); // Call a function on the enemy script to apply damage
            Destroy(gameObject); // Destroy the bullet upon collision with an enemy
        }
    }
}
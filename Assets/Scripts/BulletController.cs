using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); // Move the bullet in the desired direction
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyController enemy = other.GetComponent<EnemyController>(); // Assuming the enemy script is called EnemyController

        if (enemy != null)
        {
            enemy.TakeDamage(damage); // Call a function on the enemy script to apply damage
            Destroy(gameObject); // Destroy the bullet upon collision with an enemy
        }

        if (other.tag == "BulletDeleter")
        {
            Destroy(gameObject);
        }
    }
}
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public GameObject gigaMarcelToSpawn;
    public float spawnRate = 2f;
    public Vector2 spawnArea;
    public GameObject scoreCounterGameObject;
    public GameObject AmmoCounterGameObject;
    public GameObject parentObject;

    // Game settings defineren
    public GameObject generalScripts;
    private GameInitializationSettings gameInitializationSettings;

    void Start()
    {
        // Start spawning objects at the specified rate
        gameInitializationSettings = generalScripts.GetComponent<GameInitializationSettings>();
        InvokeRepeating("SpawnObject", 0f, spawnRate);
    }

    void SpawnObject()
    {
        if (gameInitializationSettings != null)
        {
            if (gameInitializationSettings.roundInProgress == true)
            {
                // Spawn ruimte defineren
                Vector2 randomSpawnPoint = new Vector2
                (
                    Random.Range(transform.position.x - spawnArea.x / 2, transform.position.x + spawnArea.x / 2),
                    Random.Range(transform.position.y - spawnArea.y / 2, transform.position.y + spawnArea.y / 2)
                );

                // scoreCount defineren
                ScoreCount scoreCount = scoreCounterGameObject.GetComponent<ScoreCount>();

                // Check of scoreCount object opgehaald wordt
                if (scoreCount != null)
                {

                    Debug.Log("Spawner: Score = " + scoreCount.score.ToString());

                    // Check of score lager is dan 
                    if (scoreCount.score >= 60)
                    {
                        // Spawn final boss
                        Instantiate(gigaMarcelToSpawn, randomSpawnPoint, Quaternion.identity);
                        Spawner spawner = parentObject.GetComponent<Spawner>();
                        Destroy(spawner);
                    }
                    else
                    {
                        // Spawn normale enemies
                        Instantiate(prefabToSpawn, randomSpawnPoint, Quaternion.identity);

                        // EnemyController defineren vanuit gespawnde enemy
                        EnemyController enemyController = prefabToSpawn.GetComponent<EnemyController>();

                        // Checken of EnemyController bestaat
                        if (enemyController != null)
                        {
                            // Scripts toevoegen aan enemy zodat de scores en ammo bijgehouden wordt.
                            enemyController.AssignGameObjects(scoreCounterGameObject, AmmoCounterGameObject);
                        }
                    }
                }
            }
        }        
    }
}
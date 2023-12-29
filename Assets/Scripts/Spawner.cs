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

    void Update()
    {

    }

    void SpawnObject()
    {
        if (gameInitializationSettings != null)
        {
            if (gameInitializationSettings.roundInProgress == true && gameInitializationSettings.finalBoss == false)
            {
                // Spawn ruimte defineren
                Vector2 randomSpawnPoint = new Vector2
                (
                    Random.Range(transform.position.x - spawnArea.x / 2, transform.position.x + spawnArea.x / 2),
                    Random.Range(transform.position.y - spawnArea.y / 2, transform.position.y + spawnArea.y / 2)
                );

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

    public void SpawnBoss()
    {
        if (gameInitializationSettings != null)
        {
            if (gameInitializationSettings.roundInProgress == true && gameInitializationSettings.finalBoss == true && GameObject.Find("gigaMarcel(Clone)") == null)
            {
                // Spawn ruimte defineren
                Vector2 randomSpawnPoint = new Vector2
                (
                    Random.Range(transform.position.x - spawnArea.x / 2, transform.position.x + spawnArea.x / 2),
                    Random.Range(transform.position.y - spawnArea.y / 2, transform.position.y + spawnArea.y / 2)
                );

                // Spawn final boss
                Instantiate(gigaMarcelToSpawn, randomSpawnPoint, Quaternion.identity);
                Spawner spawner = parentObject.GetComponent<Spawner>();
                Debug.Log(GameObject.Find("gigaMarcel"));
            }
        }
    }
}
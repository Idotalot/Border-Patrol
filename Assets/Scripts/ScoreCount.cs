/*
 * Jordy Perret - IO3S1AV
 * Border Patrol Alienist
 * 14-11-2023
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    // Script properties defineren
    public TextMeshProUGUI scoreText;
    public int score = 0;

    // Spawn script defineren
    public GameObject enemySpawnArea;
    private Spawner spawnerScript;

    // Game settings defineren
    public GameObject generalScripts;
    private GameInitializationSettings gameInitializationSettings;

    // Start is called before the first frame update
    void Start()
    {
        // Defineren van game objecten
        spawnerScript = enemySpawnArea.GetComponent<Spawner>();
        gameInitializationSettings = generalScripts.GetComponent<GameInitializationSettings>();
        scoreText = GameObject.Find("Canvas/scoreCount").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        score += 3;
        scoreText.text = score.ToString();
        if (score >= 60)
        {
            gameInitializationSettings.finalBoss = true;
            if (gameInitializationSettings.finalBoss == true)
            {
                spawnerScript.SpawnBoss();
            }
        }
    }
}

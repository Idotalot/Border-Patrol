/*
 * Jordy Perret - IO3S1AV
 * Border Patrol Alienist
 * 14-11-2023
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStartScript : MonoBehaviour
{
    // Script properties defineren
    public GameObject generalScripts;
    public GameObject scoreCountObject;
    public TextMeshProUGUI scoreText;
    public GameObject ammoCountObject;
    public TextMeshProUGUI ammoText;
    public GameObject border;
    public TextMeshProUGUI borderText;

    // Game scripts defineren
    private GameInitializationSettings gameInitializationSettings;
    private ScoreCount scoreCount;
    private AmmoCountController ammoCountController;
    private BorderController borderController;


    // Start is called before the first frame update
    void Start()
    {
        gameInitializationSettings = generalScripts.GetComponent<GameInitializationSettings>();

        scoreCount = scoreCountObject.GetComponent<ScoreCount>();
        ammoCountController = ammoCountObject.GetComponent<AmmoCountController>();
        borderController = border.GetComponent<BorderController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        // Game settings aanpassen als de game start
        gameInitializationSettings.playerDied = false;
        gameInitializationSettings.roundInProgress = true;
        gameInitializationSettings.finalBoss = false;
        gameInitializationSettings.startScreen = true;

        // Game waardes aanpassen
        scoreCount.score = 0;
        scoreText.text = scoreCount.score.ToString();
        ammoCountController.ammo = 30;
        ammoText.text = ammoCountController.ammo.ToString();
        borderController.currentHealth = 100;
        borderText.text = borderController.currentHealth.ToString();
    }    
}

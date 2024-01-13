using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartScript : MonoBehaviour
{
    // Game objects defineren
    public GameObject generalScripts;
    public GameObject scoreCountObject;
    public GameObject ammoCountObject;
    public GameObject border;

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
        gameInitializationSettings.playerDied = false;
        gameInitializationSettings.roundInProgress = true;
        gameInitializationSettings.finalBoss = false;

        scoreCount.score = 0;
        ammoCountController.ammo = 0;
        borderController.currentHealth = 0;
    }    
}

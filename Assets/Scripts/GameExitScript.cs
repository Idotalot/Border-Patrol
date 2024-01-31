/*
 * Jordy Perret - IO3S1AV
 * Border Patrol Alienist
 * 14-11-2023
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameExitScript : MonoBehaviour
{
    // Game objects defineren
    public GameObject generalScripts;

    // Game settings defineren
    private GameInitializationSettings gameInitializationSettings;
    // Start is called before the first frame update
    void Start()
    {
        gameInitializationSettings = generalScripts.GetComponent<GameInitializationSettings>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 'QuitGame' wordt gebruikt als de speler op een afsluitknop drukt
    public void QuitGame()
    {
        // Als ronde niet bezig is
        if (gameInitializationSettings.roundInProgress == false)
        {
            Debug.Log("Exit requested");
            // Als UNITY EDITOR aanwezig wordt de editor NIET afgesloten, anders WEL
            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
            #else
                        Application.Quit();
            #endif
        }
    }
}

/*
 * Jordy Perret - IO3S1AV
 * Border Patrol Alienist
 * 14-11-2023
 */

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartscreenScript : MonoBehaviour
{
    // Script properties defineren
    public GameObject generalScripts;
    private GameInitializationSettings gameInitializationSettings;
    public GameObject startScreen;

    // Start is called before the first frame update
    void Start()
    {
        // Iterate through all child GameObjects using foreach
    }

    // Update is called once per frame
    public void removeStartScreen()
    {
        // Game Settings defineren
        gameInitializationSettings = generalScripts.GetComponent<GameInitializationSettings>();

        // Verwijderen startscherm
        Destroy(startScreen);

        // Game settings wijzigen
        gameInitializationSettings.startScreen = false;
        gameInitializationSettings.roundInProgress = true;
    }
}

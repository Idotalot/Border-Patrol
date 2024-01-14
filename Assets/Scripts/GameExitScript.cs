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
    public void QuitGame()
    {
        if (gameInitializationSettings.roundInProgress == false)
        {
            Debug.Log("Exit requested");
            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
            #else
                        Application.Quit();
            #endif
        }
    }
}

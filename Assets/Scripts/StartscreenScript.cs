using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartscreenScript : MonoBehaviour
{
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
        gameInitializationSettings = generalScripts.GetComponent<GameInitializationSettings>();

        Destroy(startScreen);
        gameInitializationSettings.startScreen = false;
        gameInitializationSettings.roundInProgress = true;
    }
}

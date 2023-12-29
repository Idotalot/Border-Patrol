using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public List<GameObject> deathScreenObjects;
    public GameObject deathScreen;
    // Start is called before the first frame update

    // Game settings defineren
    public GameObject generalScripts;
    private GameInitializationSettings gameInitializationSettings;

    void Start()
    {
        gameInitializationSettings = generalScripts.GetComponent<GameInitializationSettings>();

        for (int i = 0; i < deathScreen.transform.childCount; i++)
        {
            SpriteRenderer childRenderer = deathScreen.transform.GetChild(i).GetComponent<SpriteRenderer>();
            Debug.Log(childRenderer.name + ": " + childRenderer.sortingLayerName);
        }
        // Iterate through all child GameObjects using foreach
    }

    // Update is called once per frame
    void Update()
    {
        gameInitializationSettings = generalScripts.GetComponent<GameInitializationSettings>();

        if (gameInitializationSettings.playerDied == true)
        {
            for (int i = 0; i < deathScreen.transform.childCount; i++)
            {
                SpriteRenderer childRenderer = deathScreen.transform.GetChild(i).GetComponent<SpriteRenderer>();
                childRenderer.sortingLayerName = "DeathScreen";
            }
        }
        
    }
}

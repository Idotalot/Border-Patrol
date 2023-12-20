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
            Debug.Log(childRenderer.name + ": " + childRenderer.sortingLayerID);
        }
        // Iterate through all child GameObjects using foreach
    }

    // Update is called once per frame
    void Update()
    {
        /* foreach GameObject gameObject in GameObject deathScreen
        {

        }
        if (gameInitializationSettings.playerDied == false)
        {
            deathScreenSprite.sortingLayer = 0;
        }
        else (gameInitializationSettings.playerDied == true) 
        {
            deathScreen.layer
        } */
    }
}

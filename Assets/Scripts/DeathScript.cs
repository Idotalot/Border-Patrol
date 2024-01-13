using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DeathScript : MonoBehaviour
{
    public List<GameObject> deathScreenObjects;
    public GameObject deathScreen;
    public TextMeshProUGUI deathScreenText;
    public Button deathScreenRetryButton;
    public Button deathScreenExitButton;
    public RectTransform retryTransform;
    public RectTransform exitTransform;
    // Game settings defineren
    public GameObject generalScripts;
    private GameInitializationSettings gameInitializationSettings;

    // Start is called before the first frame update
    void Start()
    {
        // Iterate through all child GameObjects using foreach
        InvokeRepeating("popUpDeathScreen", 0f, 1f);
    }

    private void popUpDeathScreen()
    {
        gameInitializationSettings = generalScripts.GetComponent<GameInitializationSettings>();

        for (int i = 0; i < deathScreen.transform.childCount; i++)
        {
            /*Vector2 retryTransformPos = new Vector2(85, )*/
            SpriteRenderer childRenderer = deathScreen.transform.GetChild(i).GetComponent<SpriteRenderer>();
            if (gameInitializationSettings.playerDied == true)
            {
                deathScreenText.text = "You suck!";
                childRenderer.sortingLayerName = "DeathScreen";

                retryTransform.anchoredPosition = new Vector2(-85, -200);
                exitTransform.anchoredPosition = new Vector2(85, -200);
            }
            else if (gameInitializationSettings.playerDied == false)
            {
                deathScreenText.text = "";
                childRenderer.sortingLayerName = "InvisibleLayer";

                retryTransform.anchoredPosition = new Vector2(85, -300);
                exitTransform.anchoredPosition = new Vector2(-85, -300);
            }
        }
    }
}

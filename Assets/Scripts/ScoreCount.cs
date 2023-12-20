using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;

    // Game settings defineren
    public GameObject generalScripts;
    private GameInitializationSettings gameInitializationSettings;

    // Start is called before the first frame update
    void Start()
    {
        gameInitializationSettings = generalScripts.GetComponent<GameInitializationSettings>();
        scoreText = GameObject.Find("Canvas/scoreCount").GetComponent<TextMeshProUGUI>();
        Debug.Log(scoreText.text + " points");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        score += 3;
        scoreText.text = score.ToString();
    }
}
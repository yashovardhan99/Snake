using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public static string HighScoreKey = "HIGHSCORE";
    public TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        score.GetComponent<TextMeshProUGUI>().SetText("Your Score: "+ScoreHandler.score);
        int highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        if(ScoreHandler.score > highScore) {
            highScore = ScoreHandler.score;
            PlayerPrefs.SetInt(HighScoreKey, highScore);
            GetComponent<MenuManager>().updateHighScore();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

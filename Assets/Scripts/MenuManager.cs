using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    void Start() {
        updateHighScore();
    }
    public void updateHighScore() {
        int highScore = PlayerPrefs.GetInt(GameOverManager.HighScoreKey, 0);
        highScoreText.GetComponent<TextMeshProUGUI>().SetText("High Score: "+highScore);
    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            startGame();
        }
        if(Input.GetKeyDown(KeyCode.Escape)) {
            quitGame();
        }
    }
    public void startGame() {
        SceneManager.LoadScene("GameScene");       
    }    
    public void quitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}

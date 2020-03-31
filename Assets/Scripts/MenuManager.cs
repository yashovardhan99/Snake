using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
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

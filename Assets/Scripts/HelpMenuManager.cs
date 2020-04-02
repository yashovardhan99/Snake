using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpMenuManager : MonoBehaviour
{
    void Update() {
        if(Input.GetKeyDown(KeyCode.H)) {
            backToMainMenu();
        }
    }
    public void backToMainMenu() {
        SceneManager.UnloadSceneAsync("Help");
    }
}

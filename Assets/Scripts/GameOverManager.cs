using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        score.GetComponent<TextMeshProUGUI>().SetText("Your Score "+ScoreHandler.score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

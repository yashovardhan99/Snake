using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private Snake snake;
    private bool collided;
    // Start is called before the first frame update
    void Start()
    {
        snake = FindObjectOfType<Snake>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider) {
        if(collider.tag == "Player" && !collided) {
            collided = true;
            ScoreHandler.score++;
            snake.requestNewFood();
            snake.size++;
            Destroy(gameObject);
        }
    }
}

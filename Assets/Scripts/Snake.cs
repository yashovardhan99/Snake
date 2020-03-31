using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Snake : MonoBehaviour
{
    public int startingLength = 1;
    public float speed = 4;
    public float delay = 0.1f;
    public float foodDelay = 0.5f;
    public float collError = 0.05f;
    private GameObject[] snake;
    float gameHeight, gameWidth;
    public GameObject snakePrefab;
    public GameObject foodPrefab;
    Vector2 direction = Vector2.up;
    public event System.Action gameOver;
    public bool isGameOver;
    public int size = 2;
    public TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        ScoreHandler.score = 0;
        gameHeight = Camera.main.orthographicSize;
        gameWidth = Camera.main.aspect * gameHeight;
        snake = new GameObject[Mathf.CeilToInt(gameHeight*gameWidth / snakePrefab.transform.localScale.x / snakePrefab.transform.localScale.y)];
        snake[0] = Instantiate(snakePrefab, -Vector2.one, Quaternion.identity);
        // print(snake.Length);
        StartCoroutine(moveRoutine());
        score = score.GetComponent<TextMeshProUGUI>();
        score.SetText(ScoreHandler.score.ToString());

        Instantiate(foodPrefab, new Vector2(Random.Range(-gameWidth, gameWidth), Random.Range(-gameHeight, gameHeight)), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        bool down = Input.GetKeyDown(KeyCode.DownArrow) && direction != Vector2.up;
        bool up = Input.GetKeyDown(KeyCode.UpArrow) && direction != Vector2.down;
        bool left = Input.GetKeyDown(KeyCode.LeftArrow) && direction != Vector2.right;
        bool right = Input.GetKeyDown(KeyCode.RightArrow) && direction != Vector2.left;
        
        if(down) {
            direction = Vector2.down;
        }
        else if(up) {
            direction = Vector2.up;
        }
        else if(right) {
            direction = Vector2.right;
        }
        else if(left) {
            direction = Vector2.left;
        }
        
        Vector2 position = snake[0].transform.position;
                
        if(position.x < -gameWidth || position.x > gameWidth || position.y < -gameHeight || position.y > gameHeight) {
            // print("Game Over!");
            endGame();
        }
    }
    IEnumerator moveRoutine() {
        while(!isGameOver) {
            move();
            yield return new WaitForSeconds(delay);
        }
    }
    void move() {
        for(int i=size - 1; i>0 && !isGameOver; i--) {
            createIfNull(i);
            createIfNull(i-1);
            if(snake[i] == null) {
                continue;
            }
            snake[i].transform.position = snake[i-1].transform.position;
        }
        snake[0].transform.position = snake[0].transform.position + (Vector3)direction*speed*delay;
        checkCollisionWithSelf();
    }
    void createIfNull(int index) {
        if(snake[index] == null) {
            snake[index] = Instantiate(snakePrefab, new Vector2(-100, -100), Quaternion.identity);
        }
    }
    void checkCollisionWithSelf() {
        for(int i=1; i<size; i++) {
            if(Mathf.Abs(snake[0].transform.position.x.CompareTo(snake[i].transform.position.x)) <= collError 
            && Mathf.Abs(snake[0].transform.position.y.CompareTo(snake[i].transform.position.y)) <= collError ) {
                // print("Collision with self");
                endGame();
            }
        }
    }
    public void requestNewFood() {
        StopCoroutine(spawnFoodWithDelay());
        score.SetText(ScoreHandler.score.ToString());
        StartCoroutine(spawnFoodWithDelay());
    }
    public IEnumerator spawnFoodWithDelay() {
        // print("Yo");
        yield return new WaitForSeconds(foodDelay);
        // print("New food spawned!");
        Instantiate(foodPrefab, new Vector2(Random.Range(-gameWidth, gameWidth), Random.Range(-gameHeight, gameHeight)), Quaternion.identity);
        yield break;
    }
    private void endGame() {
        isGameOver = true;
        if(gameOver!=null) {
            gameOver();       
        }
        SceneManager.LoadScene("GameOver");
    }
}

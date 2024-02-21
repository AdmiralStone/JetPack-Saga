using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public float playerScore;
    float lastHighScore = 0;

    [SerializeField] TextMeshProUGUI scoreText;
 
    [SerializeField] GameObject lastHighScoreObj;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject gameRestartButton;
    [SerializeField] GameObject player;

    

    Vector3 playerStartPos;

    // Start is called before the first frame update
    void Start()
    {
        playerStartPos = player.transform.position;
        StartGame();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGameActive) {
            playerScore += Time.fixedDeltaTime;
        }
        

        
    }

    private void Update()
    {
        scoreText.text = "Score: " + ((int)playerScore).ToString();
        lastHighScore = Mathf.Max(lastHighScore, playerScore);

        if (!isGameActive)
        {
            gameOverText.SetActive(true);
            gameRestartButton.SetActive(true);
            lastHighScoreObj.SetActive(true);

            TextMeshProUGUI lastHighScoreText = lastHighScoreObj.GetComponent<TextMeshProUGUI>();
            lastHighScoreText.text = "Last High Score: " + ((int)lastHighScore).ToString();
        }


    }

    void StartGame()
    {
        isGameActive = true;
        playerScore = 0;
    }

    public void RestartGame()
    {
        playerScore = 0;
        gameOverText.SetActive(false);
        gameRestartButton.SetActive(false);
        lastHighScoreObj.SetActive(false);

        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obs in obstacles)
        {
            Destroy(obs);
        }

        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject coin in coins)
        {
            Destroy(coin);
        }

        player.transform.position = playerStartPos;

        isGameActive = true;

    }
}

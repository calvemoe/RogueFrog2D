using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Text levelText;
    public Text scoreText;
    public Text gameOverText;

    public PlayerController player;

    private float difficultyIncrease = 1.2f;

    private float highestPosition;
    private int score = 0;
    private int level = 1;

    private float restartTimer = 3f;    //3 seconds after game over

	// Use this for initialization
	void Start () {
        gameOverText.gameObject.SetActive(false);
        player.OnPlayerMoved += OnPlayerMoved;
        player.OnPlayerEscaped += OnPlayerEscaped;

        highestPosition = player.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        if (player == null)
        {
            gameOverText.gameObject.SetActive(true);

            restartTimer -= Time.deltaTime;
            if (restartTimer <= 0)
            {
                SceneManager.LoadScene("Game");
            }
        }
	}

    void OnPlayerMoved()
    {
        if (player.transform.position.y > highestPosition)
        {
            highestPosition = player.transform.position.y;
            score++;
            scoreText.text = "Score: " + score;
        }
    }

    void OnPlayerEscaped()
    {
        highestPosition = player.transform.position.y;
        level++;
        levelText.text = "Level " + level;

        Debug.Log(difficultyIncrease);

        foreach(Enemy enemy in GetComponentsInChildren<Enemy>())
        {
            Debug.Log(enemy.speed);
            enemy.speed *= difficultyIncrease;
        }
    }
}

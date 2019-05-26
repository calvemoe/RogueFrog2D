using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    [SerializeField]
    private Text levelText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text gameOverText;

    [SerializeField]
    private PlayerController player;

    //multiplier for enemy speed increasing
    private float difficultyIncrease = 1.2f;

    private float highestPosition;
    private int score = 0;
    private int level = 1;

    private float restartTimer = 3f;    //3 seconds after game over

    private List<Enemy> enemies;

    void Awake() {
        enemies = new List<Enemy>(GetComponentsInChildren<Enemy>());
        highestPosition = player.transform.position.y;
    }

	// Use this for initialization
	void Start () {
        gameOverText.gameObject.SetActive(false);

        player.OnPlayerMoved += OnPlayerMoved;
        player.OnPlayerEscaped += OnPlayerEscaped;
	}
	
	// Update is called once per frame
	void Update () {
        if (player == null) {
            gameOverText.gameObject.SetActive(true);

            restartTimer -= Time.deltaTime;
            if (restartTimer <= 0)
                SceneManager.LoadScene("Game");
        }
	}

    void OnPlayerMoved() {
        if (player.transform.position.y > highestPosition) {
            highestPosition = player.transform.position.y;
            score++;
            scoreText.text = score.ToString();
        }
    }

    void OnPlayerEscaped() {
        highestPosition = player.transform.position.y;
        level++;
        levelText.text = level.ToString();

        foreach(Enemy enemy in enemies)
            enemy.speed *= difficultyIncrease;
    }
}

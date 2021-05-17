using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public Button restartButton;
    public GameObject titleScreen;
    public bool isGameActive;
    public int score;
    public GameObject obstaclePrefab;
    private int obstacleSpawnIndex;
    Transform spawnPoint;
    private float obstacleSpawnRate = 1.0f;
    private float gemSpawnRate = 1.0f;
    public GameObject gemPrefab;
    private int gemSpawnIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObstacle()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(obstacleSpawnRate);
            //random spawnpoint for the obstacle / random spawnplek voor de obstakel
            obstacleSpawnIndex = Random.Range(0, 3);
            spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

            // Spawn obstacle to that position / spawn obstakel op die positie
            Instantiate(obstaclePrefab, spawnPoint.position, obstaclePrefab.transform.rotation);
        }
    }

    IEnumerator SpawnGem()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(gemSpawnRate);
            //random spawnpoint for the gem / random spawnplek voor de gem
            gemSpawnIndex = Random.Range(3, 6);
            spawnPoint = transform.GetChild(gemSpawnIndex).transform;

            // Spawn gem to that position / spawn gem op die positie
            Instantiate(gemPrefab, spawnPoint.position, gemPrefab.transform.rotation);
        }
    }

    public void UpdateScore(int ScoreToAdd)
    {
        // add score / score toevoegen
        score = ScoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        // if you are game over restart button and game over text appears
        // als je game over bent de restart knop en game over text komt tevoorschijn
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        //load the scene / laad de scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        // if game starts titlescreen dissappear, the obstacle and gem spawns
        // als de game start de titlescreen verdwijnt, de obstakel en gem spawnen
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        score = 0;
        UpdateScore(0);
        StartCoroutine(SpawnObstacle());
        StartCoroutine(SpawnGem());
    }
}

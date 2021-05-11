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
    public int obstacleSpawnIndex;
    Transform spawnPoint;
    private float obstacleSpawnRate = 1.0f;
    private float gemSpawnRate = 1.0f;
    public GameObject gemPrefab;
    public int gemSpawnIndex;

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
            obstacleSpawnIndex = Random.Range(0, 3);
            spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

            Instantiate(obstaclePrefab, spawnPoint.position, obstaclePrefab.transform.rotation);
        }
    }

    IEnumerator SpawnGem()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(gemSpawnRate);
            gemSpawnIndex = Random.Range(3, 6);
            spawnPoint = transform.GetChild(gemSpawnIndex).transform;

            Instantiate(gemPrefab, spawnPoint.position, gemPrefab.transform.rotation);
        }
    }

    public void UpdateScore(int ScoreToAdd)
    {
        score += ScoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        score = 0;
        UpdateScore(0);
        StartCoroutine(SpawnObstacle());
        StartCoroutine(SpawnGem());
    }
}

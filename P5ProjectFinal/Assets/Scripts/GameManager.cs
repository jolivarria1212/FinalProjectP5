using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool isGameActive;
    private int score;
    public GameObject titleScreen;
    public GameObject pauseScreen;
    private bool paused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            score += scoreToAdd;
            scoreText.text = "Score: " + score;
        }
    }
        public void GameOver()
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            isGameActive = false;
        }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
   
        titleScreen.gameObject.SetActive(false);
    }
    public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    void ChangePaused()
    {
        if (!paused)
        {
            paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
    // Update is called once per frame
    void Update()
        {
        
        }
    }

using UnityEngine;
using TMPro; // <--- 1. ADD THIS LIBRARY

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    // 2. Add variables for Score
    public int score = 0;
    public TextMeshProUGUI scoreText; 

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
        score = 0;
        UpdateScoreUI();
        Time.timeScale = 1; 
    }

    
    public void AddScore()
    {
        score++;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
       
    }
}
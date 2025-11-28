using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    
    public int score = 0;
    public TextMeshProUGUI scoreText; 
    public GameObject startScreen;
    public GameObject gameOverScreen;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
        Time.timeScale = 0; 

        
        if(startScreen != null) startScreen.SetActive(true);
        if(gameOverScreen != null) gameOverScreen.SetActive(false);

        score = 0;
        UpdateScoreUI();
    }
    public void StartGame()
    {
        
        if(startScreen != null) startScreen.SetActive(false);
        if(scoreText != null) scoreText.gameObject.SetActive(true); 
        
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
        
        if(gameOverScreen != null) gameOverScreen.SetActive(true);
        if(scoreText != null) scoreText.gameObject.SetActive(false); 
        
        Time.timeScale = 0;
    }
    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
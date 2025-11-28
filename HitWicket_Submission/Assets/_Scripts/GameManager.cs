using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    
    // UI References
    public GameObject startScreen;
    public GameObject gameOverScreen;
    public TMPro.TMP_Text scoreText;
    void Awake() // <--- ADD THIS BLOCK
    {
        Instance = this;
    }
    void Start() 
    {
         // Pause game at start
         //Time.timeScale = 0;

         //TEMPORARY REMOVE AFTER YOU GET UI
         Time.timeScale = 1;
    }

    public void StartGame()
    {
        
        //startScreen.SetActive(false);
        Time.timeScale = 1;
        // Spawn the very first pulpit manually here
        SpawnManager.Instance.SpawnPulpit(Vector3.zero); 
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
       // Time.timeScale = 0;
        //gameOverScreen.SetActive(true);
    }
}
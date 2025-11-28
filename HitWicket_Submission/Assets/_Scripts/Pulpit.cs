using UnityEngine;
using TMPro; 

public class Pulpit : MonoBehaviour
{
    public float destroyTime;
    private float timer;
    private bool hasSpawnedNext = false;

    
    public TextMeshPro timerText; 
    private bool isScoreCounted = false;

    void Start()
    {
        
        float minTime = ConfigManager.Instance.Config.pulpit_data.min_pulpit_destroy_time;
        float maxTime = ConfigManager.Instance.Config.pulpit_data.max_pulpit_destroy_time;
        
        destroyTime = Random.Range(minTime, maxTime);
        timer = destroyTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        
        if(timerText != null) timerText.text = timer.ToString("F1");

        
        if (timer <= ConfigManager.Instance.Config.pulpit_data.pulpit_spawn_time && !hasSpawnedNext)
        {
            hasSpawnedNext = true;
            SpawnManager.Instance.SpawnPulpit(this.transform.position);
        }

        
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Player") && !isScoreCounted)
        {
            GameManager.Instance.AddScore();
            isScoreCounted = true; 
        }
    }
}
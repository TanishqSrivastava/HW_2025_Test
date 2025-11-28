using UnityEngine;
using TMPro; // For displaying the timer on the cube (optional but cool)

public class Pulpit : MonoBehaviour
{
    public float destroyTime;
    private float timer;
    private bool hasSpawnedNext = false;

    // Reference to the text mesh to show countdown
    public TextMeshPro timerText; 

    void Start()
    {
        // Get random destroy time from JSON range
        float minTime = ConfigManager.Instance.Config.pulpit_data.min_pulpit_destroy_time;
        float maxTime = ConfigManager.Instance.Config.pulpit_data.max_pulpit_destroy_time;
        
        destroyTime = Random.Range(minTime, maxTime);
        timer = destroyTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        // Update UI Text if you have it
        if(timerText != null) timerText.text = timer.ToString("F1");

        // Logic to Spawn the NEXT pulpit
        if (timer <= ConfigManager.Instance.Config.pulpit_data.pulpit_spawn_time && !hasSpawnedNext)
        {
            hasSpawnedNext = true;
            SpawnManager.Instance.SpawnPulpit(this.transform.position);
        }

        // Logic to Destroy THIS pulpit
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
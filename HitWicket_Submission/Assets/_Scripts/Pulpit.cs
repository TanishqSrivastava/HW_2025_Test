using UnityEngine;
using TMPro; 

public class Pulpit : MonoBehaviour
{
    public float destroyTime;
    private float timer;
    private bool hasSpawnedNext = false;
private bool isDestructionStarted = false;
    private Vector3 targetScale;
    public TextMeshPro timerText; 
    private bool isScoreCounted = false;

    void Start()
    {
        targetScale = transform.localScale;
        transform.localScale = Vector3.zero;
        StartCoroutine(PopUpAnimation());
        
        float minTime = ConfigManager.Instance.Config.pulpit_data.min_pulpit_destroy_time;
        float maxTime = ConfigManager.Instance.Config.pulpit_data.max_pulpit_destroy_time;
        
        destroyTime = Random.Range(minTime, maxTime);
        timer = destroyTime;
    }
    System.Collections.IEnumerator PopUpAnimation()
    {
        float timer = 0;
        float duration = 0.5f; 

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float progress = timer / duration;

            
            float curve = Mathf.SmoothStep(0, 1, progress);

            
            transform.localScale = Vector3.Lerp(Vector3.zero, targetScale, curve);

            yield return null; 
        }


        transform.localScale = targetScale;
    }
    System.Collections.IEnumerator ShrinkAnimation()
    {
        isDestructionStarted = true; 

        float animTimer = 0;
        float duration = 0.5f; 
        Vector3 currentSize = transform.localScale;

        while (animTimer < duration)
        {
            animTimer += Time.deltaTime;
            float progress = animTimer / duration;
            float curve = Mathf.SmoothStep(0, 1, progress);

            
            transform.localScale = Vector3.Lerp(currentSize, Vector3.zero, curve);
            yield return null; 
        }

        
        Destroy(gameObject);
    }

    void Update()
    {
        if (isDestructionStarted) return;
        timer -= Time.deltaTime;

        
        if(timerText != null) 
            timerText.text = Mathf.Max(0, timer).ToString("F1");

        
        if (timer <= ConfigManager.Instance.Config.pulpit_data.pulpit_spawn_time && !hasSpawnedNext)
        {
            hasSpawnedNext = true;
            SpawnManager.Instance.SpawnPulpit(this.transform.position);
        }

        
        if (timer <= 0 && !isDestructionStarted)
        {
            StartCoroutine(ShrinkAnimation());
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
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    public GameObject pulpitPrefab;

    void Awake() { Instance = this; }

    public void SpawnPulpit(Vector3 previousPosition)
    {
        Vector3 newPos = Vector3.zero;
        
        // Choose a random direction: 0=Forward, 1=Back, 2=Left, 3=Right
        int direction = Random.Range(0, 4);
        float offset = 9f; // Since platform is 9x9

        switch (direction)
        {
            case 0: newPos = previousPosition + new Vector3(0, 0, offset); break; // North
            case 1: newPos = previousPosition + new Vector3(0, 0, -offset); break; // South
            case 2: newPos = previousPosition + new Vector3(-offset, 0, 0); break; // West
            case 3: newPos = previousPosition + new Vector3(offset, 0, 0); break; // East
        }

        Instantiate(pulpitPrefab, newPos, Quaternion.identity);
    }
}
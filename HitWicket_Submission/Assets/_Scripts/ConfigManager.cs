using UnityEngine;
using System.IO; // Required for file reading

public class ConfigManager : MonoBehaviour
{
    public static ConfigManager Instance;
    public GameConfig Config;

    void Awake()
    {
        Instance = this;
        LoadConfig();
    }

    void LoadConfig()
    {
        // For simplicity in editor:
        TextAsset jsonFile = Resources.Load<TextAsset>("doofus_diary");
        Config = JsonUtility.FromJson<GameConfig>(jsonFile.text);
        
        // Note: In a real build, you might use Application.streamingAssetsPath
    }
}
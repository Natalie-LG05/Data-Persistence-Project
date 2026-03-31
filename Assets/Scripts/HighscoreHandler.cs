using System.IO;
using UnityEngine;

public class HighscoreHandler : MonoBehaviour
{
    public static HighscoreHandler Instance;

    public int highscore;
    public string playerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Instance.Load();
    }

    [System.Serializable]
    private class SaveData
    {
        public int highscore;
        public string playerName;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.highscore = highscore;
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highscore = data.highscore;
            playerName = data.playerName;
        }
    }

    private void OnApplicationQuit()
    {
        // Save game data before exiting
        Instance.Save();

        //Debug.Log("Game closed!");
    }
}

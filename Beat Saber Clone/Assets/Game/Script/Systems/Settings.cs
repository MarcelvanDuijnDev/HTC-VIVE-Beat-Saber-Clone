using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public SettingsFile saveFile;
    public PlayerStats playerStats;

    private void Awake()
    {
        //Save();
        Load();
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(saveFile);
        File.WriteAllText(Application.persistentDataPath + "/Settings.Info", json.ToString());
    }

    private void Load()
    {
        string dataPath = Application.persistentDataPath + "/Settings.Info";
        string dataAsJson = File.ReadAllText(dataPath);
        saveFile = JsonUtility.FromJson<SettingsFile>(dataAsJson);
    }

    private void OnApplicationQuit()
    {
        playerStats.Save();
    }
}

[System.Serializable]
public class SettingsFile
{
    public string gamePath;
    public bool fullscreen;
    public Vector2 resolution;
    public int graphicsQuality;
}
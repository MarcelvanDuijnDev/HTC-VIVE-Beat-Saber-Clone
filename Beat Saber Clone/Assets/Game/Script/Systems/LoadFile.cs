using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadFile : MonoBehaviour
{
    string beatsaberPath;
    [SerializeField] private Info readInfo;
    [SerializeField] private Settings settingsScript;

    public List<string> difficulties;
    public List<string> songNames;
    public List<string> authorName;
    public List<string> songnamesPath;
    public List<string> songImagePath;
    public List<string> songAudioPath;
    public List<float> songOffset;
    string[] songpath;

    void Start ()
    {
        beatsaberPath = settingsScript.saveFile.gamePath;
        songpath = Directory.GetDirectories(beatsaberPath + "/CustomSongs");

        for (int i = 1; i < songpath.Length; i++)
        {
            try
            {
                string[] getnames = Directory.GetDirectories(songpath[i]);
                songnamesPath.Add(getnames[0]);
            }
            catch
            {
                Debug.Log("Failed");
            }
        }

        for (int i = 0; i < songnamesPath.Count; i++)
        {
            Load(songnamesPath[i] + "/info.json");
            songNames.Add(readInfo.songName);
            authorName.Add(readInfo.authorName);
            songImagePath.Add(songnamesPath[i] + "/" + readInfo.coverImagePath);
            songAudioPath.Add(songnamesPath[i] + "/" + readInfo.difficultyLevels[0].audioPath);
            songOffset.Add(readInfo.difficultyLevels[0].offset);  //Get offset

            string dif = "";
            for (int o = 0; o < readInfo.difficultyLevels.Length; o++)
            {
                if (readInfo.difficultyLevels[o].difficulty == "Easy")
                    dif += "a";
                if (readInfo.difficultyLevels[o].difficulty == "Normal")
                    dif += "b";
                if (readInfo.difficultyLevels[o].difficulty == "Hard")
                    dif += "c";
                if (readInfo.difficultyLevels[o].difficulty == "Expert")
                    dif += "d";
                if (readInfo.difficultyLevels[o].difficulty == "ExpertPlus")
                    dif += "e";
            }
            difficulties.Add(dif);
        }
    }

    private void Load(string _path)
    {
        string dataPath = _path;
        string dataAsJson = File.ReadAllText(dataPath);
        readInfo = JsonUtility.FromJson<Info>(dataAsJson);
    }
}

[System.Serializable]
public class Info
{
    public string songName;
    public string songSubName;
    public string authorName;
    public int beatsPerMinute;
    public int previewStartTime;
    public int previewDuration;
    public string coverImagePath;
    public string environmentName;
    public _DifficultyLevels[] difficultyLevels;
}

[System.Serializable]
public class _DifficultyLevels
{
    public string difficulty;
    public int difficultyRank;
    public string audioPath;
    public string jsonPath;
    public int offset;
    public int oldOffset;
}
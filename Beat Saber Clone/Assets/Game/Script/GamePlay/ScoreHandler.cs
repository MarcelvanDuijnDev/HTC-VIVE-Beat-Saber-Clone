using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public PlayerStatsFile playerFile;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text comboText;
    [SerializeField] private Text multiplyText;
    [SerializeField] private ScoreSaveFile scoreSafeFile;

    [HideInInspector] public string currentSongName;

    private float score = 0;
    private float combo = 0;
    private float multiply = 0;
    private int hitsToMultiply = 4;
    private int checkHits = 0;

    void Update()
    {
        scoreText.text = score.ToString("0.00");
        comboText.text = combo.ToString();
        multiplyText.text = "x" + multiply.ToString();

        if(Input.GetKeyDown(KeyCode.H))
        {
            Save();
        }
    }

    public void Miss()
    {
        combo = 0;
        multiply = 0;
        playerFile.hits_Missed++;
    }

    public void AddScore(float _Score)
    {
        score += _Score * (1 + multiply);
        combo++;
        checkHits++;
        if (checkHits >= 4 && multiply < 8)
        {
            multiply++;
            checkHits = 0;
        }
        playerFile.hits_Total++;
    }

    public void SongComplete()
    {
        Save();
    }

    public void Save()
    {
        bool check = false;
        for (int i = 0; i < scoreSafeFile.SongNames.Count; i++)
        {
            if(scoreSafeFile.SongNames[i] == currentSongName)
            {
                for (int o = 0; o < 10; o++)
                {
                    if (scoreSafeFile.scores[scoreSafeFile.scores.Count].score[o] > score)
                    {
                        scoreSafeFile.scores[i].songName[o] = currentSongName;
                        scoreSafeFile.scores[i].playerName[o] = "playername: " + o.ToString();
                        scoreSafeFile.scores[i].score[o] = score;
                    }
                }
                check = true;
            }
        }

        if(!check)
        {
            scoreSafeFile.SongNames.Add(currentSongName);
            scoreSafeFile.scores.Add(new Scores());
            scoreSafeFile.scores[scoreSafeFile.scores.Count].songName = new string[10];
            scoreSafeFile.scores[scoreSafeFile.scores.Count].playerName = new string[10];
            scoreSafeFile.scores[scoreSafeFile.scores.Count].score = new float[10];
        }

        string json = JsonUtility.ToJson(scoreSafeFile);
        File.WriteAllText(Application.persistentDataPath + "/Scores.Info", json.ToString());
    }

    private void Load()
    {
        string dataPath = Application.persistentDataPath + "/Scores.Info";
        string dataAsJson = File.ReadAllText(dataPath);
        scoreSafeFile = JsonUtility.FromJson<ScoreSaveFile>(dataAsJson);
    }

}

[System.Serializable]
public class ScoreSaveFile
{
    public List<string> SongNames;
    public List<Scores> scores;
}

[System.Serializable]
public class Scores
{
    public string[] songName;
    public string[] playerName;
    public float[] score;
}
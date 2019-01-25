using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerStatsFile playerFile;

    [SerializeField] private Text[] hitsText;

    public void Start()
    {
        Load();
    }

    public void Update()
    {
        SetStats();
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(playerFile);
        File.WriteAllText(Application.persistentDataPath + "/UserData.Info", json.ToString());
    }

    private void Load()
    {
        string dataPath = Application.persistentDataPath + "/UserData.Info";
        string dataAsJson = File.ReadAllText(dataPath);
        playerFile = JsonUtility.FromJson<PlayerStatsFile>(dataAsJson);
    }

    public void SetStats()
    {
        for (int i = 0; i < hitsText.Length; i++)
        {
            switch (i)
            {
                case 0:
                    hitsText[i].text = "Total Hits: " + playerFile.hits_Total.ToString();
                    break;
                case 1:
                    hitsText[i].text = "Fantastic Hits: " + playerFile.hits_Fantastic.ToString();
                    break;
                case 2:
                    hitsText[i].text = "Excellent Hits: " + playerFile.hits_Excellent.ToString();
                    break;
                case 3:
                    hitsText[i].text = "Great Hits: " + playerFile.hits_Great.ToString();
                    break;
                case 4:
                    hitsText[i].text = "Good Hits: " + playerFile.hits_Good.ToString();
                    break;
                case 5:
                    hitsText[i].text = "Decent Hits: " + playerFile.hits_Decent.ToString();
                    break;
                case 6:
                    hitsText[i].text = "Way Off Hits: " + playerFile.hits_WayOff.ToString();
                    break;
                case 7:
                    hitsText[i].text = "Missed Hits: " + playerFile.hits_Missed.ToString();
                    break;
                case 8:
                    hitsText[i].text = "Songs Played: " + playerFile.songsPlayed.ToString();
                    break;
            }
        }
    }


}

[System.Serializable]
public class PlayerStatsFile
{
    public int hits_Total;
    public int hits_Fantastic;
    public int hits_Excellent;
    public int hits_Great;
    public int hits_Good;
    public int hits_Decent;
    public int hits_WayOff;
    public int hits_Missed;

    public int songsPlayed;
}

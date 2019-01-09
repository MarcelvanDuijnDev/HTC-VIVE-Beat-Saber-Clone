using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadBeatSaberFile : MonoBehaviour
{
    public ReadBeatSaberFile readBS;
    public float timer;
    public int currentNote;

    public Transform objSpawnLoc;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private ObjectPool[] objectPoolScript;

    void Start()
    {
        Load();
    }

	void Update ()
    {
        timer += 2.5f * Time.deltaTime;
        if(timer >= readBS._notes[currentNote]._time)
        {
            float angle = 0;

            switch (readBS._notes[currentNote]._cutDirection)
            {
                case 0:
                    angle = 90;
                    break;
                case 1:
                    angle = 270;
                    break;
                case 2:
                    angle = 180;
                    break;
                case 3:
                    angle = 0;
                    break;
                case 4:
                    angle = 135;
                    break;
                case 5:
                    angle = 45;
                    break;
                case 6:
                    angle = 225;
                    break;
                case 7:
                    angle = 315;
                    break;
            }

            spawnNote(readBS._notes[currentNote]._type, new Vector2(readBS._notes[currentNote]._lineIndex * 0.5f, readBS._notes[currentNote]._lineLayer * 0.5f), angle);
            currentNote += 1;
        }

	}

    void spawnNote(int _id, Vector2 _offset, float _rotation)
    {
        for (int i = 0; i < objectPoolScript[_id].objects.Count; i++)
        {
            if (!objectPoolScript[_id].objects[i].activeInHierarchy)
            {
                objectPoolScript[_id].objects[i].transform.position = new Vector3(objSpawnLoc.position.x + _offset.x, objSpawnLoc.position.y + _offset.y, objSpawnLoc.position.z);
                objectPoolScript[_id].objects[i].transform.rotation = Quaternion.Euler(0, 0, _rotation);
                objectPoolScript[_id].objects[i].SetActive(true);
                break;
            }
        }
    }

    private void Load()
    {
        string dataPath = "C:/Users/Gebruiker/Desktop/Songs/DataBeatSaber/" + audioSource.clip.name + "Expert.json";
        string dataAsJson = File.ReadAllText(dataPath);
        readBS = JsonUtility.FromJson<ReadBeatSaberFile>(dataAsJson);
    }
    
}

[System.Serializable]
public class ReadBeatSaberFile
{
    public string _version;
    public int _beatsPerMinute;
    public int _beatsPerBar;
    public int _noteJumpSpeed;
    public int _shuffle;
    public float _shufflePeriod;
    public _Notes[] _notes;
    public _Events[] _events;
    public _Obstacles[] _obstacles;
}

[System.Serializable]
public class _Notes
{
    public float _time;
    public int _lineIndex;
    public int _lineLayer;
    public int _type;
    public int _cutDirection;
}

[System.Serializable]
public class _Events
{
    public float _time;
    public int _type;
    public int _value;
}

[System.Serializable]
public class _Obstacles
{
    public float _time;
    public int _lineIndex;
    public int _type;
    public float _duration;
    public int _width;
}


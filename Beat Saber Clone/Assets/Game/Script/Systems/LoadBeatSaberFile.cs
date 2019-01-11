using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadBeatSaberFile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float audioStartTime;
    [SerializeField] private ReadBeatSaberFile readBS;
    [SerializeField] private float timer;
    [SerializeField] private float timerSpeed;
    [SerializeField] private Transform objSpawnLoc;

    private string path = "C:/Users/Gebruiker/Desktop/Songs/DataBeatSaber/" + "Expert.json";
    private string testPath = "C:/Program Files (x86)/Steam/steamapps/common/Beat Saber/CustomSongs/testmap/Easy.json";

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private ObjectPool[] objectPoolScript;

    private bool pauze;
    private int currentNote;
    private int currentObstacle;

    void Start()
    {
        Time.timeScale = speed;
        Load();
        timerSpeed = (readBS._beatsPerMinute * 1000) / 60 * 0.001f;
    }

    void Update()
    {
        if (!pauze)
        {
            timer += timerSpeed * Time.deltaTime;
            if (timer >= audioStartTime && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        if (currentNote < readBS._notes.Length)
        {
            for (int i = 0; i < readBS._notes.Length; i++)
            {
                if (timer >= readBS._notes[currentNote]._time)
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
                        case 8:
                            if (readBS._notes[currentNote]._type == 0)
                                spawnNote(2, new Vector2(readBS._notes[currentNote]._lineIndex * 0.5f, readBS._notes[currentNote]._lineLayer * 0.5f), 0);
                            else
                                spawnNote(3, new Vector2(readBS._notes[currentNote]._lineIndex * 0.5f, readBS._notes[currentNote]._lineLayer * 0.5f), 0);
                            currentNote++;
                            break;
                    }
                    if (readBS._notes[currentNote]._cutDirection != 8)
                    {
                        if (readBS._notes[currentNote]._type > 1 && readBS._notes[currentNote]._type < 1)
                            spawnNote(readBS._notes[currentNote]._type, new Vector2(readBS._notes[currentNote]._lineIndex * 0.5f, readBS._notes[currentNote]._lineLayer * 0.5f), 0);
                        else
                            spawnNote(readBS._notes[currentNote]._type, new Vector2(readBS._notes[currentNote]._lineIndex * 0.5f, readBS._notes[currentNote]._lineLayer * 0.5f), angle);
                        currentNote++;
                    }
                    else
                    {
                        //spawnNote(4, new Vector2(readBS._notes[currentNote]._lineIndex * 0.5f, readBS._notes[currentNote]._lineLayer * 0.5f), angle);
                        //currentNote++;
                    }
                }
            }
        }

        if (currentObstacle < readBS._obstacles.Length)
        {
            for (int i = 0; i < readBS._obstacles.Length; i++)
            {
                if (timer >= readBS._notes[currentObstacle]._time)
                {
                    //spawnObstacle(readBS._obstacles[i]._lineIndex, readBS._obstacles[i]._duration, readBS._obstacles[i]._width);
                    currentObstacle++;
                }
            }
        }

        /*
        float audioInt = 0;
        for (int i = 0; i < 8; i++)
        {
            audioInt += ReadAudioFile.bandBuffer[i];
        }

        for (int i = 0; i < objectPoolScript.Length; i++)
        {
            for (int o = 0; o < objectPoolScript[i].objects.Count; o++)
            {
                objectPoolScript[i].objects[o].gameObject.transform.localScale = new Vector3(audioInt * 0.2f, audioInt * 0.2f, audioInt * 0.2f);
            }
        }
        */
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

    void spawnObstacle(float _offset, float _duration, float _width)
    {
        for (int i = 0; i < objectPoolScript[5].objects.Count; i++)
        {
            if (!objectPoolScript[5].objects[i].activeInHierarchy)
            {
                objectPoolScript[5].objects[i].transform.position = new Vector3(objSpawnLoc.position.x + _offset, objSpawnLoc.position.y, objSpawnLoc.position.z);
                objectPoolScript[5].objects[i].transform.rotation = Quaternion.Euler(0, 0, 0);
                objectPoolScript[5].objects[i].transform.localScale = new Vector3(_width * 0.5f,2,_duration / timerSpeed);
                objectPoolScript[5].objects[i].SetActive(true);
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

    public void Pauze(bool _pauze)
    {
        pauze = _pauze;
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


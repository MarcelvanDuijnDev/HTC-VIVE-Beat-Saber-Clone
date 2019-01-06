﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NoteHandler : MonoBehaviour
{
    [SerializeField] private ObjectPool[] objectPoolScript;
    [SerializeField] private Transform objSpawnLoc;
    [SerializeField] private AudioSource clip;

    private Notes notes;
    private int currentNote;

    float timer;

    

    void Start()
    {
        Load();
    }

    private void Load()
    {
        string dataPath = "C:/Users/Gebruiker/Desktop/Songs/Data/" + clip.clip.name + ".json";
        string dataAsJson = File.ReadAllText(dataPath);
        notes = JsonUtility.FromJson<Notes>(dataAsJson);
    }

    void Update ()
    {
        timer += 1 * Time.deltaTime;

        if (currentNote < notes.id.Count)
        {
            if (timer >= notes.time[currentNote])
            {
                spawnNote(notes.id[currentNote], notes.offset[currentNote], notes.angle[currentNote]);
                currentNote++;
            }
        }
    }

    void spawnNote(int _id, Vector2 _offset, float _rotation)
    {
        for (int i = 0; i < objectPoolScript[_id].objects.Count; i++)
        {
            if (!objectPoolScript[_id].objects[i].activeInHierarchy)
            {
                objectPoolScript[_id].objects[i].transform.position = new Vector3(objSpawnLoc.position.x + _offset.x, objSpawnLoc.position.y + _offset.y, objSpawnLoc.position.z);
                objectPoolScript[_id].objects[i].transform.rotation = Quaternion.Euler(0,0,_rotation);
                objectPoolScript[_id].objects[i].SetActive(true);
                break;
            }
        }
    }
}

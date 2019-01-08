using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadBeatSaberFile : MonoBehaviour
{
    private int[] _notes;




	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    private void Load()
    {
        string dataPath = "C:/Users/Gebruiker/Desktop/Songs/Data/Easy.json";
        string dataAsJson = File.ReadAllText(dataPath);
        _notes = JsonUtility.FromJson<_notes>(dataAsJson);
    }
}



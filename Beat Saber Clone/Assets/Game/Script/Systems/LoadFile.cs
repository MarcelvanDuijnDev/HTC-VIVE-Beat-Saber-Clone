using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadFile : MonoBehaviour
{
    string beatsaberPath = "C:/Users/Computergebruiker/Desktop/Beat Saber";

    string[] songnames;
    string[] songpath;
    Songs[] songs;

    void Start ()
    {
        songs = new Songs[Directory.GetDirectories(beatsaberPath + "/CustomSongs").Length];
        songpath = Directory.GetDirectories(beatsaberPath + "/CustomSongs");

        for (int i = 0; i < songpath.Length; i++)
        {
            string output = songpath[i].Replace('\', "/"); //pahtcombine
            Debug.Log(songpath[i]);
        }

        songnames = new string[songpath.Length];
        for (int i = 1; i < songnames.Length; i++)
        {
            songs[i].songname = Directory.GetDirectories(songpath[i]);
            Debug.Log(songpath[i]);
            Debug.Log(songs[i].songname[i]);
        }

        Debug.Log("/CustomSongs: " + Directory.GetDirectories(beatsaberPath + "/CustomSongs").Length);


    }
	
	void Update ()
    {
		
	}
}

public class Songs
{
    public string[] songname;
}

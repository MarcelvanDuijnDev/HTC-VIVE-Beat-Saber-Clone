using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadFile : MonoBehaviour
{
    string beatsaberPath = "D:/Games/steam/steamapps/common/Beat Saber"; //"C:/Users/Computergebruiker/Desktop/Beat Saber";

    string[] songnames;
    string[] songpath;
    string[] songpath2;
    Songs[] songs;

    void Start ()
    {
        songs = new Songs[Directory.GetDirectories(beatsaberPath + "/CustomSongs").Length];
        songpath = Directory.GetDirectories(beatsaberPath + "/CustomSongs");

        for (int i = 0; i < songpath.Length; i++)
        {
            songpath2 = Directory.GetDirectories(songpath[i]);
        }

        for (int i = 0; i < songpath2.Length; i++)
        {
            Debug.Log(songpath2[i]);
        }

        songnames = new string[songpath.Length];
        for (int i = 1; i < songnames.Length; i++)
        {
            //songs[i].songname = Directory.GetDirectories(songpath[i]);
            Debug.Log(songpath[i]);
            //Debug.Log(songs[i].songname[i]);
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

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadFile : MonoBehaviour
{
    string beatsaberPath = "C:/Users/Computergebruiker/Desktop/Beat Saber"; //"D:/Games/steam/steamapps/common/Beat Saber";

    string[] songnames;
    string[] songpath;
    string[] songpath2;
    GetSongs[] getSongs;
    Songs[] songs;

    void Start ()
    {
        getSongs = new GetSongs[Directory.GetDirectories(beatsaberPath + "/CustomSongs").Length -1];

        songpath = Directory.GetDirectories(beatsaberPath + "/CustomSongs");

        getSongs[i].songs = new string[getSongs.Length];

        Debug.Log(songpath.Length);

        for (int i = 1; i < getSongs.Length; i++)
        {
            Debug.Log(songpath[i]);
            getSongs[i].songs = Directory.GetDirectories(songpath[i]);
            for (int o = 0; o < Directory.GetDirectories(getSongs[i].songs[0]).Length; o++)
            {
                songs[i].songname = Directory.GetDirectories(getSongs[i].songs[o]);
            }
        }

        for (int i = 1; i < getSongs.Length; i++)
        {
            for (int o = 0; o < songs[i].songname.Length; o++)
            {
                Debug.Log(songs[i].songname[o]);
            }
        }

        songnames = new string[songpath.Length];
        for (int i = 1; i < songpath.Length; i++)
        {
            songs[i].songname = Directory.GetDirectories(songpath2[i]);
            //Debug.Log(songs[i]);
            //Debug.Log(songs[i].songname[i]);
        }

        Debug.Log("/CustomSongs: " + Directory.GetDirectories(beatsaberPath + "/CustomSongs").Length);


    }

    void Update ()
    {
		
	}
}

public class GetSongs
{
    public string[] songs;
}

public class Songs
{
    public string[] songname;
}

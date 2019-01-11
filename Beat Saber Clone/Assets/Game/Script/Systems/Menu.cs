using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Button[] buttons;
    [SerializeField] private Button nextSongs;
    [SerializeField] private Button previousSongs;

    [SerializeField]private Text[] songnamesText;

    [SerializeField] private string[] songnames;

    private int currentSong;


	void Start ()
    {
        DirectoryInfo dir = new DirectoryInfo("C:/Users/Gebruiker/Desktop/Songs/DataBeatSaber/");
        int count = dir.GetFiles().Length;
        buttons = new Button[count];
        songnames = new string[count];
        int o = 0;
        foreach (string file in System.IO.Directory.GetFiles("C:/Users/Gebruiker/Desktop/Songs/DataBeatSaber/"))
        {
            songnames[o] = file;
            o++;
        }

        for (int i = 0; i < songnamesText.Length; i++)
        {
            songnamesText[i].text = songnames[i];
        }
        Debug.Log(count);
    }
	
	void Update ()
    {
		
	}

    public void NextSong()
    {
        currentSong += 6;
    }
    public void PreviousSong()
    {
        currentSong -= 6;
    }


}

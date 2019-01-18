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

    [SerializeField] private Image[] images;

    private int currentSong;

    //private string path = "C:/Users/Computergebruiker/Desktop/Beat Saber";
    //"C:/Users/Gebruiker/Desktop/Songs/DataBeatSaber/"

    public string url;

    IEnumerator Start()
    {
        Texture2D tex;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        using (WWW www = new WWW(url))
        {
            yield return www;
            www.LoadImageIntoTexture(tex);
            for (int i = 0; i < images.Length; i++)
            {
                images[i].GetComponent<Image>().material.mainTexture = tex;
            }
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private Menu menuScript;
    [SerializeField] private int buttonID;

    public void MenuSelectSong()
    {
        menuScript.LoadAudioButton(buttonID);
    }

    public void MenuSelectSongDif()
    {
        menuScript.ClickDifficulty(buttonID);
    }
}

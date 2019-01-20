using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("Set Script")]
    [SerializeField] private LoadFile loadFileScript;
    [SerializeField] private AudioSource audioSource;

    [Header("Set Button")]
    [SerializeField] private Button[] buttons;
    [SerializeField] private Button nextSongs;
    [SerializeField] private Button previousSongs;

    [Header("Set Text")]
    [SerializeField] private Text[] songnamesText;
    [SerializeField] private Text[] songAuthorText;
    [SerializeField] private Text selectedSongText;
    [SerializeField] private Text selectedSongAuthorText;
    [SerializeField] private Text currentSongIDText;
    [SerializeField] private Text songDuration;

    [Header("Set Image")]
    [SerializeField] private Image selectedSongImage;

    private List<string> songnames;
    private List<string> songAuthor;
    private List<string> songImagePath;
    private List<string> songAudioPath;
    private List<string> songDifficulties;

    [SerializeField] private Image[] images;

    [Header("Current Song")]
    [SerializeField] private int currentSong;

    [Header("Difficulty")]
    [SerializeField] private Button[] difficultyButtons;

    private bool loaded;

    void Start()
    {
        songnames = loadFileScript.songNames;
        songAuthor = loadFileScript.authorName;
        songImagePath = loadFileScript.songImagePath;
        songAudioPath = loadFileScript.songAudioPath;
        songDifficulties = loadFileScript.difficulties;

        selectedSongText.text = "Menu";
        selectedSongAuthorText.text = "";
    }

    public void NextSong()
    {
        currentSong += 6;
        StartCoroutine(UpdateSongs());
        UpdateSongText();
    }
    public void PreviousSong()
    {
        currentSong -= 6;
        StartCoroutine(UpdateSongs());
        UpdateSongText();
    }

    void UpdateSongText()
    {
        int textID = 0;
        for (int i = currentSong; i < currentSong +6; i++)
        {
            songnamesText[textID].text = songnames[i];
            songAuthorText[textID].text = songAuthor[i];
            textID++;
        }
        currentSongIDText.text = currentSong.ToString() + "/" + songnames.Count.ToString();
    }

    IEnumerator UpdateSongs()
    {
        int imageID = 0;
        for (int i = currentSong; i < currentSong +6; i++)
        {
            Texture2D tex;
            tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
            using (WWW www = new WWW(songImagePath[i]))
            {
                www.LoadImageIntoTexture(tex);
                images[imageID].GetComponent<Image>().material.mainTexture = tex;
                
                yield return www;
            }
            imageID++;
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].transform.gameObject.SetActive(false);
            buttons[i].transform.gameObject.SetActive(true);
        }
    }

    public void LoadAudioButton(int _ID1)
    {
        StartCoroutine(LoadAudio(currentSong + _ID1));
        selectedSongText.text = songnames[currentSong + _ID1];
        selectedSongAuthorText.text = songAuthor[currentSong + _ID1];
        StartCoroutine(SetSelectedImage(currentSong + _ID1));
        Difficulty(currentSong +  _ID1);
    }

    IEnumerator SetSelectedImage(int _ID2)
    {
        Texture2D tex;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        using (WWW www = new WWW(songImagePath[_ID2]))
        {
            www.LoadImageIntoTexture(tex);
            selectedSongImage.GetComponent<Image>().material.mainTexture = tex;

            yield return www;
        }
        selectedSongImage.transform.gameObject.SetActive(false);
        selectedSongImage.transform.gameObject.SetActive(true);
    }

    IEnumerator LoadAudio(int _ButtonID)
    {
        using (var www = new WWW(songAudioPath[_ButtonID]))
        {
            audioSource.clip = www.GetAudioClip();
            yield return www;
        }
    }

    void Update()
    {
        if(audioSource.clip != null)
        if (!audioSource.isPlaying && audioSource.clip.isReadyToPlay)
            audioSource.Play();

        float songduration = audioSource.clip.length;

        string timerString = string.Format("{0:00}:{1:00}:{2:00}", Mathf.Floor(songduration / 3600), Mathf.Floor((songduration / 60) % 60), songduration % 60);
        songDuration.text = timerString;

        if (!loaded)
        {
            StartCoroutine(UpdateSongs());
            UpdateSongText();
            loaded = true;
        }
    }

    void Difficulty(int _ID3)
    {
        if (songDifficulties[_ID3].Contains("a"))
            difficultyButtons[0].transform.gameObject.SetActive(true);
        else
            difficultyButtons[0].transform.gameObject.SetActive(false);

        if (songDifficulties[_ID3].Contains("b"))
            difficultyButtons[1].transform.gameObject.SetActive(true);
        else
            difficultyButtons[1].transform.gameObject.SetActive(false);

        if (songDifficulties[_ID3].Contains("c"))
            difficultyButtons[2].transform.gameObject.SetActive(true);
        else
            difficultyButtons[2].transform.gameObject.SetActive(false);

        if (songDifficulties[_ID3].Contains("d"))
            difficultyButtons[3].transform.gameObject.SetActive(true);
        else
            difficultyButtons[3].transform.gameObject.SetActive(false);

        if (songDifficulties[_ID3].Contains("e"))
            difficultyButtons[4].transform.gameObject.SetActive(true);
        else
            difficultyButtons[4].transform.gameObject.SetActive(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using UnityEngine;

public class Menu : MonoBehaviour
{
    #region Variables
    [Header("Set Script")]
    [SerializeField] private LoadFile loadFileScript;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private PlayerStats playerStatsScript;
    [SerializeField] private ScoreHandler scoreHandlerScript;

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

    [Header("CanvasOBJ")]
    [SerializeField] private GameObject menuObj;
    [SerializeField] private GameObject gameObj;

    private bool loaded;
    private int selectedSongID;
    private bool inMenu;

    [SerializeField] private LoadBeatSaberFile loadBSFile;
    #endregion

    void Start()
    {
        inMenu = true;
        songnames = loadFileScript.songNames;
        songAuthor = loadFileScript.authorName;
        songImagePath = loadFileScript.songImagePath;
        songAudioPath = loadFileScript.songAudioPath;
        songDifficulties = loadFileScript.difficulties;

        selectedSongText.text = audioSource.clip.name;
        selectedSongAuthorText.text = "Joji";
        CheckButtons();
    }

    public void NextSong()
    {
        currentSong += 6;
        CheckButtons();
        StartCoroutine(UpdateSongs());
        UpdateSongText();
    }
    public void PreviousSong()
    {
        currentSong -= 6;
        CheckButtons();
        StartCoroutine(UpdateSongs());
        UpdateSongText();
    }

    void UpdateSongText()
    {
        int textID = 0;
        for (int i = currentSong; i < currentSong +6; i++)
        {
            if (i < songnames.Count)
            {
                songnamesText[textID].text = songnames[i];
                songAuthorText[textID].text = songAuthor[i];
                textID++;
            }
        }
        currentSongIDText.text = currentSong.ToString() + "/" + songnames.Count.ToString();
    }

    IEnumerator UpdateSongs()
    {
        int imageID = 0;
        for (int i = currentSong; i < currentSong + 6; i++)
        {
            if (i < songnames.Count)
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
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i < songnames.Count)
            {
                buttons[i].transform.gameObject.SetActive(false);
                buttons[i].transform.gameObject.SetActive(true);
            }
        }
        CheckButtons();
    }

    public void LoadAudioButton(int _ID1)
    {
        selectedSongID = currentSong + _ID1;
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
        if (inMenu)
        {
            if (audioSource.clip != null)
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

            menuObj.SetActive(true);
            gameObj.SetActive(false);
        }
        else
        {
            menuObj.SetActive(false);
            gameObj.SetActive(true);
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inMenu = true;
            menuObj.SetActive(true);
            gameObj.SetActive(false);
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

    void CheckButtons()
    {
        if (currentSong == 0)
        {
            previousSongs.transform.gameObject.SetActive(false);
        }
        else
        {
            previousSongs.transform.gameObject.SetActive(true);
        }

        int o = 0;
        for (int i = currentSong; i < currentSong + 6; i++)
        {
            if(i < songnames.Count)
            {
                buttons[o].transform.gameObject.SetActive(true);
            }
            else
            {
                buttons[o].transform.gameObject.SetActive(false);
            }
            o++;
        }
    }

    public void ClickDifficulty(int _difID)
    {
        audioSource.Play();
        string getPath = loadFileScript.songnamesPath[selectedSongID] + "/";
        if (_difID == 0)
            getPath += "easy.json";
        if (_difID == 1)
            getPath += "normal.json";
        if (_difID == 2)
            getPath += "hard.json";
        if (_difID == 3)
            getPath += "expert.json";
        if (_difID == 4)
            getPath += "expertplus.json";
        inMenu = false;

        scoreHandlerScript.currentSongName = songnames[selectedSongID];

        StartCoroutine(LoadAudio(selectedSongID));
        selectedSongText.text = songnames[selectedSongID];
        selectedSongAuthorText.text = songAuthor[selectedSongID];
        StartCoroutine(SetSelectedImage(selectedSongID));
        Difficulty(selectedSongID);

        playerStatsScript.playerFile.songsPlayed++;
        loadBSFile.Load(getPath, loadFileScript.songOffset[selectedSongID]);
    }

}

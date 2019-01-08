using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    [SerializeField] private Text playButtonText;
    [SerializeField] private Text musicTimeMinText;
    [SerializeField] private Text musicTimeSecText;
    [SerializeField] private Text noteAngleText;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private bool continueMusic;
    [SerializeField] private Slider sliderMusic;

    [SerializeField] private Notes notes;
    [SerializeField] private GridHandler gridHandler;

    [Header("SnapSettings")]
    [SerializeField] private float snapAngle;
    [SerializeField] private bool snapAngleEnable;

    [Header("Other")]
    [SerializeField] private Transform raycastPoint;
    [SerializeField] private GameObject uiObject;
    [SerializeField] private bool hideUI;

    [Header("NoteInfo")]
    [SerializeField] private int noteID;
    [SerializeField] private Vector2 offset;
    [SerializeField] private float angle;

    [Header("Preview")]
    [SerializeField] private GameObject[] previewObjects;
    [SerializeField] private GameObject previewObj;

    private string timerString;
    private float musicTime;
    private float calcAngle;

	void Start ()
    {
        sliderMusic.maxValue = audioSource.clip.length;
        SetPreviewObject();
    }

    void Update()
    {
        SetText();

        if (continueMusic && !audioSource.isPlaying)
        {
            audioSource.Play();
            playButtonText.text = "II";
        }
        if (!continueMusic && audioSource.isPlaying)
        {
            audioSource.Pause();
            playButtonText.text = ">";
        }

        if (audioSource.isPlaying)
        {
            musicTime = sliderMusic.value;
            sliderMusic.value = audioSource.time;
        }
        else
        {
            audioSource.time = sliderMusic.value;
            musicTime = sliderMusic.value;
        }

        RaycastHit hit;
        if (Physics.Raycast(raycastPoint.position, raycastPoint.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(raycastPoint.position, raycastPoint.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (hit.transform.gameObject.CompareTag("Button"))
            {
                gridHandler.ChangeButton(hit.transform.gameObject);

                if(previewObj != null)
                {
                    previewObj.transform.position = hit.transform.position;
                    previewObj.transform.eulerAngles = new Vector3(0, 0, calcAngle);
                }
                else
                {
                    previewObjects[noteID].SetActive(true);
                    previewObj = previewObjects[noteID];
                }

                if (Input.GetKeyDown(KeyCode.O))
                {
                    notes.id.Add(noteID);
                    notes.time.Add(musicTime);
                    notes.offset.Add(new Vector2(hit.transform.position.x, hit.transform.position.y));
                    notes.angle.Add(angle);
                }
            }
            else
            {
                if (previewObj != null)
                {
                    gridHandler.ChangeButtonNull();
                    previewObj.SetActive(false);
                    previewObj = null;
                }
            }

            if (hit.transform.gameObject.CompareTag("Button1"))
            {
                gridHandler.ChangeButton1(hit.transform.gameObject);
            }
            else
            {
                gridHandler.ChangeButton1Null();
            }
        }

        if (snapAngleEnable)
        {
            float calc = Mathf.Floor(angle / snapAngle);
            calcAngle = calc * snapAngle;
        }
        else
            calcAngle = angle;

        //Set Angle
        
    }

    void SetPreviewObject()
    {
        for (int i = 0; i < previewObjects.Length; i++)
        {
            previewObjects[i].SetActive(false);
        }
        previewObjects[noteID].SetActive(true);
        previewObj = previewObjects[noteID];
    }

    public void Play()
    {
        continueMusic = !continueMusic;
    }

    public void HideUI()
    {
        hideUI = !hideUI;
        if (hideUI)
            uiObject.SetActive(false);
        else
            uiObject.SetActive(true);
    }

    void SetText()
    {
        timerString = string.Format("{0:00}:{1:00}:{2:00}", Mathf.Floor(musicTime / 3600), Mathf.Floor((musicTime / 60) % 60), musicTime % 60);
        musicTimeMinText.text = timerString;
        musicTimeSecText.text = musicTime.ToString("0") + "s";
        noteAngleText.text = "Note angle: " + calcAngle.ToString("0.00");
    }

    private void PlaceNote(int _noteID, Vector2 _offSet, float _time, float _angle)
    {
        notes.id.Add(_noteID);
        notes.time.Add(_time);
        notes.offset.Add(_offSet);
        notes.angle.Add(_angle);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    [Header("Visualize")]
    [SerializeField] private Text totalNotesText;
    [SerializeField] private Text notesPerSecText;
    [SerializeField] private GameObject rightNote;
    [SerializeField] private GameObject leftNote;
    [Header("Options")]
    [SerializeField] private float rate;

    [SerializeField] private Notes notes;
    [SerializeField] private AudioSource clip;

    private float setTime;
    private float[] checkSound = new float[8];



    void Start()
    {
        //Load();
    }

    void Update ()
    {
        totalNotesText.text = "Total Notes: " + notes.id.Count.ToString();
        notesPerSecText.text = "Notes: " + (notes.id.Count / setTime).ToString("0.00") + "/s";

        setTime += Time.deltaTime;

        if (setTime > 1)
        {
            for (int i = 0; i < 8; i++)
            {
                float check = (ReadAudioFile.bandBuffer[i] - checkSound[i]) / checkSound[i] * 100;
                if (check > rate)
                {
                    notes.id.Add(Random.Range(0, 2));
                    notes.time.Add(setTime);
                    notes.offset.Add(new Vector2(Random.Range(-1f, 1f), Random.Range(-0.8f, 0.8f)));
                    notes.angle.Add(Random.Range(0, 360));

                    if (notes.id[notes.id.Count - 1] == 0)
                    {
                        rightNote.transform.eulerAngles = new Vector3(0, 0, notes.angle[notes.id.Count - 1]);
                        rightNote.transform.position = new Vector3(notes.offset[notes.id.Count - 1].x, notes.offset[notes.id.Count - 1].y + 1, 4);
                    }
                    else
                    {
                        leftNote.transform.eulerAngles = new Vector3(0, 0, notes.angle[notes.id.Count - 1]);
                        leftNote.transform.position = new Vector3(notes.offset[notes.id.Count - 1].x, notes.offset[notes.id.Count - 1].y + 1, 4);
                    }
                }
                checkSound[i] = ReadAudioFile.bandBuffer[i];
            }
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                checkSound[i] = ReadAudioFile.bandBuffer[i];
            }
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            Save();
        }
    }

    private void Save()
    {
        string json = JsonUtility.ToJson(notes);
        File.WriteAllText("C:/Users/Gebruiker/Desktop/Songs/Data/" + clip.clip.name + ".json", json.ToString());
    }
    private void Load()
    {
        string dataPath = "C:/Users/Gebruiker/Desktop/Songs/Data/" + clip.clip.name + ".json";
        string dataAsJson = File.ReadAllText(dataPath);
        notes = JsonUtility.FromJson<Notes>(dataAsJson);
    }
}

[System.Serializable]
public class Notes
{
    public int wallID;
    public int visualizerID;
    public int groundID;

    public List<int> id;
    public List<float> time;
    public List<Vector2> offset;
    public List<float> angle;
}

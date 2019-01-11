using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private GameObject menuObj;
    [SerializeField] private Text songNameText;
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private LoadBeatSaberFile loadBSFScript;
    [SerializeField] private ObjectPool[] objectPoolScript;
    [SerializeField] private float health;

    void Start()
    {
        menuObj.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (menuObj.activeSelf)
                PauzeGame(false);
            else
                PauzeGame(true);
        }

        songNameText.text = audiosource.clip.name;
    }

    public void PauzeGame(bool _pauze)
    {
        if(_pauze)
        {
            menuObj.SetActive(true);
            loadBSFScript.Pauze(true);
            audiosource.Pause();
            for (int i = 0; i < objectPoolScript.Length; i++)
            {
                for (int o = 0; o < objectPoolScript[i].objects.Count; o++)
                {
                    objectPoolScript[i].objects[o].GetComponent<Note>().Pauze(true);
                }
            }
        }
        else
        {
            menuObj.SetActive(false);
            loadBSFScript.Pauze(false);
            audiosource.Play();
            for (int i = 0; i < objectPoolScript.Length; i++)
            {
                for (int o = 0; o < objectPoolScript[i].objects.Count; o++)
                {
                    objectPoolScript[i].objects[o].GetComponent<Note>().Pauze(false);
                }
            }
        }
    }
}

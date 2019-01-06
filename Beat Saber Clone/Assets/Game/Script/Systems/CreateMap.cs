using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    [SerializeField] private Text playButtonText;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private bool continueMusic;
    [SerializeField] private Slider sliderMusic;

    private float musicTime;

	void Start ()
    {
        sliderMusic.maxValue = audioSource.clip.length;

    }
	
	void Update ()
    {
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
        }
    }

    public void Play()
    {
        continueMusic = !continueMusic;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class ReadAudioFile : MonoBehaviour 
{
    public int mapId;
    AudioSource audioScource;
    public static float[] samples = new float[512];
    public static float[] freqBand = new float[8];
    public static float[] bandBuffer = new float[8];
    private float[] bufferDecrease = new float[8];

    public int musicAmount;
    public MusicMap[] musicMapScript;

    void Start()
    {
        audioScource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!audioScource.isPlaying)
        {
            audioScource.clip = musicMapScript[mapId].audioClips[musicAmount];
            musicAmount += 1;
            audioScource.Play();
        }

        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();

        //Debug.Log(audioScource.clip.samples);
        float samplesAmount = audioScource.clip.samples / 1000 / 50;
        //Debug.Log(samplesAmount);
    }

    void GetSpectrumAudioSource()
    {
        audioScource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void BandBuffer()
    {
        for (int i = 0; i < 8; i++)
        {
            if (freqBand[i] > bandBuffer[i])
            {
                bandBuffer[i] = freqBand[i];
                bufferDecrease[i] = 0.005f;
            }
            if (freqBand[i] < bandBuffer[i])
            {
                bandBuffer[i] -= bufferDecrease[i];
                bufferDecrease[i] *= 1.2f;
            }
        }
    }

    void MakeFrequencyBands()
    {
/*
22050 / 512 = 43hertz per sample

20 - 60 hertz
60 - 250 hertz
250 - 500 hertz
500 - 2000 hertz
2000 - 4000 hertz
4000 - 6000 hertz
6000 - 20000 hertz

0 - 2 = 86 hertz
1 - 4 = 172 hertz - 87-258
2 - 8 = 344 hertz - 259-602
3 - 16 = 688 hertz - 603-1290
4 - 32 = 1376 hertz - 1291-2666
5 - 64 = 2752 hertz - 2667-5418
6 - 128 = 5504 hertz - 5419-10922
7 - 256 = 11008 hertz - 10923-21930
510
*/
        float average = 0;
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }

            average /= count;
            freqBand[i] = average * 10;
        }
    }
}


[System.Serializable]
public struct MusicMap
{
    public AudioClip[] audioClips;
}
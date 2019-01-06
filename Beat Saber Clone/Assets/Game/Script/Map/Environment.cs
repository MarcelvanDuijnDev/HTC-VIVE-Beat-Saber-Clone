using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    private enum Options            { NoWall, Wall1, Wall2, Wall3, Wall4, Wall5};
    private enum AudioVisualizer    { NoVisualizer, Visualizer1 };
    private enum Ground             { NoGround, Ground1, Ground2 };

    [Header("Options")]
    [SerializeField] private Options options;
    [SerializeField] private AudioVisualizer audioVisualizer;
    [SerializeField] private Ground ground;

    [SerializeField] private Color backgroundColor;

    [SerializeField] private float intesity;

    [Header("SetObjects")]
    [SerializeField] private GameObject[] envObj;
    [SerializeField] private GameObject audioVisualizerObj;
    [SerializeField] private GameObject groundObj;
    [SerializeField] private Camera camera;

    float rot1;
    float rot2;
	
	void Update ()
    {
        switch (options)
        {
            case Options.NoWall:
                if(envObj[envObj.Length -1].activeSelf)
                {
                    for (int i = 0; i < envObj.Length; i++)
                    {
                        envObj[i].SetActive(false);
                    }
                }
                break;
            case Options.Wall1:
                if (!envObj[envObj.Length - 1].activeSelf)
                {
                    for (int i = 0; i < envObj.Length; i++)
                    {
                        envObj[i].SetActive(true);
                    }
                }
                for (int i = 0; i < ReadAudioFile.bandBuffer.Length; i++)
                {
                    rot1 += ReadAudioFile.bandBuffer[i] * 0.1f;
                }
                for (int i = 0; i < envObj.Length; i++)
                {
                    envObj[i].transform.rotation = Quaternion.Euler(0, 0, rot1 * (i + 1) * intesity * 0.001f);
                }
                break;
            case Options.Wall2:
                if (!envObj[envObj.Length - 1].activeSelf)
                {
                    for (int i = 0; i < envObj.Length; i++)
                    {
                        envObj[i].SetActive(true);
                    }
                }
                rot2 = 0;
                for (int i = 0; i < ReadAudioFile.bandBuffer.Length; i++)
                {
                    rot2 += ReadAudioFile.bandBuffer[i] * 0.1f;
                }
                for (int i = 0; i < envObj.Length; i++)
                {
                    envObj[i].transform.rotation = Quaternion.Euler(0, 0, rot2 * (i + 1) * intesity * 0.1f);
                }
                break;
            case Options.Wall3:
                if (!envObj[envObj.Length - 1].activeSelf)
                {
                    for (int i = 0; i < envObj.Length; i++)
                    {
                        envObj[i].SetActive(true);
                    }
                }
                for (int i = 0; i < ReadAudioFile.bandBuffer.Length; i++)
                {
                    rot1 += ReadAudioFile.bandBuffer[i] * 0.1f;
                }
                for (int i = 0; i < envObj.Length; i++)
                {
                    if(i % 2 == 0)
                        envObj[i].transform.rotation = Quaternion.Euler(0, 0, rot1 * (i + 1) * intesity * 0.001f);
                    else
                        envObj[i].transform.rotation = Quaternion.Euler(0, 0, -rot1 * (i + -1) * intesity * 0.001f);
                }
                break;
            case Options.Wall4:
                if (!envObj[envObj.Length - 1].activeSelf)
                {
                    for (int i = 0; i < envObj.Length; i++)
                    {
                        envObj[i].SetActive(true);
                    }
                }
                for (int i = 0; i < ReadAudioFile.bandBuffer.Length; i++)
                {
                    rot1 += ReadAudioFile.bandBuffer[i] * 0.1f;
                }
                for (int i = 0; i < envObj.Length; i++)
                {
                    if (i % 2 == 0)
                        envObj[i].transform.rotation = Quaternion.Euler(0, 0, rot1 * (i + 1) * intesity * 0.001f);
                    else
                        envObj[i].transform.rotation = Quaternion.Euler(0, 0, rot1 * (i + 1) * intesity * 0.003f);
                }
                break;
            case Options.Wall5:
                if (!envObj[envObj.Length - 1].activeSelf)
                {
                    for (int i = 0; i < envObj.Length; i++)
                    {
                        envObj[i].SetActive(true);
                    }
                }
                for (int i = 0; i < ReadAudioFile.bandBuffer.Length; i++)
                {
                    rot1 += ReadAudioFile.bandBuffer[i] * 0.1f;
                }
                for (int i = 0; i < envObj.Length; i++)
                {
                    if (i % 2 == 0)
                        envObj[i].transform.rotation = Quaternion.Euler(0, 0, rot1 * (i + 1) * intesity * 0.001f);
                    else
                        envObj[i].transform.rotation = Quaternion.Euler(0, 0, rot1 * (i + 1) * intesity * 0.001f);
                }
                break;
        }
        switch (audioVisualizer)
        {
            case AudioVisualizer.NoVisualizer:
                if(audioVisualizerObj.activeSelf)
                audioVisualizerObj.SetActive(false);
                break;
            case AudioVisualizer.Visualizer1:
                if (!audioVisualizerObj.activeSelf)
                    audioVisualizerObj.SetActive(true);
                break;
        }
        switch (ground)
        {
            case Ground.NoGround:
                if (groundObj.activeSelf)
                    groundObj.SetActive(false);
                break;
            case Ground.Ground1:
                if (!groundObj.activeSelf)
                    groundObj.SetActive(true);
                break;
        }
        if (camera.backgroundColor != backgroundColor)
        {
            camera.backgroundColor = backgroundColor;
        }
    }
}

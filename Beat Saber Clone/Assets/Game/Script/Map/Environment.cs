using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] private int options;
    [SerializeField] private int audioVisualizer;
    [SerializeField] private int ground;

    [SerializeField] private Color backgroundColor;

    [SerializeField] private float intesity;

    [Header("SetObjects")]
    [SerializeField] private GameObject envObjParent;
    [SerializeField] private GameObject audioVisualizerObj;
    [SerializeField] private GameObject groundObj;
    [SerializeField] private Camera camera;

    private GameObject[] envObj;
    private float rot1;
    private float rot2;

    private void Start()
    {
        envObj = new GameObject[envObjParent.transform.childCount];
        for (int i = 0; i < envObjParent.transform.childCount; i++)
        {
            envObj[i] = envObjParent.transform.GetChild(i).gameObject;
        }
    }

    void Update ()
    {
        switch (options)
        {
            case 0:
                if(envObj[envObj.Length -1].activeSelf)
                {
                    for (int i = 0; i < envObj.Length; i++)
                    {
                        envObj[i].SetActive(false);
                    }
                }
                break;
            case 1:
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
            case 2:
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
            case 3:
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
            case 4:
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
            case 5:
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
            case 0:
                if(audioVisualizerObj.activeSelf)
                audioVisualizerObj.SetActive(false);
                break;
            case 1:
                if (!audioVisualizerObj.activeSelf)
                    audioVisualizerObj.SetActive(true);
                break;
        }
        switch (ground)
        {
            case 0:
                if (groundObj.activeSelf)
                    groundObj.SetActive(false);
                break;
            case 1:
                if (!groundObj.activeSelf)
                    groundObj.SetActive(true);
                break;
        }
        if (camera.backgroundColor != backgroundColor)
        {
            camera.backgroundColor = backgroundColor;
        }
    }

    public void SetOptions(int _options, int _audioVis, int _ground)
    {
        options = _options;
        audioVisualizer = _audioVis;
        ground = _ground;
    }
}

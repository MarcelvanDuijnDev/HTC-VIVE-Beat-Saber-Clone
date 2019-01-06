using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizer : MonoBehaviour

{
    public float intensity;
    public GameObject[] obj;

    void Update()
    {
        for (int i = 0; i < 8; i++)
        {
            obj[i].transform.localScale = new Vector3(0.15f,ReadAudioFile.bandBuffer[i] * intensity, 0.15f);
        }
    }
}

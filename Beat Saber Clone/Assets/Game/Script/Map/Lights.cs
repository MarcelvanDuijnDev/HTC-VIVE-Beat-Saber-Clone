using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour 
{
    public float intensity;
    public Light[] lights;

    public bool invertRGB;
	
	void Update () 
    {
        float audioIntensity = 0;
        float audioIntensity_r = ReadAudioFile.bandBuffer[0] + ReadAudioFile.bandBuffer[1];
        float audioIntensity_g = ReadAudioFile.bandBuffer[2] + ReadAudioFile.bandBuffer[3];
        float audioIntensity_b = ReadAudioFile.bandBuffer[4] + ReadAudioFile.bandBuffer[5];
        for (int i = 0; i < 8; i++)
        {
            audioIntensity += ReadAudioFile.bandBuffer[i];
        }
        for (int i = 0; i < lights.Length; i++)
        {
            //Intensity
            lights[i].intensity = audioIntensity *0.2f * intensity;

            //Color
            float r = audioIntensity_r*0.05f;
            float g = audioIntensity_g*0.05f;
            float b = audioIntensity_b*0.05f;
            //Debug.Log("r: " + r + " | " + "g: " + g + " | " + "b: " + b);

            if (!invertRGB)
            {
                lights[i].color = new Color(r, g, b);
            }
            else
            {
                lights[i].color = new Color(b, g, r);
            }
        }
	}
}

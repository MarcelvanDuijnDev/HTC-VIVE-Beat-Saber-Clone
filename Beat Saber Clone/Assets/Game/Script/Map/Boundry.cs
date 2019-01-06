using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundry : MonoBehaviour
{
    [SerializeField]private ScoreHandler scoreHandlerScript;

    void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.tag == "Right" || Other.gameObject.tag == "Left")
        {
            scoreHandlerScript.Miss();
            Other.gameObject.SetActive(false);
        }
    }
}

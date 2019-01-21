using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTCVIVE;

public class InteractWithMenu : MonoBehaviour
{
    [SerializeField] private Transform[] raycastPoint;

    private int controllerID;

	void Update ()
    {
        if (VR.LeftTrigger() || VR.RightTrigger())
        {
            if (VR.LeftTrigger())
                controllerID = 0;
            if (VR.RightTrigger())
                controllerID = 1;

            RaycastHit hit;
            if (Physics.Raycast(raycastPoint[controllerID].position, raycastPoint[controllerID].transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(raycastPoint[controllerID].position, raycastPoint[controllerID].transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

                if (hit.transform.gameObject.tag == "Button")
                {
                    hit.transform.GetComponent<MenuButtons>().MenuSelectSong();
                }
                if (hit.transform.gameObject.tag == "Button1")
                {
                    hit.transform.GetComponent<MenuButtons>().MenuSelectSongDif();
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Saber : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private SteamVR_Action_Vibration haptic;
    [SerializeField] private int saberID;
    [SerializeField] private ScoreHandler scoreHandlerScript;
    [SerializeField] private Transform raycastPoint;

    public SteamVR_Behaviour_Pose pose;

    public GameObject obj;
    private Vector3 rot;
    private float rotZ;

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastPoint.position, transform.TransformDirection(Vector3.forward), out hit, 1))
        {
            Debug.DrawRay(raycastPoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (hit.transform.gameObject.CompareTag("Right") && saberID == 0)
            {
                rot = (new Vector3(hit.point.x,hit.point.y,hit.transform.position.z) - hit.transform.position).normalized;
                Vector3 rotCalc = Quaternion.LookRotation(rot).ToEuler();

                if (rot.x < 0 && rot.y > 0)
                {
                    rotZ = 90 * rot.y;
                }
                if (rot.x > 0 && rot.y > 0)
                {
                    rotZ = (rot.x * 90) + 90;
                }
                if (rot.x > 0 && rot.y < 0)
                {
                    rotZ = (-90 * rot.y) + 180;
                }
                if (rot.x < 0 && rot.y < 0)
                {
                    rotZ = (-90 * rot.x) + 270;
                }
                obj.transform.eulerAngles = new Vector3(0, 0, -rotZ);

                hit.transform.gameObject.SetActive(false);
                haptic.Execute(0, 0.3f, 60, 1f, SteamVR_Input_Sources.RightHand);

                float score = 0;
                float rotx = 0;
                float roty = 0;
                if(rotZ > 180)
                {
                    rotx = rotZ - 180;
                    rotx = 180 - rotx;
                }
                if(hit.transform.eulerAngles.z > 180)
                {
                    roty = rotZ - 180;
                    roty = 180 - roty;
                }
                if(rotx > roty)
                    score = rotx - roty;
                else
                    score = roty - rotx;

                scoreHandlerScript.AddScore(score);
                scoreText.text = score.ToString();
            }
            if (hit.transform.gameObject.CompareTag("Left") && saberID == 1)
            {
                rot = (new Vector3(hit.point.x, hit.point.y, hit.transform.position.z) - hit.transform.position).normalized;
                Vector3 rotCalc = Quaternion.LookRotation(rot).ToEuler();

                if (rot.x < 0 && rot.y > 0)
                {
                    rotZ = 90 * rot.y;
                }
                if (rot.x > 0 && rot.y > 0)
                {
                    rotZ = (rot.x * 90) + 90;
                }
                if (rot.x > 0 && rot.y < 0)
                {
                    rotZ = (-90 * rot.y) + 180;
                }
                if (rot.x < 0 && rot.y < 0)
                {
                    rotZ = (-90 * rot.x) + 270;
                }
                obj.transform.eulerAngles = new Vector3(0, 0, -rotZ);

                scoreHandlerScript.AddScore(100);
                hit.transform.gameObject.SetActive(false);
                haptic.Execute(0, 0.3f, 60, 1f, SteamVR_Input_Sources.LeftHand);
            }
        }
    }

    void OnCollisionStay(Collision Other)
    {
        if (Other.gameObject.tag == "Saber")
        {
            //haptic.Execute(1, 0.5f, 1, 0.5f, SteamVR_Input_Sources.RightHand);
            //haptic.Execute(1, 0.5f, 1, 0.5f, SteamVR_Input_Sources.LeftHand);
        }
    }
}

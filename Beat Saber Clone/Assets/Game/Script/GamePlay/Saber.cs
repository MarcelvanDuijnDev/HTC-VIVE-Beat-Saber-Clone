using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Saber : MonoBehaviour
{
    [Header("Set")]
    [SerializeField] private Text scoreText;
    [SerializeField] private SteamVR_Action_Vibration haptic;
    [SerializeField] private int saberID;
    [SerializeField] private ScoreHandler scoreHandlerScript;
    [SerializeField] private Transform raycastPoint;
    [SerializeField] private ParticleSystem effect;
    [SerializeField] private ParticleSystem effectBlue;
    [SerializeField] private ParticleSystem effectRed;

    [Header("ScoreOptions")]
    [SerializeField] private float hitAngle;

    public SteamVR_Behaviour_Pose pose;

    //public GameObject obj;
    private Vector3 rot;
    private float rotZ;

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastPoint.position, raycastPoint.TransformDirection(Vector3.forward), out hit, 1))
        {
            Debug.DrawRay(raycastPoint.position, raycastPoint.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
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
                //obj.transform.eulerAngles = new Vector3(0, 0, -rotZ);
                effect.transform.eulerAngles = new Vector3(0, 0, 0);
                effect.Play();
                effectBlue.transform.eulerAngles = new Vector3(0, rotZ, 0);
                effectBlue.transform.position = hit.point;
                effectBlue.Play();

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
                effect.Play();
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
                //obj.transform.eulerAngles = new Vector3(0, 0, -rotZ);
                effect.transform.eulerAngles = new Vector3(0, 0, 0);
                effect.Play();
                effectRed.transform.eulerAngles = new Vector3(0, rotZ, 0);
                effectRed.transform.position = hit.point;
                effectRed.Play();

                scoreHandlerScript.AddScore(100);
                hit.transform.gameObject.SetActive(false);
                haptic.Execute(0, 0.3f, 60, 1f, SteamVR_Input_Sources.LeftHand);
            }

            if(hit.transform.gameObject.CompareTag("Bomb"))
            {
                //Lose combo + get damage
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

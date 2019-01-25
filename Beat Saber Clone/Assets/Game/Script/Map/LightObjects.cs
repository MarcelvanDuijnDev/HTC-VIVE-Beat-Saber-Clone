using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObjects : MonoBehaviour
{
    [SerializeField] private Material lightMat;

    [SerializeField] private Animator animator;
	
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            animator.Play("Anim1");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            animator.Play("Anim2");
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            animator.Play("Anim3");
        }



        //lightMat.SetColor("_EmissionColor", color);
        //lightMat.color = new Color(255,255,255,0);
    }

    void Flash()
    {
        
    }
}

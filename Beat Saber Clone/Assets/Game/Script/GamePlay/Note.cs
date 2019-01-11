using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool pauze;

	void FixedUpdate ()
    {
        if(!pauze)
        transform.Translate(0, 0, -speed * Time.deltaTime);
    }

    public void Pauze(bool _pauze)
    {
        pauze = _pauze;
    }
}

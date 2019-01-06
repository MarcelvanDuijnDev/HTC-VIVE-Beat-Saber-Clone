using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private float speed;

	void FixedUpdate ()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime);

    }
}

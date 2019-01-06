using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefabGameObject;
    public int pooledAmount;
    public List<GameObject> objects;

	void Start () 
    {
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(prefabGameObject);
            obj.transform.parent = gameObject.transform;
            obj.SetActive(false);
            objects.Add(obj);
        }
	}
}

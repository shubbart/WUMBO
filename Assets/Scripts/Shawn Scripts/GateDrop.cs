using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDrop : MonoBehaviour
{
    public bool oneKey, twoKeys;
    public float speed;
    public GameObject[] keyTrigger;
    OrbDropOff[] dropOff;
    bool allCompleted = false;

	void Start ()
    {
        dropOff = new OrbDropOff[keyTrigger.Length];

        for(int i = 0; i < keyTrigger.Length; ++i)
        {
            dropOff[i] = keyTrigger[i].GetComponent<OrbDropOff>();
        }
	}
	
	void Update ()
    {
        if (oneKey)
            if (dropOff[0].isCompleted)
                allCompleted = true;

        if (twoKeys)
            if (dropOff[0].isCompleted && dropOff[1].isCompleted)
                allCompleted = true;

        if(allCompleted)
        {
            transform.position -= new Vector3(0, speed, 0);
        }
	}
}

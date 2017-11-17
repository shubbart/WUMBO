using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDrop : MonoBehaviour
{
    public float speed;
    public GameObject keyTrigger;
    OrbDropOff dropOff;

	void Start ()
    {
        dropOff = keyTrigger.GetComponent<OrbDropOff>();
	}
	
	void Update ()
    {
		if(dropOff.isCompleted)
        {
            transform.position -= new Vector3(0, speed, 0);
        }
	}
}

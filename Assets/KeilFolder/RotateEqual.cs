using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEqual : MonoBehaviour {
    public Transform equal;
	// Use this for initialization
	void equator ()
    {
        transform.rotation = equal.transform.rotation;
	}
	
	// Update is called once per frame
	void Update ()
    {
        equator();
	}
}

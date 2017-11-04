using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeilVR : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        if( UnityEngine.VR.VRDevice.SetTrackingSpaceType(UnityEngine.VR.TrackingSpaceType.RoomScale))
        {
            Debug.Log("Roomscale!");
        }
        else
        {
            Debug.Log("Not room scale!");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

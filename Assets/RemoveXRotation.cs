using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveXRotation : MonoBehaviour
{	
	// Update is called once per frame
	void Update ()
    { transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z); }
}

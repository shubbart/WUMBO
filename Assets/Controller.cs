using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class Controller : MonoBehaviour
{
    public VRNode node;


    void Start()
    {
        if(node == VRNode.Head)
        {
            VRDevice.DisableAutoVRCameraTracking(GetComponent<Camera>(), true);
        }
    }

	// Update is called once per frame
	void Update() {

        transform.localPosition = InputTracking.GetLocalPosition(node);
        transform.localRotation = InputTracking.GetLocalRotation(node);

    }
}

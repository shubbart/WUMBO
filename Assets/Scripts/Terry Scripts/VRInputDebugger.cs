using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class VRInputDebugger : MonoBehaviour
{
    public GameObject controllerLeft;
    public NVRHand contLeft;
    public GameObject controllerRight;
    public NVRHand contRight;

    public List<NVRButtons> buttons;

    void Start()
    {
        contLeft = controllerLeft.GetComponent<NVRHand>();
        contRight = controllerRight.GetComponent<NVRHand>();
    }

    // Update is called once per frame
    void LateUpdate ()
    {
        if(contLeft.UseButtonPressed)
        {
            Debug.Log("left pressed: use button");
        }

        if (contRight.UseButtonPressed)
        {
            Debug.Log("right pressed: use button");
        }

    }
}

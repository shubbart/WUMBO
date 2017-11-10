using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrankScript : NewtonVR.NVRInteractable {

    public Rigidbody srb;
    public float speed = 0.1F;

    protected override void Update()
    {
        base.Update();
        if(IsAttached)
        {
            //Vector3 dir = (AttachedHand.transform.position - Rigidbody.transform.position).normalized;
            Rigidbody.transform.LookAt(AttachedHand.transform.position);
            Rigidbody.transform.rotation = Quaternion.Euler(new Vector3(0, Rigidbody.transform.rotation.eulerAngles.y, 0));
           // Vector3 dsiredAngle = new Vector3(0, transform.rotation.y, 0);
            srb.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
        }
    }
}

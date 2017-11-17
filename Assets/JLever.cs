using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JLever : NewtonVR.NVRInteractable {

    public Rigidbody ship;

    float angleX = 0;
    Quaternion prev = Quaternion.identity;

    float speed = 1;

    float leverInput = 0;

    bool flippedRotations = false;

    protected override void Update()
    {
        base.Update();

        UpdateRotation();
        MoveShip();

        //Debug.Log(leverInput);
    }

    public override void AddExternalAngularVelocity(Vector3 angularVelocity)
    {
        //base.AddExternalAngularVelocity(angularVelocity);
    }

    public override void AddExternalVelocity(Vector3 velocity)
    {
        //base.AddExternalVelocity(velocity);
    }

    void UpdateRotation()
    {
        flippedRotations = ((ship.transform.localRotation.eulerAngles.y > 90 && ship.transform.localRotation.eulerAngles.y < 270));
        if (AttachedHand)
        {
            //
            Vector3 dir;
            dir = (new Vector3(0, (AttachedHand.CurrentPosition - transform.position).y, (AttachedHand.CurrentPosition - transform.position).z)).normalized;
            Debug.Log(ship.transform.localRotation.eulerAngles);
            transform.localRotation = Quaternion.LookRotation(dir);
            transform.localRotation *= Quaternion.Euler(90, 0, 0);
            if (transform.localRotation.eulerAngles.z == 0)
            {
                transform.localRotation = Quaternion.Euler(Mathf.Clamp(transform.localRotation.eulerAngles.x, 0, 90), transform.localRotation.eulerAngles.y, 0);
                if (flippedRotations)
                    transform.localRotation = Quaternion.Euler(0, 180, 0) * transform.localRotation;

                prev = transform.localRotation;
            }
            else transform.localRotation = prev;

            bool leverBackwards = (transform.localRotation.eulerAngles.y > 90 && transform.localRotation.eulerAngles.y < 270);
            leverInput = transform.localRotation.eulerAngles.x / 90 * ((leverBackwards && !flippedRotations) || (flippedRotations && leverBackwards) ? -1 : 1);
            //transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, 0, 0);
        }
    }

    //void UpdateRotation()
    //{
    //    if (AttachedHand)
    //    {
    //        //
    //        Quaternion temp;
    //        flippedRotations = ship.transform.localRotation.eulerAngles.y > 90 || ship.transform.localRotation.eulerAngles.y < -90;
    //        Vector3 dir = (new Vector3(0, (AttachedHand.CurrentPosition - transform.position).y, (AttachedHand.CurrentPosition - transform.position).z)).normalized;
    //        Debug.Log(ship.transform.eulerAngles.y);
    //        transform.rotation = Quaternion.LookRotation(dir);
    //        temp = transform.localRotation;
    //        transform.localRotation *= Quaternion.Euler(90, 0, 0);
    //        if (transform.localRotation.eulerAngles.z == 0)
    //        {
    //            transform.localRotation = Quaternion.Euler(Mathf.Clamp(transform.localRotation.eulerAngles.x, 0, 90), transform.localRotation.eulerAngles.y, 0);
    //            //if (flippedRotations)
    //            //    transform.localRotation = Quaternion.Euler(0, 180, 0) * transform.localRotation;

    //            leverInput = transform.localRotation.eulerAngles.x / 90 * ((temp.eulerAngles.y > 0 && !flippedRotations) ? -1 : 1);

    //            prev = transform.localRotation;
    //        }
    //        else transform.localRotation = prev;
    //        Debug.Log(transform.eulerAngles);
    //        //transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, 0, 0);
    //    }
    //}

    void MoveShip()
    {
        ship.AddForce(ship.transform.TransformDirection(new Vector3(0, 0, speed * leverInput)));
    }
}


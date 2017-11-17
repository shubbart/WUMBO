using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float firingForce;
    public GameObject projectile;

    public void Fire()
    {
        GameObject projectilCopy = Instantiate(projectile, transform.position, projectile.transform.rotation) as GameObject;
        Rigidbody rbody = projectilCopy.GetComponent<Rigidbody>();
        rbody.AddForce(transform.forward * firingForce);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public GameObject targetLocation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            targetLocation.GetComponent<Shoot>().Fire();
    }

}

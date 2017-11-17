using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class OrbDropOff : MonoBehaviour
{
    public GameObject dropOffText;
    public GameObject usedOrb;
    GameObject player;
    PlayerManager pManager;

    public GameObject controllerLeft;
    public NVROculusInputDevice contLeft;
    public GameObject controllerRight;
    public NVROculusInputDevice contRight;

    public bool isCompleted;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pManager = player.GetComponent<PlayerManager>();
        contLeft = controllerLeft.GetComponent<NVROculusInputDevice>();
        contRight = controllerRight.GetComponent<NVROculusInputDevice>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ship" && pManager.collectedOrbs > 0 && !isCompleted)
            dropOffText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ship")
            dropOffText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ship" && pManager.collectedOrbs > 0 && contRight.GetPressDown(NVRButtons.Grip) && !isCompleted)
        {
            --pManager.collectedOrbs;
            pManager.orbUI[pManager.collectedOrbs].SetActive(false);
            dropOffText.SetActive(false);
            usedOrb.SetActive(true);
            isCompleted = true;
        }

    }
}

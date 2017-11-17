using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbDropOff : MonoBehaviour
{
    public GameObject dropOffText;
    public GameObject usedOrb;
    GameObject player;
    PlayerManager pManager;

    public bool isCompleted;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pManager = player.GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && pManager.collectedOrbs > 0 && !isCompleted)
            dropOffText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            dropOffText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && pManager.collectedOrbs > 0 && Input.GetKeyUp("x") && !isCompleted)
        {
            --pManager.collectedOrbs;
            pManager.orbUI[pManager.collectedOrbs].SetActive(false);
            dropOffText.SetActive(false);
            usedOrb.SetActive(true);
            isCompleted = true;
        }

    }
}

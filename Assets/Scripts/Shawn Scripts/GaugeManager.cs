using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeManager : MonoBehaviour
{
    public bool frostGauge;
    public bool flameGauge;
    public bool gravityGauge;

    GameObject player;
    PlayerManager pManager;
    Slider gauge;

	// Use this for initialization
	void Start ()
    {
        gauge = GetComponent<Slider>();
        player = GameObject.FindGameObjectWithTag("Player");
        pManager = player.GetComponent<PlayerManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (frostGauge)
            gauge.value = pManager.frostAmmo;
        if (flameGauge)
            gauge.value = pManager.flameAmmo;
        if (gravityGauge)
            gauge.value = pManager.gravityAmmo;
    }
}

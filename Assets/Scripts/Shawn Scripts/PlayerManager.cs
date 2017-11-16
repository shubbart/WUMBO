﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int health;
    public int collectedOrbs;
    public GameObject[] orbUI;

    public bool activeFrost = false;
    public int maxFrostAmmo = 100;
    public int frostAmmo = 100;
    public int frostCost = 5;
    public int frostRecover = 2;
    public float frostRecoverTimer = 2;
    float frostRecoverReset;
    public float frostTick = 1;
    float frostTickReset;

    public bool activeFlame = false;
    public int flameAmmo = 100;
    public int maxFlameAmmo = 100;
    public int flameCost = 5;
    public int flameRecover = 2;
    public float flameRecoverTimer = 2;
    float flameRecoverReset;
    public float flameTick = 1;
    float flameTickReset;

    public bool activeGravity = false;
    public int maxGravityAmmo = 100;
    public int gravityAmmo = 100;
    public int gravityCost = 5;
    public int gravityRecover = 2;
    public float gravityRecoverTimer = 2;
    float gravityRecoverReset;
    public float gravityTick = 1;
    float gravityTickReset;

    void Start ()
    {
        frostTickReset = frostTick;
        frostRecoverReset = frostRecoverTimer;
        flameTickReset = flameTick;
        flameRecoverReset = flameRecoverTimer;
        gravityTickReset = gravityTick;
        gravityRecoverReset = gravityRecoverTimer;
	}
	
	void Update ()
    {
		if(activeFrost && frostAmmo - frostTick >= 0)
        {
            frostTick -= Time.deltaTime;
            if(frostTick <= 0)
            {
                frostAmmo -= frostCost;
                frostTick = frostTickReset;
            }
        }
        else if(!activeFrost && frostAmmo + frostRecover <= maxFrostAmmo)
        {
            frostRecoverTimer -= Time.deltaTime;
            if (frostRecoverTimer <= 0)
            {
                frostAmmo += frostRecover;
                frostRecoverTimer = frostRecoverReset;
            }
        }

        if (activeFlame && flameAmmo - flameTick >= 0)
        {
            flameTick -= Time.deltaTime;
            if (flameTick <= 0)
            {
                flameAmmo -= flameCost;
                flameTick = flameTickReset;
            }
        }
        else if (!activeFlame && flameAmmo + flameRecover <= maxFlameAmmo)
        {
            flameRecoverTimer -= Time.deltaTime;
            if (flameRecoverTimer <= 0)
            {
                flameAmmo += flameRecover;
                flameRecoverTimer = flameRecoverReset;
            }
        }

        if (activeGravity && gravityAmmo - gravityTick >= 0)
        {
            gravityTick -= Time.deltaTime;
            if (gravityTick <= 0)
            {
                gravityAmmo -= gravityCost;
                gravityTick = gravityTickReset;
            }
        }
        else if (!activeGravity && gravityAmmo + gravityRecover <= maxGravityAmmo)
        {
            gravityRecoverTimer -= Time.deltaTime;
            if (gravityRecoverTimer <= 0)
            {
                gravityAmmo += gravityRecover;
                gravityRecoverTimer = gravityRecoverReset;
            }
        }
    }
}

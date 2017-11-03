using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateParticleTimed : MonoBehaviour
{
    public float timer;
    public float timerReset;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timerReset;
            gameObject.SetActive(false);            
        }
    }
}

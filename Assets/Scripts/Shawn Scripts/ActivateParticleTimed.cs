using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateParticleTimed : MonoBehaviour
{
    public float timer;
    float timerReset;
    int resetHealth;
    public ParticleSystem particles;

	void Start ()
    {
        timerReset = timer;
        resetHealth = GetComponent<ObjectHealth>().health;
    }
	
	void Update ()
    {
        timer -= Time.deltaTime;
		if(timer <= 0)
        {
            particles.gameObject.SetActive(true);
            if (GetComponent<ObjectHealth>().isDead)
            {
                GetComponent<ObjectHealth>().health = resetHealth;
                GetComponent<ObjectHealth>().isDead = false;
            }
            timer = timerReset + Random.Range(0,3);
        }
	}
}

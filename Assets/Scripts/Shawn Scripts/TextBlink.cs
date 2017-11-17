using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBlink : MonoBehaviour
{
    public float blinkTimer;
    float timerReset;
    Text myText;

	void Start ()
    {
        timerReset = blinkTimer;
        myText = GetComponent<Text>();
	}
	

	void Update ()
    {
        blinkTimer -= Time.deltaTime;

        if(blinkTimer <= 0)
        {
            myText.enabled = !myText.enabled;
            blinkTimer = timerReset;
        }
		
	}
}

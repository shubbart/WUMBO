using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOrbController : MonoBehaviour
{
    //public float rotationTimer;
    //float timerReset;
    public Vector3 minRotationSpeed;
    public Vector3 maxRotationSpeed;
    Vector3 randomRotation;

    void Start ()
    {
        //timerReset = rotationTimer;
        randomRotation = new Vector3(Random.Range(minRotationSpeed.x, maxRotationSpeed.x),
                            Random.Range(minRotationSpeed.y, maxRotationSpeed.y),
                            Random.Range(minRotationSpeed.z, maxRotationSpeed.z));
    }
	
	void Update ()
    {

        //rotationTimer -= Time.deltaTime;

        //if (rotationTimer <= 0)
        //{
        //    randomRotation = new Vector3(Random.Range(minRotationSpeed.x, maxRotationSpeed.x),
        //                                Random.Range(minRotationSpeed.y, maxRotationSpeed.y),
        //                                Random.Range(minRotationSpeed.z, maxRotationSpeed.z));
        //    rotationTimer = timerReset;
        //}
        transform.Rotate(randomRotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOrbController : MonoBehaviour
{
    public Vector3 minRotationSpeed;
    public Vector3 maxRotationSpeed;
    public GameObject gravityAura;
    Vector3 randomRotation;

    void Start ()
    {
        randomRotation = new Vector3(Random.Range(minRotationSpeed.x, maxRotationSpeed.x),
                            Random.Range(minRotationSpeed.y, maxRotationSpeed.y),
                            Random.Range(minRotationSpeed.z, maxRotationSpeed.z));
    }
	
	void Update ()
    {
        transform.Rotate(randomRotation);
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Gravitygun")
        {
            gravityAura.SetActive(true);
        }
    }
}

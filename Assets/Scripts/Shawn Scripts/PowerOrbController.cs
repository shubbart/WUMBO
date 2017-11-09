using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOrbController : MonoBehaviour
{
    public float speed;
    public Vector3 minRotationSpeed;
    public Vector3 maxRotationSpeed;
    public GameObject gravityAura;
    Vector3 randomRotation;
    Rigidbody rbody;

    GameObject player;
    PlayerManager pManager;
    Vector3 dir;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pManager = player.GetComponent<PlayerManager>();
        rbody = GetComponent<Rigidbody>();
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
            dir = -(transform.position - player.transform.position).normalized;
            rbody.AddForce(new Vector3(speed * dir.x, speed * dir.y, speed * dir.z));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ++pManager.collectedOrbs;
            Destroy(gameObject);
        }
    }
}

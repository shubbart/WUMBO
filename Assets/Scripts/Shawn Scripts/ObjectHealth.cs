using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    public int health;

	void Update ()
    {
        if (health <= 0)
            Die();
	}

    void Die()
    {
        Destroy(gameObject);
    }
}

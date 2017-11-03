using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    public int health;
    public bool isDead;
    public enum typeOfDeath
    {
        Steam,
        Vine
    }

    public typeOfDeath deathState;

    void Update ()
    {
        if (health <= 0 && !isDead)
            switch(deathState)
            {
                case typeOfDeath.Steam:
                    steamDeath();
                    break;
                case typeOfDeath.Vine:
                    vineDeath();
                    break;
            }
	}

    void steamDeath()
    {
        GetComponent<ActivateParticleTimed>().timer = 15;
        isDead = true;
    }

    void vineDeath()
    {
        Destroy(gameObject);
    }
}

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
        Vine,
        Ice
    }

    public typeOfDeath deathState;

    void Update()
    {
        if (health <= 0 && !isDead)
            switch (deathState)
            {
                case typeOfDeath.Steam:
                    steamDeath();
                    break;
                case typeOfDeath.Vine:
                    vineDeath();
                    break;
                case typeOfDeath.Ice:
                    steamDeath();
                    break;
            }

        if (health < 100 && health > 0)
        {
            switch (deathState)
            { 
                case typeOfDeath.Ice:
                    iceMelt();
                    break;
            }
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

    void iceMelt()
    {
        if(transform.localScale.x > 0)
        transform.localScale -= new Vector3(1, 1 , 1 ) * .15f * Time.deltaTime;
        if(transform.localScale.x <= .05)
            Destroy(gameObject);
    }
}

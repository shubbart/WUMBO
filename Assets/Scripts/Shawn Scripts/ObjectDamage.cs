using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDamage : MonoBehaviour
{
    public bool flammable;
    public bool freezable;

    private void OnParticleCollision(GameObject other)
    {
        if (flammable && other.name == "FlameGunParticles")
            GetComponent<ObjectHealth>().health -= other.GetComponent<WeaponDamage>().damage;
        if (freezable && other.name == "FreezeGunParticles")
            GetComponent<ObjectHealth>().health -= other.GetComponent<WeaponDamage>().damage;
    }
}

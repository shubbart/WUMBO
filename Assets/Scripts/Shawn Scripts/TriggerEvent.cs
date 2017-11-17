using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public GameObject[] targetLocation;
    public float delay;
    public bool shooting = false;
    //GameObject currentTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !shooting)
        {
            Invoke("DoShoot1", delay);
            shooting = true;
        }
    }

    void DoShoot1()
    {
        if (shooting)
        {
            targetLocation[0].GetComponent<Shoot>().Fire();
            if (targetLocation.Length > 1)
                Invoke("DoShoot2", delay);
            else
                shooting = false;
        }
    }
    void DoShoot2()
    {
        if (shooting)
        {
            targetLocation[1].GetComponent<Shoot>().Fire();
            if (targetLocation.Length > 2)
                Invoke("DoShoot3", delay);
            else
                shooting = false;
        }
    }
    void DoShoot3()
    {
        if (shooting)
        {
            targetLocation[2].GetComponent<Shoot>().Fire();
            if (targetLocation.Length > 3)
                Invoke("DoShoot4", delay);
            else
                shooting = false;
        }
    }
    void DoShoot4()
    {
        if (shooting)
        {
            targetLocation[3].GetComponent<Shoot>().Fire();
            if (targetLocation.Length > 4)
                Invoke("DoShoot5", delay);
            else
                shooting = false;
        }
    }
    void DoShoot5()
    {
        if (shooting)
        {
            targetLocation[4].GetComponent<Shoot>().Fire();
            if (targetLocation.Length > 5)
                Invoke("DoShoot6", delay);
            else
                shooting = false;
        }
    }
    void DoShoot6()
    {
        if (shooting)
        {
            targetLocation[5].GetComponent<Shoot>().Fire();
            if (targetLocation.Length > 6)
                Invoke("DoShoot7", delay);
            else
                shooting = false;
        }
    }
    void DoShoot7()
    {
        if (shooting)
        {
            targetLocation[6].GetComponent<Shoot>().Fire();
            if (targetLocation.Length > 7)
                Invoke("DoShoot8", delay);
            else
                shooting = false;
        }
    }
    void DoShoot8()
    {
        if (shooting)
        {
            targetLocation[7].GetComponent<Shoot>().Fire();
            if (targetLocation.Length > 8)
                Invoke("DoShoot9", delay);
            else
                shooting = false;
        }
    }
    void DoShoot9()
    {
        if (shooting)
        {
            targetLocation[8].GetComponent<Shoot>().Fire();
            if (targetLocation.Length > 9)
                Invoke("DoShoot10", delay);
            else
                shooting = false;
        }
    }
    void DoShoot10()
    {
        if (shooting)
        {
            targetLocation[9].GetComponent<Shoot>().Fire();
        }
        shooting = false;
    }

}

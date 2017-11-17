using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageToPlayer : MonoBehaviour
{
    public int damage;
    GameObject player;
    PlayerManager pManager;
    GameObject damageText;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pManager = player.GetComponent<PlayerManager>();
        damageText = GameObject.FindGameObjectWithTag("DamageText");
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ship")
        {
            pManager.health -= damage;
            damageText.GetComponent<DamageText>().SetDamage();
            Destroy(gameObject);
        }
    }
}

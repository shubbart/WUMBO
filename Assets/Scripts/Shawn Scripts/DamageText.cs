using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    Text damage;
    GameObject player;
    PlayerManager pManager;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pManager = player.GetComponent<PlayerManager>();
        damage = GetComponent<Text>();

        damage.text = "Damage: " + (100 - pManager.health) + "%";
	}
	
	public void SetDamage ()
    {
        damage.text = "Damage: " + (100 - pManager.health) + "%";
    }
}

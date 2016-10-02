using UnityEngine;
using System.Collections;

public class HurtPlayerWithEnemy : MonoBehaviour {

	public int enemyDamageToGive;

	public GameObject hurtParticle;

	private PlayerController player;

	void Start () 
	{
		player = FindObjectOfType<PlayerController>();
	}

	void Update () 
	{

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			HealthManager.HurtPlayerWithEnemy (enemyDamageToGive);
			Instantiate (hurtParticle, player.transform.position, player.transform.rotation);
		}
	}
}

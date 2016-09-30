using UnityEngine;
using System.Collections;

public class HurtPlayerWithEnemy : MonoBehaviour {

	public int enemyDamageToGive;

	void Start () 
	{

	}

	void Update () 
	{

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			HealthManager.HurtPlayerWithEnemy (enemyDamageToGive);
		}
	}
}

using UnityEngine;
using System.Collections;

public class HurtPlayerOnContact : MonoBehaviour {

	public int damageToGive;

	public GameObject hurtParticle;


	private PlayerController player;

	void Start () 
	{
		//player = FindObjectOfType<PlayerController>();
	}

	void Update () 
	{
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			HealthManager.HurtPlayer (damageToGive);

			var player = other.gameObject.GetComponent<PlayerController> (); 
			player.knockbackCount = player.knockbakLenght; 

			if (other.gameObject.transform.position.x > transform.position.x)
				player.knockFromRight = true;
			else if (other.gameObject.transform.position.x < transform.position.x)
				player.knockFromRight = false;

			Instantiate (hurtParticle, player.transform.position, player.transform.rotation);
		}
	}
}

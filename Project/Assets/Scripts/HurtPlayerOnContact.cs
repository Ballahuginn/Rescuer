using UnityEngine;
using System.Collections;

public class HurtPlayerOnContact : MonoBehaviour {

	public int damageToGive;

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
		if (other.name == "Player")
		{
			HealthManager.HurtPlayer (damageToGive);

			var player = other.GetComponent<PlayerController> (); 
			player.knockbackCount = player.knockbakLenght; 

			//if (other.transform.position.x < transform.position.x)
			if (Input.GetKey("right"))
				player.knockFromRight = true;
			else if (Input.GetKey("left"))
				player.knockFromRight = false;

			Instantiate (hurtParticle, player.transform.position, player.transform.rotation);
		}
	}
}

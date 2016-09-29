using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

    public LevelManager levelManager;

	public static bool deadTarget;

	public GameObject deathParticle;

	private PlayerController player;

	void Start ()
	{
		player = FindObjectOfType<PlayerController>();
        levelManager = FindObjectOfType<LevelManager>();
		deadTarget = false;
	}
	
	void Update ()
    {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.tag == "Player")
        {
            levelManager.RespawnPlayer();
        }
		if (other.tag == "Target")
		{
			Instantiate (deathParticle, player.transform.position, player.transform.rotation);
			PlayerController.SpriteSet("targetIsDead", true);
			deadTarget = true;
		}
    }
}

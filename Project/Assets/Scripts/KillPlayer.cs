using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

    public LevelManager levelManager;

	public static bool deadTarget;

	public GameObject deathParticle;

	private PlayerController player;
	private GameObject targetCollider;

	void Start ()
	{
		player = FindObjectOfType<PlayerController>();
        levelManager = FindObjectOfType<LevelManager>();
		deadTarget = false;
		targetCollider = player.transform.FindChild ("Target Collider").gameObject;
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
			targetCollider.SetActive (false);
		}
    }
}

using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

    public LevelManager levelManager;

	//private PlayerController playerController;

	void Start ()
    {
        levelManager = FindObjectOfType<LevelManager>();
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
			PlayerController.SpriteSet("targetIsDead", true);
		}
    }
}

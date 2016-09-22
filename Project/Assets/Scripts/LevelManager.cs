using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    public GameObject deathParticle;
    public float respawnDelay;

    private PlayerController player;

    void Start ()
    {
        player = FindObjectOfType<PlayerController>();
    }
	
	void Update ()
    {
	    
	}

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo ()
    {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);

        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        player.GetComponent<BoxCollider2D>().enabled = false;
        player.rb.velocity = Vector2.zero;

        yield return new WaitForSeconds(respawnDelay);

        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.transform.position = currentCheckpoint.transform.position;
		player.soundWasPlayed = false;
    }
}

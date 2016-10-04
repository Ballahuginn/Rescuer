using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    public GameObject deathParticle;
    public float respawnDelay;

	public HealthManager healthManager;

    private PlayerController player;
	//private GameObject targetCollider;

    void Start ()
    {
        player = FindObjectOfType<PlayerController>();
		healthManager = FindObjectOfType<HealthManager> ();
		PlayerPrefs.SetString("LastActiveScene", SceneManager.GetActiveScene().name);
		//targetCollider = player.transform.FindChild ("Target Collider").gameObject;
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
        player.rb.velocity = Vector2.zero;

        yield return new WaitForSeconds(respawnDelay);

		player.knockbackCount = 0;
		player.transform.position = currentCheckpoint.transform.position;
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
		healthManager.FullHealth ();
		healthManager.isDead = false; 
		player.soundWasPlayed = false;
		PlayerController.SpriteSet ("targetIsDead", false);
		KillPlayer.deadTarget = false;
		//targetCollider.SetActive (true);
	}
}

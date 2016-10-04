using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	private bool playerInZone;

	public string levelToLoad;
	public string levelTag;

	void Start () 
	{
		Scene scene = SceneManager.GetActiveScene ();
		playerInZone = false;
	}

	void Update () 
	{
		if (playerInZone)
		{
			LoadLevel ();
		}
	}

	public void LoadLevel()
	{
		PlayerPrefs.SetInt (levelTag, 1);
		Application.LoadLevel (levelToLoad);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			playerInZone = true;
			PlayerPrefs.SetInt (SceneManager.GetActiveScene ().name + "_done", 1); 
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			playerInZone = false;
		}
	}
}

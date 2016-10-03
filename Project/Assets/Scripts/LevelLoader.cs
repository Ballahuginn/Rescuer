using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	private bool playerInZone;

	public string levelToLoad;
	public string levelTag;

	void Start () 
	{
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

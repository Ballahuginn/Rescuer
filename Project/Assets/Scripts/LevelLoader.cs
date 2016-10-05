using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	private bool playerInZone;
	private string levelNumber;

	public string levelToLoad;
	//public string levelTag;

	void Start () 
	{
		playerInZone = false;
		PlayerPrefs.SetInt ("Level_0", 1);
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
		//PlayerPrefs.SetInt (levelTag, 1);
        SceneManager.LoadScene(levelToLoad);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		for (int i = 0; i < NewLevelSelectManager.numberOfLevels; i++)
		{
			levelNumber = "Level_" + i;
			if(levelNumber.Equals(SceneManager.GetActiveScene().name))
			{
				int j = i + 1;
				PlayerPrefs.SetInt ("Level_" + j, 1);
			}
		}

		if (other.tag == "Player")
		{
			playerInZone = true;
			PlayerPrefs.SetInt (SceneManager.GetActiveScene ().name + "_done", 1); 
		}

		if (PlayerPrefs.GetInt("WithTarget") == 1)
		{
			PlayerPrefs.SetInt (SceneManager.GetActiveScene ().name + "_target", 1);
		}

        if (HealthManager.playerHealth == 3)
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_fullhealth", 1);
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

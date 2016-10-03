using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string levelSelect;
	public string level0Tag;

	public void NewGame()
	{
		Application.LoadLevel (startLevel);
		PlayerPrefs.SetInt (level0Tag, 1);
		PlayerPrefs.SetInt ("PlayerLevelSelectPosition", 0);
		//SceneManager.LoadScene (startLevel);
	}

	public void LevelSelect()
	{
		Application.LoadLevel (levelSelect);
		PlayerPrefs.SetInt (level0Tag, 1);

		if (!PlayerPrefs.HasKey("PlayerLevelSelectPosition"))
		{
			PlayerPrefs.SetInt ("PlayerLevelSelectPosition", 0);
		}
	}

	public void QuitGame()
	{
		Application.Quit ();
	}
}

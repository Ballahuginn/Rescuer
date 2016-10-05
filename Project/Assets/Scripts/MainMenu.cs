using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
//using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string levelSelect;
	public string level0Tag;

	public GameObject warningCanvas;
	public GameObject mainMenu;
	public Button contButton;

	void Start()
	{
		//Button contButton = mainMenu.GetComponentInChildren<Button> ();
		if (PlayerPrefs.GetInt("HaveNewGame") == 1)
		{
			contButton.interactable = true;
		}
		else
		{
			contButton.interactable = false;
		}
	}

	void Update()
	{
		
	}

	public void NewGame()
	{
		PlayerPrefs.SetInt (level0Tag, 1);
		PlayerPrefs.SetInt ("PlayerLevelSelectPosition", 0);
		if (PlayerPrefs.GetInt("HaveNewGame") != 1)
		{
			warningCanvas.SetActive(false);
			Application.LoadLevel (startLevel);
		}
		else
		{
			warningCanvas.SetActive(true);
		}
		//PlayerPrefs.DeleteAll ();
		//SceneManager.LoadScene (startLevel);
	}

	public void ContGame()
	{
		SceneManager.LoadScene (PlayerPrefs.GetString ("LastActiveScene"));
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

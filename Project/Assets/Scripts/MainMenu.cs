using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string levelSelect;

	public GameObject warningCanvas;
	public GameObject mainMenu;
	public Button contButton;

	void Start()
	{
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
		if (PlayerPrefs.GetInt("HaveNewGame") != 1)
		{
			warningCanvas.SetActive(false);
            SceneManager.LoadScene(startLevel);
		}
		else
		{
			warningCanvas.SetActive(true);
		}
	}

	public void ContGame()
	{
		SceneManager.LoadScene (PlayerPrefs.GetString ("LastActiveScene"));
	}

	public void LevelSelect()
	{
        SceneManager.LoadScene(levelSelect);
	}

	public void QuitGame()
	{
		Application.Quit ();
        //PlayerPrefs.DeleteAll();
	}
}

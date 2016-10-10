using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class NewLevelSelectManager : MonoBehaviour {

	public GameObject levelButton;
	public Transform spacer;
	public List<Level> levelList;

	public static int numberOfLevels;

	[System.Serializable]
	public class Level
	{
		public string levelText;
		public int unLocked;
		public bool isInteractable;
	}

	void Start () 
	{
		numberOfLevels = 0;
		FillList ();
	}

	void FillList()
	{
		foreach(var level in levelList)
		{
			GameObject newButton = Instantiate (levelButton) as GameObject;

			LevelSelectButton button = newButton.GetComponent<LevelSelectButton > ();

			button.levelText.text = level.levelText;

			if (PlayerPrefs.GetInt("Level_" + button.levelText.text) == 1)
			{
				level.unLocked = 1;
				level.isInteractable = true;
			}

			button.unlocked = level.unLocked;
			button.GetComponent<Button> ().interactable = level.isInteractable;
			button.GetComponent<Button> ().onClick.AddListener (() => LoadLevels ("Level_" + button.levelText.text));

			if (PlayerPrefs.GetInt("Level_" + button.levelText.text + "_done") == 1)
			{
				button.Star1.SetActive (true);
			}
			if (PlayerPrefs.GetInt("Level_" + button.levelText.text + "_target") == 1)
			{
				button.Star2.SetActive (true);
			}
            if (PlayerPrefs.GetInt("Level_" + button.levelText.text + "_fullhealth") == 1)
            {
                button.Star3.SetActive (true);
            }

			newButton.transform.SetParent (spacer);
			numberOfLevels = numberOfLevels + 1;
		}
		SaveAll ();
	}

	void SaveAll()
	{
		GameObject[] allButtons = GameObject.FindGameObjectsWithTag ("LevelButton");
		foreach (GameObject buttons in allButtons) 
		{
			LevelSelectButton button = buttons.GetComponent<LevelSelectButton> ();
			PlayerPrefs.SetInt ("Level_" + button.levelText.text, button.unlocked);
		}
	}

	void LoadLevels(string value)
	{
        SceneManager.LoadScene(value);
	}

	public void MainMenu ()
	{
		SceneManager.LoadScene ("Main Menu");
	}

	void DeleteAll()
	{
		PlayerPrefs.DeleteAll (); 
	}
}

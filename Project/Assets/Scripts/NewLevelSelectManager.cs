using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class NewLevelSelectManager : MonoBehaviour {

	public GameObject levelButton;
	public Transform spacer;
	public List<Level> levelList;

	[System.Serializable]
	public class Level
	{
		public string levelText;
		public int unLocked;
		public bool isInteractable;

		//public Button.ButtonClickedEvent onClickEvet;
	}

	void Start () 
	{
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

			newButton.transform.SetParent (spacer);
		}
		SaveAll ();
	}

	void SaveAll()
	{
//		if (PlayerPrefs.HasKey ("Level1")) {
//			return;
//		} 
//		else 
//		{
			GameObject[] allButtons = GameObject.FindGameObjectsWithTag ("LevelButton");
			foreach (GameObject buttons in allButtons) 
			{
				LevelSelectButton button = buttons.GetComponent<LevelSelectButton> ();
				PlayerPrefs.SetInt ("Level_" + button.levelText.text, button.unlocked);
			}
		//}
	}

	void LoadLevels(string value)
	{
		Application.LoadLevel (value);
	}

	void DeleteAll()
	{
		PlayerPrefs.DeleteAll (); 
	}
}

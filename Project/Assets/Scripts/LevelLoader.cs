using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System;

public class LevelLoader : MonoBehaviour {

	private string levelNumber;
    private string[] levelName;
    private int levelNumberForText;
    //private int j;

    public string mainMenu;
    public string levelToLoad;

    public GameObject levelComplete;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public Text levelNameText;

	void Start () 
	{
		PlayerPrefs.SetInt ("Level_0", 1);
        levelName = SceneManager.GetActiveScene().name.Split('_');
	}

	void OnTriggerEnter2D(Collider2D other)
	{
        /*
		for (int i = 0; i < NewLevelSelectManager.numberOfLevels; i++)
		{
			levelNumber = "Level_" + i;
			if(levelNumber.Equals(SceneManager.GetActiveScene().name))
			{
                levelNumberForText = i;
                int j = i + 1;
                PlayerPrefs.SetInt ("Level_" + j, 1);
			}
		}
        */
        levelNumberForText = Convert.ToInt32(levelName[1]);
        levelNumberForText = levelNumberForText + 1;
        PlayerPrefs.SetInt("Level_" + levelNumberForText, 1);

        levelComplete.SetActive(true);
        levelNameText.text = "You have completed Level " + levelName[1] + "!";
        //Time.timeScale = 0;

        if (other.tag == "Rope")
		{
			PlayerPrefs.SetInt (SceneManager.GetActiveScene ().name + "_done", 1);
            star1.SetActive(true);
		}

		if (other.tag == "Target")
		{
			PlayerPrefs.SetInt (SceneManager.GetActiveScene ().name + "_target", 1);
            star2.SetActive(true);
		}

        if (HealthManager.playerHealth == 3)
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_fullhealth", 1);
            star3.SetActive(true);
        }
	}

    public void NextLevel()
    {
        TurnOffWinCanvas();
        SceneManager.LoadScene(levelToLoad);
    }

    public void MainMenu()
    {
        TurnOffWinCanvas();
        SceneManager.LoadScene(mainMenu);
    }

    public void LevelRestart()
    {
        TurnOffWinCanvas();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void TurnOffWinCanvas ()
    {
        levelComplete.SetActive(false);
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        //Time.timeScale = 1;
    }
}

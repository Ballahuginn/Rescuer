using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System;

public class LevelLoader : MonoBehaviour {

	private string levelNumber;
    private string[] levelName;
    private int levelNumberForText;
	private bool pauseIsOn;
	private bool paused;
	private bool annotationIsOn;
	private bool levelEndIsOn;

    public string mainMenu;
    public string levelToLoad;
	public string levelSelect;

	public GameObject pauseMenuCanvas;

	public GameObject annotationMenuCanvas;
	public GameObject annotationMenuCanvas2;

    public GameObject levelComplete;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public Text levelNameText;

	void Start () 
	{
		PlayerPrefs.SetInt ("Level_0", 1);
        levelName = SceneManager.GetActiveScene().name.Split('_');
		paused = false;
		pauseIsOn = false;
		levelEndIsOn = false;

		if (PlayerPrefs.GetInt("HaveNewGame") != 1)
		{
			paused = true;
			annotationMenuCanvas.SetActive (true);
			annotationIsOn = true;

		}
		else
		{
			paused = false;
			annotationMenuCanvas.SetActive (false);
			annotationIsOn = false;
		}
	}

	void Update()
	{
		if (paused)
		{
			Time.timeScale = 0;
		}

		if (!paused)
		{
			Time.timeScale = 1;
		}

		if (Input.GetKeyDown(KeyCode.Escape) && !annotationIsOn && !levelEndIsOn)
		{
			paused = !paused;
			pauseIsOn = !pauseIsOn;
		}
		else if (Input.GetKeyDown(KeyCode.Escape) && (annotationIsOn || levelEndIsOn))
		{
			pauseIsOn = !pauseIsOn;
		}

		if (pauseIsOn)
		{
			pauseMenuCanvas.SetActive (true);
		}
		else if (!pauseIsOn)
		{
			pauseMenuCanvas.SetActive (false);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			paused = true;
			levelEndIsOn = true;
			levelNumberForText = Convert.ToInt32(levelName[1]);
			levelNumberForText = levelNumberForText + 1;
			PlayerPrefs.SetInt("Level_" + levelNumberForText, 1);

			levelComplete.SetActive(true);
			levelNameText.text = "You have completed Level " + levelName[1] + "!";

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

	public void Resume ()
	{
		paused = false;
	}

	public void LevelSelect ()
	{
		SceneManager.LoadScene(levelSelect);
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

	public void NextCanvas()
	{
		annotationMenuCanvas.SetActive (false);
		annotationMenuCanvas2.SetActive (true);
	}

	public void CloseCanvas ()
	{
		paused = false;
		annotationIsOn = false;
		annotationMenuCanvas2.SetActive (false);
		PlayerPrefs.SetInt("HaveNewGame", 1);
	}

    void TurnOffWinCanvas ()
    {
        levelComplete.SetActive(false);
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
		paused = false;
		levelEndIsOn = false;
    }
}

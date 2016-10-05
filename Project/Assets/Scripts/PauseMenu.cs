using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public string levelSelect;
	public string mainMenu;

	public bool paused;

	public GameObject pauseMenuCanvas;

	void Start()
	{
		paused = false;
	}

	void Update () 
	{
		if (paused)
		{
			pauseMenuCanvas.SetActive (true);
			Time.timeScale = 0;
		}
		else if (!paused)
		{
			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1;
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			paused = !paused;
		}
	}

	public void Resume ()
	{
		paused = false;
	}

	public void LevelSelect()
	{
        SceneManager.LoadScene(levelSelect);
	}

	public void MainMenu  ()
	{
        SceneManager.LoadScene(mainMenu);
	}
}

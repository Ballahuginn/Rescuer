using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public string levelSelect;
	public string mainMenu;

	public bool paused;

	public GameObject pauseMenuCanvas;

	void Start()
	{
		//annotationMenu = FindObjectOfType<AnnotationMenu> ();
		//annotationMenu.enabled (false);
		paused = false;
		//AnnotationMenu.isPaused = false;
	}

	void Update () 
	{
		if (paused)
		{
			pauseMenuCanvas.SetActive (true);
			//AnnotationMenu.isPaused = true;
			Time.timeScale = 0;
		}
		//else if (AnnotationMenu.isPaused && )
		else if (!paused)
		{
			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1;
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			//AnnotationMenu.isPaused = !AnnotationMenu.isPaused;
			paused = !paused;
		}
	}

	public void Resume ()
	{
		paused = false;
		//AnnotationMenu.isPaused = false;
	}

	public void LevelSelect()
	{
		Application.LoadLevel (levelSelect);
	}

	public void MainMenu  ()
	{
		Application.LoadLevel (mainMenu);
	}
}

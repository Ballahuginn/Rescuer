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
		if (AnnotationMenu.isPaused == true && paused)
		{
			pauseMenuCanvas.SetActive (true);
			Time.timeScale = 0;
		}
        else if (AnnotationMenu.isPaused == false && paused)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        else if (AnnotationMenu.isPaused == false && !paused)
		{
			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1;
		}
        else if (AnnotationMenu.isPaused == true && !paused)
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
		{
            //AnnotationMenu.isPaused = !AnnotationMenu.isPaused;
            paused = !paused;
		}
	}

	public void Resume ()
	{
		AnnotationMenu.isPaused = false;
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

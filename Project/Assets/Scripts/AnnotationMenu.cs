using UnityEngine;
using System.Collections;

public class AnnotationMenu : MonoBehaviour {

	public static bool isPaused;

	public GameObject annotationMenuCanvas;
	public GameObject annotationMenuCanvas2;
    public GameObject annotation;

    void Start () 
	{
		if (PlayerPrefs.GetInt("HaveNewGame") != 1)
		{
			isPaused = true;
			annotationMenuCanvas.SetActive (true);
			
		}
		else
		{
			isPaused = false;
			annotationMenuCanvas.SetActive (false);	
		}

	}

	void Update ()
	{
		if (isPaused)
		{
			Time.timeScale = 0f;
		}
		else if (!isPaused)
		{
			annotationMenuCanvas2.SetActive (false);
			Time.timeScale = 1f;
		}
	}

	public void NextCanvas()
	{
		annotationMenuCanvas.SetActive (false);
		annotationMenuCanvas2.SetActive (true);
	}

	public void Resume ()
	{
		isPaused = false;
        annotation.SetActive(false);
        PlayerPrefs.SetInt("HaveNewGame", 1);
    }
}


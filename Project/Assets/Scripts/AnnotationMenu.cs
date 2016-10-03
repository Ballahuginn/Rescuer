using UnityEngine;
using System.Collections;

public class AnnotationMenu : MonoBehaviour {

	public bool isPaused;

	public GameObject annotationMenuCanvas;

	void Start () 
	{
		isPaused = true;
	}

	void Update ()
	{
		if (isPaused)
		{
			annotationMenuCanvas.SetActive (true);
			Time.timeScale = 0f;
		}
		else if (!isPaused)
		{
			annotationMenuCanvas.SetActive (false);
			Time.timeScale = 1f;
		}
	}

	public void Resume ()
	{
		isPaused = false;
	}
}


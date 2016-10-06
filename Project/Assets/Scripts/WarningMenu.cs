using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WarningMenu : MonoBehaviour {

	public string startLevel;

	public GameObject warningCanvas;

	void Start () {
	
	}

	void Update () {
	
	}

	public void YesNewGame()
	{
		PlayerPrefs.DeleteAll ();
        SceneManager.LoadScene(startLevel);
	}

	public void NoGoBack()
	{
		warningCanvas.SetActive (false);
	}
}

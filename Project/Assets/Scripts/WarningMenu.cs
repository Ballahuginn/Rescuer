using UnityEngine;
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
		Application.LoadLevel (startLevel);
	}

	public void NoGoBack()
	{
		warningCanvas.SetActive (false);
	}
}

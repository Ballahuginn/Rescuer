using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
    
    public LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Update ()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.tag == "Player")
        {
            levelManager.currentCheckpoint = gameObject;
            //Debug.Log("Activated Checkpoint " + transform.position);
        }
    }
}

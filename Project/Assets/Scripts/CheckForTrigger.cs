using UnityEngine;
using System.Collections;

public class CheckForTrigger : MonoBehaviour {

    public static bool wasTriggered;

	private AudioSource audioS;

	private float delay;

	void Start()
	{
		audioS = GetComponent<AudioSource> ();
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.name == "Player")
        {
            wasTriggered = true;
            audioS.Play();
        }
    }

    void OnTriggerStay2D (Collider2D other)
    {
		
        if (PlayerController.grounded == false && PlayerController.wasGrounded)
            Destroy(gameObject);
    }
}

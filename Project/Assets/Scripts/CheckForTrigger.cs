using UnityEngine;
using System.Collections;

public class CheckForTrigger : MonoBehaviour {

    public static bool wasTriggered;

	private AudioSource audio;
	private float delay;

	void Start()
	{
		audio = GetComponent<AudioSource> ();
		delay = 0.3f;
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.name == "Player")
            wasTriggered = true;
		audio.PlayDelayed (delay);
    }

    void OnTriggerStay2D (Collider2D other)
    {
		
        if (PlayerController.grounded == false && PlayerController.wasGrounded)
            Destroy(gameObject);
    }
}

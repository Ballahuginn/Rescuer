using UnityEngine;
using System.Collections;

public class CheckForTrigger : MonoBehaviour {

    public static bool wasTriggered;

	private AudioSource audioS;

	private float delay;

	void Start()
	{
		audioS = GetComponent<AudioSource> ();
		delay = 0.2f;
	}

    void OnTriggerEnter2D (Collider2D other)
    {
		if (other.tag == "Player")
            wasTriggered = true;
		audioS.PlayDelayed (delay);
    }

    void OnTriggerStay2D (Collider2D other)
    {
		
        if (PlayerController.grounded == false && PlayerController.wasGrounded)
            Destroy(gameObject);
    }
}

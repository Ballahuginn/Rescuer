using UnityEngine;
using System.Collections;

public class CheckForTrigger : MonoBehaviour {

    public static bool wasTriggered;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.name == "Player")
            wasTriggered = true;

        
    }

    void OnTriggerStay2D (Collider2D other)
    {
        if (PlayerController.grounded == false && PlayerController.wasGrounded)
            Destroy(gameObject);
    }
}

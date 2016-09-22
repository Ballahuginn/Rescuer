using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float generalSpeed;
    public float groundCheckRadius;

    public static bool grounded;
    public static bool wasGrounded;
	public bool soundWasPlayed;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    public Text goUpText;
    public Rigidbody2D rb;

	private Animator anim;
	private AudioSource audio;

    private float verticalSpeed;
	private bool upWasPressed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		audio = GetComponent<AudioSource> ();
		soundWasPlayed = false;
    }
	
    void FixedUpdate ()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

	void Update ()
    {
        if (grounded)
        {
            wasGrounded = true;
            anim.SetBool("onTheGround", true);
        }  
        else
        {
            anim.SetBool("onTheGround", false);
        }

        if (wasGrounded)
        {
            goUpText.enabled = true;
            if (Input.GetKey("up") && CheckForTrigger.wasTriggered)
            {
                upWasPressed = true;
                anim.SetBool("withTheHuman", true);

            }
            if (upWasPressed)
			{
                goUpText.enabled = false;
                if (Input.GetKey("up"))
                {
                    verticalSpeed = -5;
                }
                else
                {
                    verticalSpeed = -1;
                }
                Moving();
            }
            
        }
        else
        {
            if (Input.GetKey("down"))
            {
                verticalSpeed = 10;
            }
            else
            {
                verticalSpeed = 1;
            }
            Moving();
        }

		if (upWasPressed && !soundWasPlayed) 
		{
			audio.Play ();
			soundWasPlayed = true;
		}

        if (rb.velocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else if (rb.velocity.x < 0)
            transform.localScale = new Vector3(-1f, 1f, -1f);
    }

    void Moving ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = 0.15f * verticalSpeed;

        Vector2 movement = new Vector2(moveHorizontal, -moveVertical);
        rb.velocity = movement * generalSpeed;
    }
}

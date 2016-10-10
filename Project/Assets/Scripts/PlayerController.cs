using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float generalSpeed;
   
	public float groundCheckRadius;  
    public static bool grounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;

	public static bool wasGrounded;

    public Text goUpText;
	public Rigidbody2D rb;

	public float knockback;
	public float knockbakLenght;
	public float knockbackCount; 
	public bool knockFromRight;
	public bool soundWasPlayed;

	public static Animator playerAnimation;
	private AudioSource audioS;
	private GameObject targetCollider;

    private float verticalSpeed;
	private bool upWasPressed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
		audioS = GetComponent<AudioSource> ();
		targetCollider = transform.FindChild ("Target Collider").gameObject;
		soundWasPlayed = false;
		wasGrounded = false;
		targetCollider.SetActive (false);
		PlayerPrefs.SetInt ("WithTarget", 0);
		SpriteSet ("withTheHuman", false);
		SpriteSet ("targetIsDead", false);

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
			targetCollider.SetActive (false);
			PlayerPrefs.SetInt ("WithTarget", 0);

			if (Input.GetKey ("up") && CheckForTrigger.wasTriggered)
			{
				
				upWasPressed = true;
                SpriteSet("withTheHuman", true);
				targetCollider.SetActive (true);
				PlayerPrefs.SetInt ("WithTarget", 1);

			}
		}  
		else
		{
			if (KillPlayer.deadTarget == false && wasGrounded == false)
			{
				targetCollider.SetActive (false);
				PlayerPrefs.SetInt ("WithTarget", 0);
			}
			else if (KillPlayer.deadTarget == true && wasGrounded == true)
			{
				targetCollider.SetActive (false);
				PlayerPrefs.SetInt ("WithTarget", 0);
			}
			else
			{
				targetCollider.SetActive (true);
				PlayerPrefs.SetInt ("WithTarget", 1);
			}
			
		}

		if (wasGrounded)
		{
			goUpText.enabled = true;
			if (upWasPressed)
			{
				goUpText.enabled = false;
				if (Input.GetKey ("up") && KillPlayer.deadTarget == false)
					verticalSpeed = -5;
				else if (Input.GetKey ("up") && KillPlayer.deadTarget)
					verticalSpeed = -10;
				else
					verticalSpeed = -1;
				Moving();
			}

		}
		else
		{
			if (Input.GetKey("down"))
				verticalSpeed = 10;
			else
				verticalSpeed = 1;
			Moving();
		}

		if (upWasPressed && !soundWasPlayed) 
		{
			audioS.Play ();
			soundWasPlayed = true;
		}
			
		if (knockbackCount <= 0) 
			Moving ();
		else
		{
			if (knockFromRight)
				rb.velocity = new Vector2 (-rb.velocity.x, rb.velocity.y);
			else
				rb.velocity = new Vector2 (knockback, rb.velocity.y);
			knockbackCount -= Time.deltaTime;
		}


	}

	void Moving ()
	{
		float moveHorizontal;
		float moveVertical = 0.15f * verticalSpeed;
		if (grounded)
			moveHorizontal = 0.0f;
		else 
		{
			moveHorizontal = Input.GetAxis ("Horizontal");
		}

		Vector2 movement = new Vector2 (moveHorizontal, -moveVertical);
		rb.velocity = movement * generalSpeed;

		if (rb.velocity.x > 0)
			transform.localScale = new Vector3(-1.5f, 1.5f, 1f);
		else if (rb.velocity.x < 0)
			transform.localScale = new Vector3(1.5f, 1.5f, 1f);
	}

	public static void SpriteSet (string spriteToSet, bool spriteState)
	{
		playerAnimation.SetBool(spriteToSet, spriteState);
	}
}
﻿using UnityEngine;
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

	public float knockback;
	public float knockbakLenght;
	public float knockbackCount; 
	public bool knockFromRight;

	private Animator anim;
	private AudioSource audio;
	private GameObject ropeCollider;
	private GameObject onGroundCollider;
	private GameObject withHumanCollider;

    private float verticalSpeed;
	private bool upWasPressed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		audio = GetComponent<AudioSource> ();
		ropeCollider = transform.FindChild ("Rope Collider").gameObject;
		onGroundCollider = transform.FindChild ("OnGround Collider").gameObject;
		withHumanCollider = transform.FindChild ("WithHuman Collider").gameObject;
		soundWasPlayed = false;
		wasGrounded = false;
		ropeCollider.SetActive (true);
		onGroundCollider.SetActive (false);
		withHumanCollider.SetActive (false);


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
			ropeCollider.SetActive (false);
			onGroundCollider.SetActive (true);
			withHumanCollider.SetActive (false);
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
				ropeCollider.SetActive (false);
				onGroundCollider.SetActive (false);
				withHumanCollider.SetActive (true);

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
			
		if (knockbackCount <= 0) 
			Moving ();
		else
		{
			if (knockFromRight)
				rb.velocity = new Vector2 (-knockback, rb.velocity.y);
			else
				rb.velocity = new Vector2 (knockback, rb.velocity.y);
			knockbackCount -= Time.deltaTime;
		}

		if (rb.velocity.x > 0)
			transform.localScale = new Vector3(1f, 1f, 1f);
		else if (rb.velocity.x < 0)
			transform.localScale = new Vector3(-1f, 1f, -1f);
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
	}
}

using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	public float moveSpeed;
	public bool moveRight;
	public bool moveVertical;
	public bool moveUp;

	public Transform wallCheck;
	public Transform spikesCheck;
	public float wallCheckRadius;
	public float spikesCheckRadius;
	public LayerMask whatIsWall;
	public LayerMask whatIsSpikes;
	private bool hittingWall;
	private bool hittingSpikes;

	private Rigidbody2D rb;
	private GameObject upCheck;

	void Start () 
	{
		rb = GetComponent <Rigidbody2D> ();
		upCheck = transform.FindChild ("UpCheck").gameObject;
		//moveUp = true;
	}
	
	void Update () 
	{
		hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
		hittingSpikes = Physics2D.OverlapCircle (spikesCheck.position, spikesCheckRadius, whatIsSpikes);

		if (hittingWall || hittingSpikes)
		{
			moveRight = !moveRight;
			moveUp = !moveUp;
		}

		if (moveVertical)
		{
			if (moveUp) 
			{
				//transform.localScale = new Vector3 (-0.75f, 0.75f, 0.75f);
				upCheck.transform.localPosition = new Vector3 (0f, 0.3f, 0f);
				rb.velocity = new Vector2 (rb.velocity.x, moveSpeed);
			}
			else 
			{
				//transform.localScale = new Vector3 (0.75f, 0.75f, 0.75f);
				upCheck.transform.localPosition = new Vector3 (0f, -0.3f, 0f);
				rb.velocity = new Vector2 (rb.velocity.x, -moveSpeed);
			}
		}
		else
		{
			if (moveRight) 
			{
				transform.localScale = new Vector3 (-0.75f, 0.75f, 0.75f);
				rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);
			}
			else 
			{
				transform.localScale = new Vector3 (0.75f, 0.75f, 0.75f);
				rb.velocity = new Vector2 (-moveSpeed, rb.velocity.y);
			}
		}
	}
}

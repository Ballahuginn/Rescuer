using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public static int playerHealth;
	public int maxPlayerHealth;
	public bool isDead;

	private LevelManager levelManager;

	Text text; 

	void Start () 
	{
		text = GetComponent<Text> (); 

		playerHealth = maxPlayerHealth;

		levelManager = FindObjectOfType<LevelManager> ();

		isDead = false; 
	}

	void Update () 
	{
		if (playerHealth <= 0 && !isDead)
		{
			playerHealth = 0;
			levelManager.RespawnPlayer ();
			isDead = true;
		}

		text.text = "" + playerHealth;
	}

	public static void HurtPlayer(int damageToGive)
	{
		playerHealth -= damageToGive;
	}

	public static void HurtPlayerWithEnemy(int enemyDamageToGive)
	{
		playerHealth -= enemyDamageToGive;
	}

	public void FullHealth()
	{
		playerHealth = maxPlayerHealth; 
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{

	public static Player instance;

	public int currentHealth;
	public bool nextToDoor;
	public float movSpeed;
	public UseableItem equippedItem;
	public bool inGoal;

	public List<Upgrade> givenUpgrades = new List<Upgrade>();


	private Rigidbody2D rigidBody;
	private Vector3 prevInputForce;
	private float effectiveMoveSpeed;

	void Start ()
	{
		instance = this;

		currentHealth = 2;
		rigidBody = this.GetComponent<Rigidbody2D>();
	}

	void Update ()
	{
		effectiveMoveSpeed = movSpeed;
		if (Input.GetButton("boost") || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			effectiveMoveSpeed *= 2.5f;
		}

		Vector3 inputForce = new Vector3(Input.GetAxis("Horizontal") * effectiveMoveSpeed, Input.GetAxis("Vertical") * effectiveMoveSpeed, 0);
		if (inputForce.x == 0 && inputForce.y == 0)
		{
			if (Input.GetButton("w"))
			{
				inputForce = inputForce + new Vector3(0, effectiveMoveSpeed, 0);
			}
			if (Input.GetButton("s"))
			{
				inputForce = inputForce + new Vector3(0, effectiveMoveSpeed * -1, 0);
			}
			if (Input.GetButton("a"))
			{
				inputForce = inputForce + new Vector3(effectiveMoveSpeed * -1, 0, 0);
			}
			if (Input.GetButton("d"))
			{
				inputForce = inputForce + new Vector3(effectiveMoveSpeed * 1, 0, 0);
			}
		}
		inputForce = Vector3.ClampMagnitude(inputForce, effectiveMoveSpeed);


		if (inputForce.x != 0 || inputForce.y != 0)
		{
			prevInputForce = inputForce;
		}
		rigidBody.AddForce(inputForce);
		rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, 1.0f);

		float heading = Mathf.Atan2(-prevInputForce.x, prevInputForce.y);
		this.transform.rotation = Quaternion.Euler(0f, 0f, heading * Mathf.Rad2Deg);

		if (Input.GetButtonDown("regen"))
		{
			LevelGenerator.instance.GenerateBoard();
		}

		if (nextToDoor && Input.GetButtonDown("x"))
		{
			Application.LoadLevel("LevelUpScene");
		}

		if (currentHealth <= 0)
		{
			Application.LoadLevel("LoseScene");
		}

		if (Input.GetButtonDown("use"))
		{
			equippedItem.UseItem();
		}
	}

	public void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.GetComponent<CollisionKillTag>())
		{
			currentHealth--;
			HeartUIController.instance.HealthChanged();
		}

		if (coll.gameObject.GetComponent<DiamondTag>())
		{
			GlobalState.instance.incGemCount(coll.gameObject.GetComponent<DiamondTag>().diamondValue);
			Destroy(coll.gameObject);
		}
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.GetComponent<GoalZone>())
		{
			inGoal = true;
		}

		if (coll.gameObject.GetComponent<DoorTag>())
		{
			nextToDoor = true;
		}
	}

	public void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.GetComponent<GoalZone>())
		{
			inGoal = false;
		}

		if (coll.gameObject.GetComponent<DoorTag>())
		{
			nextToDoor = false;
		}
	}
}
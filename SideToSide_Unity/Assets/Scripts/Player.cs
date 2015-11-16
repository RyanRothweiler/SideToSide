using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{

	public static Player instance;

	public bool nextToDoor;
	public float movSpeed;
	private float effectiveMoveSpeed;

	public List<Upgrade> givenUpgrades = new List<Upgrade>();

	private Rigidbody2D rigidBody;

	private Vector3 prevInputForce;

	void Start ()
	{
		instance = this;

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
	}

	public void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.GetComponent<CollisionKill>())
		{
			Application.LoadLevel("LoseScene");
		}

		if (coll.gameObject.GetComponent<Diamond>())
		{
			GlobalState.instance.incGemCount(coll.gameObject.GetComponent<Diamond>().diamondValue);
			Destroy(coll.gameObject);
		}
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.GetComponent<DoorController>())
		{
			nextToDoor = true;
		}
	}

	public void OnTriggerExit2D(Collider2D coll)
	{
		nextToDoor = false;
	}
}
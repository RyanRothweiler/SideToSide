using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	public static Player instance;

	public float movSpeed;

	private Rigidbody2D rigidBody;
	private Soul soulNextTo;
	private Soul soulHeld;

	private Vector3 prevInputForce;

	void Start ()
	{
		instance = this;

		rigidBody = this.GetComponent<Rigidbody2D>();
	}

	void Update ()
	{
		Vector3 inputForce = new Vector3(Input.GetAxis("Horizontal") * movSpeed, Input.GetAxis("Vertical") * movSpeed, 0);
		if (inputForce.x != 0 || inputForce.y != 0)
		{
			prevInputForce = inputForce;
		}
		rigidBody.AddForce(inputForce);
		rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, 1.0f);

		float heading = Mathf.Atan2(-prevInputForce.x, prevInputForce.y);
		this.transform.rotation = Quaternion.Euler(0f, 0f, heading * Mathf.Rad2Deg);

		if (Input.GetButtonDown("x"))
		{
			if (soulHeld != null)
			{
				soulHeld.GetComponent<BoxCollider2D>().isTrigger = false;
				soulHeld = null;
			}
			else
			{
				if (soulNextTo != null)
				{
					soulHeld = soulNextTo;
					soulHeld.GetComponent<BoxCollider2D>().isTrigger = true;
				}

			}
		}

		if (soulHeld)
		{
			Vector3 newPos = new Vector3(this.transform.position.x, this.transform.position.y, 1);
			soulHeld.transform.position = newPos;
		}
	}

	public void OnCollisionExit2D(Collision2D coll)
	{
		if (soulNextTo != null &&
		    soulNextTo.gameObject == coll.gameObject)
		{
			soulNextTo = null;
		}
	}

	public void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.GetComponent<CollisionKill>())
		{
			Application.LoadLevel("Lose");
		}

		if (coll.gameObject.GetComponent<Soul>())
		{
			soulNextTo = coll.gameObject.GetComponent<Soul>();
		}
	}
}

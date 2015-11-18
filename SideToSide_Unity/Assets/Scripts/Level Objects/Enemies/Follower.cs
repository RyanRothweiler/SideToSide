using UnityEngine;
using System.Collections;

public class Follower : Enemy
{

	public Player player;

	void Start ()
	{
		player = Player.instance;
	}

	void Update ()
	{
		if (!frozen)
		{
			if (!player.inGoal)
			{
				if (Vector3.Distance(this.transform.position, player.transform.position) < 2.3f)
				{
					Vector3 direction = (this.transform.position - player.transform.position).normalized;
					this.transform.position = this.transform.position + (direction * -0.8f * Time.deltaTime);
				}
			}
		}
	}
}
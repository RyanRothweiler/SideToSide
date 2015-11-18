using UnityEngine;
using System.Collections;

public class GoalZone : MonoBehaviour
{
	public void OnTriggerEnter2D(Collider2D coll)
	{
		GoalController.instance.WallTouched(this.gameObject);
	}
}

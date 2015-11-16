using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pather : MonoBehaviour
{

	public bool activated = false;
	public List<GameObject> waypoints = new List<GameObject>();
	private int waypointIndex = 0;

	void Update ()
	{
		if (activated)
		{
			GameObject currentTarget = waypoints[waypointIndex];
			Vector3 targetDir = (this.transform.position - currentTarget.transform.position).normalized;
			this.transform.position = this.transform.position - (targetDir * 0.03f);
			if (Vector3.Distance(this.transform.position, currentTarget.transform.position) < 0.2f)
			{
				waypointIndex = (waypointIndex + 1) % waypoints.Count;
			}
		}
	}
}

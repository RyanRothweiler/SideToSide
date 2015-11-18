using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PacerPiece : LevelPiece
{

	public List<GameObject> pacers = new List<GameObject>();

	public override void PlacePiece(GameObject holder)
	{
		foreach (GameObject pacer in pacers)
		{
			pacer.GetComponent<Pather>().activated = true;
			foreach (GameObject waypoint in pacer.GetComponent<Pather>().waypoints)
			{
				waypoint.transform.parent = holder.transform;
			}
		}
	}

	public override void Remove()
	{
		foreach (GameObject pacer in pacers)
		{
			foreach (GameObject waypoint in pacer.GetComponent<Pather>().waypoints)
			{
				Destroy(waypoint);
			}
		}
	}
}
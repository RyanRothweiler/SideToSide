using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SawPiece : LevelPiece
{

	public List<GameObject> saws = new List<GameObject>();

	public override void PlacePiece(GameObject holder)
	{
		foreach (GameObject saw in saws)
		{
			saw.GetComponent<Pacer>().activated = true;
			saw.GetComponent<Pacer>().targetOne.transform.parent = holder.transform;
			saw.GetComponent<Pacer>().targetTwo.transform.parent = holder.transform;
		}
	}

	public override void Remove()
	{
		foreach (GameObject saw in saws)
		{
			Destroy(saw.GetComponent<Pacer>().targetOne);
			Destroy(saw.GetComponent<Pacer>().targetTwo);
		}
	}
}
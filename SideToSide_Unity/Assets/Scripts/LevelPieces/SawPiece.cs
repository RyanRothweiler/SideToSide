using UnityEngine;
using System.Collections;

public class SawPiece : LevelPiece
{

	public GameObject levelHolder;

	public override void GenPlaced()
	{
		this.GetComponent<Pacer>().targetOne.transform.position = this.transform.position;
		this.GetComponent<Pacer>().targetOne.transform.parent = levelHolder.transform;

		Vector3 randomOffset = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
		this.GetComponent<Pacer>().targetTwo.transform.position = this.transform.position + randomOffset;
		this.GetComponent<Pacer>().targetTwo.transform.parent = levelHolder.transform;
	}

}
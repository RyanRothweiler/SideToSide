using UnityEngine;
using System.Collections;

public class LevelPiece : MonoBehaviour
{
	public void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.name == "LevelKiller")
		{
			Destroy(this.gameObject);
		}
	}

	public virtual void GenPlaced()
	{

	}

}

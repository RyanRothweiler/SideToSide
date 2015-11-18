using UnityEngine;
using System.Collections;

public class WeaponFreezeCollision : MonoBehaviour
{

	public void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.GetComponent<Enemy>())
		{
			coll.gameObject.GetComponent<Enemy>().Freeze();
		}
	}

}

using UnityEngine;
using System.Collections;

public class SlugDrop : MonoBehaviour
{
	void Start ()
	{
		StartCoroutine(WaitKill());
	}

	public IEnumerator WaitKill()
	{
		yield return new WaitForSeconds(2.0f);
		Destroy(this.gameObject);
	}
}

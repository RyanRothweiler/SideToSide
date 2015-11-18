using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	public GameObject frozenEffect;
	public bool frozen = false;

	public void Freeze()
	{
		frozenEffect.SetActive(true);
		frozen = true;
		StartCoroutine(unFreeze());
	}
	private IEnumerator unFreeze()
	{
		yield return new WaitForSeconds(4.0f);
		frozen = false;
		frozenEffect.SetActive(false);
	}
}

using UnityEngine;
using System.Collections;


// TODO look at pulling this out, it's only the freezing effect, don't really need to use inheritance
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

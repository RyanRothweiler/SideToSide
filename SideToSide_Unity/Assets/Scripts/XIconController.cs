using UnityEngine;
using System.Collections;

public class XIconController : MonoBehaviour
{

	public GameObject sprite;

	void Update ()
	{
		if (Player.instance != null)
		{
			if (Player.instance.nextToDoor)
			{
				sprite.SetActive(true);
				this.transform.position = Player.instance.transform.position + new Vector3(0, 0.25f, 0);
			}
			else
			{
				sprite.SetActive(false);
			}
		}
	}
}

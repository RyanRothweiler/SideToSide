using UnityEngine;
using System.Collections;

public class GlobalState : MonoBehaviour
{

	public static GlobalState instance;

	public int gemsHeld;
	public int totalGemCount;

	void Start ()
	{
		if (instance != null &&
		    instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			DontDestroyOnLoad(this.gameObject);
			instance = this;
		}
	}

	public void incGemCount(int amount)
	{
		gemsHeld += amount;
		totalGemCount += amount;
	}
}
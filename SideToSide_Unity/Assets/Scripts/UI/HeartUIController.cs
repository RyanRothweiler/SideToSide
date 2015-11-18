using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeartUIController : MonoBehaviour
{

	public static HeartUIController instance;

	public List <GameObject> hearts = new List<GameObject>();

	public void Start()
	{
		instance = this;
		HealthChanged();
	}

	public void HealthChanged()
	{
		if (Player.instance.currentHealth > hearts.Count)
		{
			Debug.LogWarning("Not enough hearts to display that health, add more.");
		}

		for (int heartIndex = 0;
		     heartIndex < hearts.Count;
		     heartIndex++)
		{
			if (Player.instance.currentHealth > heartIndex)
			{
				hearts[heartIndex].SetActive(true);
			}
			else
			{
				hearts[heartIndex].SetActive(false);
			}
		}
	}

}

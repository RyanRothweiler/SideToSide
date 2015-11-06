using UnityEngine;
using System.Collections;

public class LoseSceneController : MonoBehaviour
{

	public void Update()
	{
		if (Input.GetButtonDown("x"))
		{
			Application.LoadLevel("FirstScene");
		}
	}

}
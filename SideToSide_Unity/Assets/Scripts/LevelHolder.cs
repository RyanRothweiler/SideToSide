using UnityEngine;
using System.Collections;

public class LevelHolder : MonoBehaviour
{

	void Update ()
	{
		this.transform.position = this.transform.position + new Vector3(0, 0.01f, 0);
	}

}
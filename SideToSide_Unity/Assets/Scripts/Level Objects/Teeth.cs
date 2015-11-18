using UnityEngine;
using System.Collections;

public class Teeth : MonoBehaviour
{

	public Vector3 direction;

	void Update ()
	{
		this.transform.position = this.transform.position + (direction * 0.001f);
	}
}

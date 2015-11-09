using UnityEngine;
using System.Collections;

public class RowMover : MonoBehaviour
{

	public Vector3 direction;

	void Update ()
	{
		this.transform.position = this.transform.position + (direction * 0.0f);
	}
}

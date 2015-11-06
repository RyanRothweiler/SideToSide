using UnityEngine;
using System.Collections;

public class SphereGizmo : MonoBehaviour
{

	public void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(this.transform.position, 0.1f);
	}

}
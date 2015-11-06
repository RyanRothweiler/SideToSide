using UnityEngine;
using System.Collections;

public class PacerTarget : MonoBehaviour
{
	
	// TODO need to parent this to something

	public void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(this.transform.position, 0.1f);
	}

}
using UnityEngine;
using System.Collections;

public class BoxGizmo : MonoBehaviour
{
	public void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(this.transform.position, this.transform.localScale * 2);
	}
}
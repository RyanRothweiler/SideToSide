using UnityEngine;
using System.Collections;

public class Pacer : MonoBehaviour
{

	public bool activated = false;

	public GameObject targetOne;
	public GameObject targetTwo;
	private GameObject currentTarget;


	void Start ()
	{
		currentTarget = targetOne;
	}

	void Update ()
	{
		if (activated)
		{
			Vector3 targetDir = (this.transform.position - currentTarget.transform.position).normalized;
			this.transform.position = this.transform.position - (targetDir * 0.03f);
			if (Vector3.Distance(this.transform.position, currentTarget.transform.position) < 0.2f)
			{
				if (currentTarget == targetOne)
				{
					currentTarget = targetTwo;
				}
				else
				{
					currentTarget = targetOne;
				}
			}
		}
	}
}

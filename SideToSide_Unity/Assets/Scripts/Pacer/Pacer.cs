using UnityEngine;
using System.Collections;

public class Pacer : MonoBehaviour
{

	public GameObject targetOne;
	public GameObject targetTwo;
	private GameObject currentTarget;


	void Start ()
	{
		currentTarget = targetOne;
	}

	// Update is called once per frame
	void Update ()
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
		float heading = Mathf.Atan2(-targetDir.x, targetDir.y);
		this.transform.rotation = Quaternion.Euler(0f, 0f, heading * Mathf.Rad2Deg);
	}
}

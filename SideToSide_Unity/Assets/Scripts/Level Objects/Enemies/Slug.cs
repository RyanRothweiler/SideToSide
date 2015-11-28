using UnityEngine;
using System.Collections;

public class Slug : Enemy
{

	public float moveSpeed;
	public GameObject levelCenter;
	public GameObject droppingObj;

	private bool doDrop;
	private Vector3 targetLoc;


	// Use this for initialization
	void Start ()
	{
		targetLoc = this.transform.position;
		doDrop = true;

		levelCenter = GameObject.Find("LevelCenter");
	}

	// Update is called once per frame
	void Update ()
	{
		if (!frozen)
		{
			if (doDrop)
			{
				Instantiate(droppingObj, this.transform.position, Quaternion.identity);
				doDrop = false;
				StartCoroutine(DropWait());
			}
			Vector3 targetDir = (this.transform.position - targetLoc).normalized;
			this.transform.position = this.transform.position - (targetDir * Time.deltaTime * moveSpeed);

			if (Vector3.Distance(targetLoc, this.transform.position) < 0.2f)
			{
				bool validPoint = false;
				Vector3 newTargetLoc = new Vector3(0, 0, 0);
				while (!validPoint)
				{
					float randRange = 5.0f;
					newTargetLoc = this.transform.position +
					               new Vector3(Random.Range(-randRange, randRange),
					                           Random.Range(-randRange, randRange),
					                           0);

					if (Vector3.Distance(newTargetLoc, levelCenter.transform.position) < 6.47f)
					{
						validPoint = true;
					}
				}

				targetLoc = newTargetLoc;
			}
		}
	}

	public IEnumerator DropWait()
	{
		yield return new WaitForSeconds(0.3f);
		doDrop = true;
	}
}

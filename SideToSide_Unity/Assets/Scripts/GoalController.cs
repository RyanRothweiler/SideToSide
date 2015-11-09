using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour
{

	public static GoalController instance;
	public int touchCount;

	public GameObject targetLeft;
	public GameObject targetRight;
	public GameObject currentTarget;

	void Start ()
	{
		instance = this;
		touchCount = 0;
		currentTarget = targetLeft;
	}

	public void WallTouched(GameObject touched)
	{
		if (touched == currentTarget)
		{
			LevelGenerator.instance.GenerateBoard();
			
			touchCount++;
			if (currentTarget == targetLeft)
			{
				currentTarget.GetComponent<SpriteRenderer>().color = Color.white;
				currentTarget = targetRight;
				currentTarget.GetComponent<SpriteRenderer>().color = Color.green;
			}
			else
			{
				currentTarget.GetComponent<SpriteRenderer>().color = Color.white;
				currentTarget = targetLeft;
				currentTarget.GetComponent<SpriteRenderer>().color = Color.green;
			}
		}

	}

}
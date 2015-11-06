using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

	public static UIController instance;

	public Text goalCountText;

	void Start ()
	{
		instance = this;
	}

	void Update ()
	{
		goalCountText.text = "" + GoalController.instance.touchCount;
	}
}

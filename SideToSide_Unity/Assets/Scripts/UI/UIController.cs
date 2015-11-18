using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

	public static UIController instance;

	public Text levelGemCountText;

	void Start ()
	{
		instance = this;
	}

	void Update ()
	{
		levelGemCountText.text = "" + GlobalState.instance.gemsHeld + " gems";
	}
}

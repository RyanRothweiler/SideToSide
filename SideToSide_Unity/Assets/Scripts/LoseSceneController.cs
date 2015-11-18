using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoseSceneController : MonoBehaviour
{

	public Text touchCount;

	public void Start()
	{
		touchCount.text = "score - " + GlobalState.instance.totalGemCount;
	}

	public void Update()
	{
		if (Input.GetButtonDown("x"))
		{
			GlobalState.instance.gemsHeld = 0;
			GlobalState.instance.totalGemCount = 0;

			Application.LoadLevel("GameScene");
		}
	}

}
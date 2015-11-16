using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LevelUpSceneController : MonoBehaviour
{

	public Text gemsHeldText;

	public List<Upgrade> upgradeLibrary = new List<Upgrade>();

	public GameObject selector;
	public List<GameObject> selectionOptions;
	private int selectorOptionsIndex;

	private bool canMove;

	public void Start()
	{
		canMove = true;

		foreach (GameObject option in selectionOptions)
		{
			UpgradeOptionSlot slot = option.GetComponent<UpgradeOptionSlot>();
			slot.Slot(upgradeLibrary[Random.Range(0, upgradeLibrary.Count)]);
		}

	}

	public void Update()
	{
		gemsHeldText.text = "Gems Held " + GlobalState.instance.gemsHeld;

		Vector3 inputForce = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		if (inputForce.x == 0 && inputForce.y == 0)
		{
			if (Input.GetButton("w"))
			{
				inputForce = inputForce + new Vector3(0, 1, 0);
			}
			if (Input.GetButton("s"))
			{
				inputForce = inputForce + new Vector3(0, -1, 0);
			}
			if (Input.GetButton("a"))
			{
				inputForce = inputForce + new Vector3(-1, 0, 0);
			}
			if (Input.GetButton("d"))
			{
				inputForce = inputForce + new Vector3(1, 0, 0);
			}
		}

		if (inputForce.x == 0 && inputForce.y == 0)
		{
			canMove = true;
		}

		if (canMove)
		{
			if (inputForce.x > 0)
			{
				MoveSelector(1);
			}
			if (inputForce.x < 0)
			{
				MoveSelector(-1);
			}
		}

		int gemCost = selectionOptions[selectorOptionsIndex].GetComponent<UpgradeOptionSlot>().optionSlotted.gemCost;
		if (GlobalState.instance.gemsHeld - gemCost > 0 && Input.GetButtonDown("x"))
		{
			GlobalState.instance.gemsHeld -= gemCost;
			Application.LoadLevel("GameScene");
		}
	}

	public void MoveSelector(int change)
	{
		selectorOptionsIndex = (selectorOptionsIndex + change) % selectionOptions.Count;
		if (selectorOptionsIndex < 0)
		{
			selectorOptionsIndex = selectionOptions.Count - 1;
		}
		canMove = false;
		selector.transform.position = selectionOptions[selectorOptionsIndex].transform.position;
	}
}
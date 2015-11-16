using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradeOptionSlot : MonoBehaviour
{

	public Text title;
	public Text description;
	public Text gemCost;
	public Upgrade optionSlotted;

	public void Slot(Upgrade upgradeSlotting)
	{
		// Debug.Log(upgradeSlotting);
		title.text = upgradeSlotting.title;
		description.text = upgradeSlotting.description;
		gemCost.text = "" + upgradeSlotting.gemCost;
		optionSlotted = upgradeSlotting;
	}
}

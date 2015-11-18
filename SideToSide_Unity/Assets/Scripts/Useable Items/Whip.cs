using UnityEngine;
using System.Collections;
using UnityEditor.Animations;

public class Whip : UseableItem
{

	public SpriteRenderer whipSprite;

	private Animator animator;

	void Start ()
	{
		animator = this.GetComponent<Animator>();
	}

	public override void UseItem()
	{
		base.UseItem();
		animator.SetTrigger("Use");
	}

}

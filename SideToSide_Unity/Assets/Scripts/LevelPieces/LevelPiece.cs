using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelPiece : MonoBehaviour
{

	public List<Vector2> gridsTakenOffset;

	public virtual void PlacePiece(GameObject holder)
	{ }
	
	public virtual void Remove()
	{ }

}
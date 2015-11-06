using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{

	public static LevelGenerator instance;

	public GameObject levelHolder;
	public GameObject levelGenLocation;
	public List<LevelGenPiece> levelPieces = new List<LevelGenPiece>();

	public GameObject sideWallOne;
	public GameObject sideWallTwo;

	private bool genWaiting = false;

	void Start ()
	{
		instance = this;

		for (int index = 0;
		     index < 15;
		     index++)
		{
			PlacePiece(levelHolder.transform.position);
		}
	}

	void Update ()
	{
		if (!genWaiting)
		{
			PlacePiece(levelGenLocation.transform.position);
			genWaiting = true;
			StartCoroutine(GenWait());
		}
	}

	// TODO make this use the piece ramdon weights
	public void PlacePiece(Vector3 centerLoc)
	{
		bool piecePlaced = false;
		while (!piecePlaced)
		{
			Vector3 newPosRange = new Vector3(5.5f, 5.5f, 0);
			Vector3 randomOffset = new Vector3(Random.Range(-newPosRange.x, newPosRange.x), Random.Range(-newPosRange.x, newPosRange.x), 0);
			Vector3 newPos = randomOffset + centerLoc;

			LevelGenPiece newPiece = levelPieces[Random.Range(0, levelPieces.Count)];
			if (newPiece.use)
			{
				GameObject newObj = Instantiate(newPiece.piece);
				newObj.transform.position = newPos;
				newObj.transform.Rotate(Vector3.forward * Random.Range(0, 360));

				newObj.GetComponent<LevelPiece>().GenPlaced();
				newObj.transform.parent = levelHolder.transform;

				piecePlaced = true;
				if (newObj.GetComponent<BoxCollider2D>() != null)
				{
					if (sideWallOne.GetComponent<BoxCollider2D>().bounds.Intersects(newObj.GetComponent<BoxCollider2D>().bounds) ||
					    sideWallTwo.GetComponent<BoxCollider2D>().bounds.Intersects(newObj.GetComponent<BoxCollider2D>().bounds))
					{
						piecePlaced = false;
					}
				}

				if (!piecePlaced)
				{
					Destroy(newObj);
				}
			}
		}
	}

	public IEnumerator GenWait()
	{
		yield return new WaitForSeconds(1f);
		genWaiting = false;
	}
}

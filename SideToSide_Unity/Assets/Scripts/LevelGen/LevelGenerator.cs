using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{

	public static LevelGenerator instance;

	public List<GameObject> rowLocs = new List<GameObject>();
	public List<GameObject> rowHolders = new List<GameObject>();
	private List<GameObject> pieceLibrary = new List<GameObject>();

	private List<Vector3> originalPositions = new List<Vector3>();

	void Start ()
	{
		instance = this;

		foreach (Transform child in transform)
		{
			if (child.gameObject.activeInHierarchy)
			{
				pieceLibrary.Add(child.gameObject);
			}
		}

		foreach (GameObject holder in rowHolders)
		{
			originalPositions.Add(holder.transform.position);
		}

		GenerateBoard();
	}

	public void GenerateBoard()
	{

		for (int index = 0;
		     index < rowHolders.Count;
		     index++)
		{
			rowHolders[index].transform.position = originalPositions[index];
		}

		for (int index = 0;
		     index < rowHolders.Count;
		     index++)
		{
			foreach (Transform child in rowHolders[index].transform)
			{
				Destroy(child.gameObject);
			}
		}

		int piecesGenerated = 5;
		float tileWidth = 2.88f;
		for (int colIndex = 0;
		     colIndex < 5;
		     colIndex++)
		{

			int flipper = colIndex % 2;
			if (flipper == 0)
			{
				flipper = 1;
			}
			else
			{
				flipper = -1;
			}

			Vector3 currentPos = rowLocs[colIndex].transform.position;
			for (int pieceNum = 0;
			     pieceNum < piecesGenerated;
			     pieceNum++)
			{
				int pieceIndex = Random.Range(0, pieceLibrary.Count);
				GameObject newPiece = GameObject.Instantiate(pieceLibrary[pieceIndex]) as GameObject;

				if (flipper == 1)
				{
					if (newPiece.GetComponent<LevelPiece>().isDouble)
					{
						currentPos -= new Vector3(0, tileWidth * flipper * 2, 0);
					}
					else
					{
						currentPos -= new Vector3(0, tileWidth * flipper, 0);
					}
					newPiece.transform.position = currentPos;
				}
				else
				{
					newPiece.transform.position = currentPos;
					if (newPiece.GetComponent<LevelPiece>().isDouble)
					{
						currentPos -= new Vector3(0, tileWidth * flipper * 2, 0);
					}
					else
					{
						currentPos -= new Vector3(0, tileWidth * flipper, 0);
					}
				}

				newPiece.transform.parent = rowHolders[colIndex].transform;

				if (newPiece.GetComponent<SawPiece>())
				{
					newPiece.GetComponent<LevelPiece>().PlacePiece(rowHolders[colIndex]);
				}
				else
				{
					newPiece.GetComponent<LevelPiece>().PlacePiece();
				}
			}
		}

		for (int colIndex = 0;
		     colIndex < rowLocs.Count;
		     colIndex++)
		{

			int flipper = colIndex % 2;
			if (flipper == 0)
			{
				flipper = 1;
			}
			else
			{
				flipper = -1;
			}

			rowHolders[colIndex].transform.position = rowHolders[colIndex].transform.position +
			        new Vector3(0, tileWidth * flipper * (piecesGenerated + 2), 0);
		}
	}
}
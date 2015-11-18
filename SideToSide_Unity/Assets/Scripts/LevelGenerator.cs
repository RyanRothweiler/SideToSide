using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{

	public static LevelGenerator instance;

	public GameObject gridTopLeft;

	public float gridCellSize;
	public int gridSizeX; // 5
	public int gridSizeY; // 4

	public bool[,] gridTaken;
	private List<GameObject> pieceLibrary = new List<GameObject>();

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


		GenerateBoard();
	}

	public void GenerateBoard()
	{
		gridTaken = new bool[gridSizeX, gridSizeY];
		foreach (Transform child in gridTopLeft.transform)
		{
			Destroy(child.gameObject);
		}

		for (int x = 0;
		     x < gridSizeX;
		     x++)
		{
			for (int y = 0;
			     y < gridSizeY;
			     y++)
			{
				if (!gridTaken[x, y])
				{
					bool piecePlaced = false;
					while (!piecePlaced)
					{
						LevelPiece pieceTesting = pieceLibrary[Random.Range(0, pieceLibrary.Count)].GetComponent<LevelPiece>();

						bool spaceOpen = true;

						foreach (Vector2 newTaken in pieceTesting.gridsTakenOffset)
						{
							int xTaken = x + (int)newTaken.x;
							int yTaken = y + (int)newTaken.y;

							bool outsideArena = !(xTaken >= 0 && xTaken < gridSizeX &&
							                      yTaken >= 0 && yTaken < gridSizeY);
							if (outsideArena)
							{
								spaceOpen = false;
							}

							if (!outsideArena && gridTaken[xTaken, yTaken])
							{
								spaceOpen = false;
							}
						}

						if (spaceOpen)
						{
							piecePlaced = true;

							GameObject newPiece = Instantiate(pieceTesting.gameObject);
							newPiece.transform.position = new Vector3(x * gridCellSize, y * gridCellSize * -1) + gridTopLeft.transform.position;

							newPiece.transform.parent = gridTopLeft.transform;

							foreach (Vector2 newTaken in newPiece.GetComponent<LevelPiece>().gridsTakenOffset)
							{
								gridTaken[x + (int)newTaken.x, y + (int)newTaken.y] = true;
							}

							newPiece.GetComponent<LevelPiece>().PlacePiece(gridTopLeft);
						}
					}
				}
			}
		}
	}
}
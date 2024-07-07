using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour
{
    public PuzzleGenerator puzzleGenerator; // Reference to the PuzzleGenerator script
    public GameObject puzzlePiecePrefab; // Reference to the PuzzlePiece prefab
    public RectTransform puzzleContainer; // Reference to the UI Panel that holds the puzzle
    private int[,] puzzle;
    private Vector2Int emptySlot;
    private Dictionary<Vector2Int, GameObject> puzzlePieces;

    void Start()
    {
        GenerateAndDistributePuzzle();
    }

    void GenerateAndDistributePuzzle()
    {
        // Use a fixed seed for demonstration purposes
        int seed = new System.Random().Next();
        UnityEngine.Random.InitState(seed);

        // Generate the puzzle
        puzzle = puzzleGenerator.GeneratePuzzle();
        puzzlePieces = new Dictionary<Vector2Int, GameObject>();

        // Create puzzle pieces
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (puzzle[i, j] == 0)
                {
                    emptySlot = new Vector2Int(i, j);
                }
                else
                {
                    Vector2Int position = new Vector2Int(i, j);
                    GameObject piece = Instantiate(puzzlePiecePrefab, puzzleContainer);
                    piece.GetComponent<PuzzlePiece>().Initialize(puzzle[i, j], position, this);
                    puzzlePieces[position] = piece;
                }
            }
        }
    }

    public bool TryMovePiece(Vector2Int piecePosition)
    {
        if (Vector2Int.Distance(piecePosition, emptySlot) == 1)
        {
            // Swap the piece with the empty slot
            puzzle[emptySlot.x, emptySlot.y] = puzzle[piecePosition.x, piecePosition.y];
            puzzle[piecePosition.x, piecePosition.y] = 0;

            // Update the positions of the pieces
            GameObject piece = puzzlePieces[piecePosition];
            piece.transform.SetSiblingIndex(emptySlot.x * 3 + emptySlot.y); // Update UI position
            puzzlePieces[emptySlot] = piece;
            puzzlePieces.Remove(piecePosition);
            emptySlot = piecePosition;

            return true;
        }
        return false;
    }
}

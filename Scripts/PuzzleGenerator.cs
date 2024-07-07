using System;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGenerator : MonoBehaviour
{
    public int[,] GeneratePuzzle(int steps = 100)
    {
        int[,] puzzle = new int[3, 3];
        int[] values = { 0, 1, 2, 3, 4, 5, 6, 7, 8 }; // 0 represents the empty space

        // Initialize puzzle to solved state
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                puzzle[i, j] = values[i * 3 + j];
            }
        }

        // Shuffle the puzzle by making random moves
        Vector2Int emptyPosition = new Vector2Int(2, 2); // Start with the empty space at the bottom-right
        System.Random random = new System.Random();

        for (int step = 0; step < steps; step++)
        {
            List<Vector2Int> possibleMoves = GetPossibleMoves(emptyPosition);
            Vector2Int move = possibleMoves[random.Next(possibleMoves.Count)];

            // Swap the empty space with the chosen move
            puzzle[emptyPosition.x, emptyPosition.y] = puzzle[move.x, move.y];
            puzzle[move.x, move.y] = 0;

            emptyPosition = move;
        }

        return puzzle;
    }

    private List<Vector2Int> GetPossibleMoves(Vector2Int emptyPosition)
    {
        List<Vector2Int> moves = new List<Vector2Int>();

        if (emptyPosition.x > 0) moves.Add(new Vector2Int(emptyPosition.x - 1, emptyPosition.y)); // Up
        if (emptyPosition.x < 2) moves.Add(new Vector2Int(emptyPosition.x + 1, emptyPosition.y)); // Down
        if (emptyPosition.y > 0) moves.Add(new Vector2Int(emptyPosition.x, emptyPosition.y - 1)); // Left
        if (emptyPosition.y < 2) moves.Add(new Vector2Int(emptyPosition.x, emptyPosition.y + 1)); // Right

        return moves;
    }
}

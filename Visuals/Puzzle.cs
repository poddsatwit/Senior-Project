using System;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public Action OnPuzzleSolved;

    // Puzzle-specific logic here
    public void InitializePuzzle()
    {
        // Initialize the puzzle state
    }

    // Call this method when the puzzle is solved
    public void SolvePuzzle()
    {
        OnPuzzleSolved?.Invoke();
    }
}

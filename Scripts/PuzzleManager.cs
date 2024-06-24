using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public List<Player> players;
    public Puzzle puzzlePrefab;
    public Transform puzzleParent;
    public Text winnerText;

    private Dictionary<int, Puzzle> playerPuzzles;
    private bool gameEnded = false;

    void Start()
    {
        InitializePuzzleForPlayers();
    }

    void InitializePuzzleForPlayers()
    {
        playerPuzzles = new Dictionary<int, Puzzle>();
        foreach (Player player in players)
        {
            Puzzle puzzleInstance = Instantiate(puzzlePrefab, puzzleParent);
            puzzleInstance.InitializePuzzle();
            puzzleInstance.OnPuzzleSolved += () => OnPuzzleSolved(player.PlayerId);
            playerPuzzles.Add(player.PlayerId, puzzleInstance);
        }
    }

    void OnPuzzleSolved(int playerId)
    {
        if (!gameEnded)
        {
            gameEnded = true;
            winnerText.text = $"Player {playerId} wins!";
            Debug.Log($"Player {playerId} solved the puzzle first!");
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private TurnManager turnManager;
    private GameManager gameManager;

    void Start()
    {
        // Initialize game manager
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
            return;
        }

        // Define the number of players (with a limit of 6)
        int numberOfPlayers = 0; // This value can be set dynamically
        numberOfPlayers = Mathf.Clamp(numberOfPlayers, 1, 6); // Ensure it's between 1 and 6


        // Initialize turn manager with the list of players
        //turnManager = new TurnManager(new List<Player>(gameManager.Players.Values));

        // Example game loop: Run a series of turn cycles
        for (int round = 1; round <= 5; round++) // Example: 5 rounds
        {
            Debug.Log($"Starting round {round}");
            turnManager.RunTurnCycle();
        }
    }
}

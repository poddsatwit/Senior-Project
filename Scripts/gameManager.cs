using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private Dictionary<int, Player> players = new Dictionary<int, Player>();
    private int currentPlayerId;
    private int currentRound = 1; // Track the current round
    private static GameManager instance;
    public Gamestate State;
    public TMP_Text roundText; // Reference to the TMP_Text element to display the round

    public static event Action<Gamestate> Ongamestatechanged;

    private void Start()
    {
        UpdateGameState(Gamestate.CharacterSelect);
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    instance = go.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public enum Gamestate
    {
        MenuScene,
        CharacterSelect,
        RandomizePlayers,
        PlayerTurn,
        EnemyTurn,
        Minigame1,
        Minigame2,
        Minigame3,
        Showdown,
        Victory,
        Lose
    }

    public void UpdateGameState(Gamestate newstate)
    {
        State = newstate;

        switch (newstate)
        {
            case Gamestate.MenuScene:
                HandleMenuScene();
                break;
            case Gamestate.CharacterSelect:
                break;
            case Gamestate.RandomizePlayers:
                RandomizePlayers();
                break;
            case Gamestate.PlayerTurn:
                HandlePlayerTurn();
                break;
            case Gamestate.EnemyTurn:
                break;
            case Gamestate.Minigame1:
                UpdateRound<Minigame1>();
                break;
            case Gamestate.Minigame2:
                UpdateRound<Minigame2>();
                break;
            case Gamestate.Minigame3:
                UpdateRound<Minigame3>();
                break;
            case Gamestate.Showdown:
                break;
            case Gamestate.Victory:
                break;
            case Gamestate.Lose:
                break;
            default:
                break;
        }
        Ongamestatechanged?.Invoke(newstate);
    }

    private void HandlePlayerTurn()
    {
        Player currentPlayer = GetPlayer(currentPlayerId);
        if (currentPlayer != null)
        {
            // Trigger the start of the player's turn
            currentPlayer.StartTurn();
        }
    }

    public void EndPlayerTurn()
    {
        Player currentPlayer = GetPlayer(currentPlayerId);
        if (currentPlayer != null)
        {
            // End the current player's turn
            currentPlayer.EndTurn();
        }
        NextTurn();
    }

    public void NextTurn()
    {
        currentPlayerId++;
        if (currentPlayerId > players.Count)
        {
            currentPlayerId = 1; // Loop back to the first player
        }
        UpdateGameState(Gamestate.PlayerTurn);
    }

    private void RandomizePlayers()
    {
        int numberOfPlayers = 6; // or get this value from your game settings
        List<int> playerIds = new List<int>();
        for (int i = 1; i <= numberOfPlayers; i++)
        {
            playerIds.Add(i);
        }

        // Shuffle player IDs for randomization
        for (int i = 0; i < playerIds.Count; i++)
        {
            int temp = playerIds[i];
            int randomIndex = UnityEngine.Random.Range(i, playerIds.Count);
            playerIds[i] = playerIds[randomIndex];
            playerIds[randomIndex] = temp;
        }

        // Create and add players using the randomized IDs
        foreach (int playerId in playerIds)
        {
            Player newPlayer = CreatePlayerInstance(playerId);
            AddPlayer(playerId, newPlayer);
        }
    }

    private Player CreatePlayerInstance(int playerId)
    {
        Player newPlayer = new Player(playerId);
        // Configure new player as needed
        return newPlayer;
    }

    // Overloaded AddPlayer to take playerId and Player instance
    public void AddPlayer(int playerId, Player player)
    {
        if (!players.ContainsKey(playerId))
        {
            players.Add(playerId, player);
        }
    }

    public Player GetPlayer(int playerId)
    {
        players.TryGetValue(playerId, out Player player);
        return player;
    }

    public int GetCurrentPlayerId()
    {
        return currentPlayerId;
    }

    public void SetCurrentPlayerId(int playerId)
    {
        currentPlayerId = playerId;
    }

    private void HandleMenuScene()
    {
        // Implement the logic for handling the menu scene
        // This could involve setting up UI elements, displaying options, etc.
    }

    private void UpdateRound<T>() where T : MinigameBase
    {
        currentRound++;
        UpdateRoundText();
    }

    public void UpdateRoundText()
    {
        if (roundText != null)
        {
            roundText.text = "Round " + currentRound;
        }
    }

    public Dictionary<int, Player> Players => players;
}

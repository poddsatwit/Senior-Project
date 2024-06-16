using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Dictionary<int, Player> players = new Dictionary<int, Player>();
    private int currentPlayerId;

    // Overloaded AddPlayer to take only playerId
    public void AddPlayer(int playerId)
    {
        if (!players.ContainsKey(playerId))
        {
            Player newPlayer = new Player(playerId);
            players.Add(playerId, newPlayer);
        }
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

    public void NextTurn()
    {
        // Implement logic to set currentPlayerId to the next player's ID
    }

    public Dictionary<int, Player> Players => players;
}

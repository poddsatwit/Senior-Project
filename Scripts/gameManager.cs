using System.Collections.Generic;

public class GameManager
{
    public Dictionary<int, Player> Players { get; private set; }

    public GameManager()
    {
        Players = new Dictionary<int, Player>();
    }

    public void AddPlayer(int playerId)
    {
        if (!Players.ContainsKey(playerId))
        {
            Players[playerId] = new Player(playerId);
        }
    }

    public void AssignItemToPlayer(int playerId, Item item)
    {
        if (Players.ContainsKey(playerId))
        {
            Players[playerId].ItemInventory.AddItem(item);
        }
    }

    public void AssignEventToPlayer(int playerId, Event eventObj)
    {
        if (Players.ContainsKey(playerId))
        {
            Players[playerId].EventInventory.AddItem(eventObj);
        }
    }

    public override string ToString()
    {
        return $"GameManager with players: {string.Join(", ", Players.Values)}";
    }
}

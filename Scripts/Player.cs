using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int PlayerId { get; private set; }
    public int Coins { get; set; }
    public Inventory<Item> ItemInventory { get; private set; }
    public Inventory<Event> EventInventory { get; private set; }

    public Player(int playerId)
    {
        PlayerId = playerId;
        Coins = 100; // Initial coin amount for the player
        ItemInventory = new Inventory<Item>();
        EventInventory = new Inventory<Event>();
    }

    public override string ToString()
    {
        return $"Player {PlayerId} with {Coins} coins, Items: {ItemInventory}, Events: {EventInventory}";
    }
}

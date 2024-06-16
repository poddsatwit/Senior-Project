using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerId { get; set; }

    public Player(int playerId)
    {
        PlayerId = playerId;
    }
    public int Coins { get; set; }
    public Inventory<Item> ItemInventory { get; private set; }
    public Inventory<Event> EventInventory { get; private set; }

    void Awake()
    {
        Coins = 100;
        ItemInventory = new Inventory<Item>();
        EventInventory = new Inventory<Event>();
    }

    public void Initialize(int playerId)
    {
        PlayerId = playerId;
    }

    public override string ToString()
    {
        return $"Player {PlayerId} with {Coins} coins, Items: {ItemInventory}, Events: {EventInventory}";
    }
}

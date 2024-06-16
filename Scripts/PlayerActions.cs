using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions
{
    public void Shop(Player player, Shop shop)
    {
        Debug.Log($"Player {player.PlayerId} is shopping.");

        // Example: Player chooses an item to buy (in a real game, you would get this input from the player)
        int itemIdToBuy = 1; // Example item ID
        shop.BuyItem(player, itemIdToBuy);
    }

    public void UseItem(Player player, Item item)
    {
        Debug.Log($"Player {player.PlayerId} is using item {item.itemName}.");
        // Implement item usage logic
        // Example: player.UseItem(item);
    }

    public void UseWildcard(Player player, Item wildcard, List<Player> players)
    {
        if (wildcard.cardType != "Wildcard")
        {
            Debug.LogError("Item is not a wildcard.");
            return;
        }

        Debug.Log($"Player {player.PlayerId} is using wildcard {wildcard.itemName}.");

        
        switch (wildcard.itemName)
        {
           // add cards from card database
        }

        // Remove the wildcard from the player's inventory after use
        player.ItemInventory.RemoveItem(wildcard);
    }

    private void AddRandomItem(Player player)
    {
        Item newItem = new Item(999, "Random Item", "Regular", 0, 0, "A random item", null); // Example item
        player.ItemInventory.AddItem(newItem);
        Debug.Log($"Player {player.PlayerId} received a random item.");
    }

    private void RemoveRandomItem(Player currentPlayer, List<Player> players)
    {
        // Select a random player other than the current player
        Player targetPlayer = players[Random.Range(0, players.Count)];
        while (targetPlayer == currentPlayer)
        {
            targetPlayer = players[Random.Range(0, players.Count)];
        }

        // Remove a random item from the target player's inventory
        List<Item> items = targetPlayer.ItemInventory.GetItems();
        if (items.Count > 0)
        {
            Item itemToRemove = items[Random.Range(0, items.Count)];
            targetPlayer.ItemInventory.RemoveItem(itemToRemove);
            Debug.Log($"Player {targetPlayer.PlayerId} had item {itemToRemove.itemName} removed.");
        }
        else
        {
            Debug.Log($"Player {targetPlayer.PlayerId} has no items to remove.");
        }
    }

    private void DoubleCoins(Player player)
    {
        player.Coins *= 2;
        Debug.Log($"Player {player.PlayerId} now has {player.Coins} coins.");
    }
}

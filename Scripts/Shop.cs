using System.Collections.Generic;
using UnityEngine;

public class Shop: MonoBehaviour
{
    private List<Item> availableItems;

    public Shop()
    {
        availableItems = new List<Item>();
        // Initialize the shop with some items
        availableItems.Add(new Item(1, "Coin", "Currency", 10, 0, "A shiny gold coin", null));
        availableItems.Add(new Item(2, "Wildcard", "Special", 50, 0, "A special wildcard", null));
        // Add more items as needed
    }

    public bool BuyItem(Player player, int itemId)
    {
        Item itemToBuy = availableItems.Find(item => item.id == itemId);
        if (itemToBuy != null)
        {
            if (player.Coins >= itemToBuy.cost)
            {
                player.Coins -= itemToBuy.cost;
                player.ItemInventory.AddItem(itemToBuy);
                Debug.Log($"Player {player.PlayerId} bought {itemToBuy.itemName}.");
                return true;
            }
            else
            {
                Debug.Log($"Player {player.PlayerId} does not have enough coins to buy {itemToBuy.itemName}.");
            }
        }
        else
        {
            Debug.Log("Item not found in the shop.");
        }
        return false;
    }

    public List<Item> GetAvailableItems()
    {
        return new List<Item>(availableItems);
    }
}

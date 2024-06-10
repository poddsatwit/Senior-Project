using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static List<Item> ItemList = new List<Item>();

    // Assign Item and Values
    private void Awake()
    {
        Debug.Log("ItemDatabase Awake called");

        // Example card additions
        ItemList.Add(new Item(1, "Gumball", "Item", 1, 2, "Consume to gain 1 HP.", Resources.Load<Sprite>("") ));
        ItemList.Add(new Item(1, "Armor", "Item", 1, 2, "Gain temporary health equal to the amount of armor you have.", Resources.Load<Sprite>("") ));
        ItemList.Add(new Item(1, "Cap", "Item", 1, 2, "Gain 1 cap.", Resources.Load<Sprite>("") ));
        ItemList.Add(new Item(1, "Blank", "Item", 1, 2, "Use to give 1 blank cap to someone.", Resources.Load<Sprite>("") ));
        ItemList.Add(new Item(1, "Wildcard", "Item", 1, 2, "Gain 1 random wildcard.", Resources.Load<Sprite>("") ));

        Debug.Log("ItemDatabase.cardList.Count: " + ItemList.Count);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int id;
    public string itemName;
    public string cardType;
    public int cost;
    public int power;
    public string itemDescription;
    public Sprite spriteImage;

    public Item(int id, string itemName, string cardType, int cost, int power, string itemDescription, Sprite spriteImage)
    {
        this.id = id;
        this.itemName = itemName;
        this.cardType = cardType;
        this.cost = cost;
        this.power = power;
        this.itemDescription = itemDescription;
        this.spriteImage = spriteImage;
    }
}

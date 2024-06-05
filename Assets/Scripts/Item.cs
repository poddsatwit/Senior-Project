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

    public Item(int id, string itemName, string itemType, int cost, int power, string itemDescription, Sprite SpriteImage)
    {
        this.id = id;
        this.cardName = cardName;
        this.cardType = cardType;
        this.cost = cost;
        this.power = power;
        this.cardDescription = cardDescription;
        this.spriteImage = SpriteImage;
    }
}

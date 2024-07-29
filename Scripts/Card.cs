using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Card
{
    public int id;
    public string cardName;
    public int power;
    public string cardDescription;
    public Sprite spriteImage;

    public Card(int id, string cardName, int power, string cardDescription, Sprite SpriteImage)
    {
        this.id = id;
        this.cardName = cardName;
        this.power = power;
        this.cardDescription = cardDescription;
        this.spriteImage = SpriteImage;
    }
}

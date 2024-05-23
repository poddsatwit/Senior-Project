using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Card
{
    public int id;
    public string cardName;
    public string cardType;
    public int cost;
    public int power;
    public string cardDescription;
    public Sprite spriteImage;

    // public int addBullets
    // public int removeBullets
    // public int addHealth


    public Card()
    {

    }

    public Card(int id, string cardName, string cardType, int cost, int power, string cardDescription, Sprite SpriteImage)
    {
        this.id = id;
        this.cardName = cardName;
        this.cardType = cardType;
        this.cost = cost;
        this.power = power;
        this.cardDescription = cardDescription;
        this.spriteImage = SpriteImage;
    }
    //might have to change this. to just id, cname, ctype, etc. 
}

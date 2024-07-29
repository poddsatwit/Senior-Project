using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject
{
    public Sprite sprite;
    public string Name;
    public int Coins;
    public int Ammo;
    public int Health;
    public List<Card> Cardlist;
    public bool CardActive;
    public int ActiveCardIndex;
    public PlayerObject(Sprite sprite, string Name, int Coins, int Ammo, int Health)
    {
        this.sprite = sprite;
        this.Name = Name;
        this.Coins = Coins;
        this.Ammo = Ammo;
        this.Health = Health;
        Cardlist = new List<Card> ();
        CardActive = false;
        ActiveCardIndex = -1;
    }

    public bool hasCard()
    {
        return Cardlist.Count != 0;
    }

}

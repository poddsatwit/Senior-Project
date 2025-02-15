using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    // Assign Cards and Values
    private void Awake()
    {
        Debug.Log("CardDatabase Awake called");

        cardList.Add(new Card(1, "Ammo Crate", 1, "+5 Ammo", Resources.Load<Sprite>("Assets/Visuals/cardbackskull") ));
        cardList.Add(new Card(2, "Full Heal", 1, "+3 Health", Resources.Load<Sprite>("Assets/Visuals/Wildcard (no Border)")));
        cardList.Add(new Card(3, "Shared Fate", 1, "Any damage taken is also taken by opponent", Resources.Load<Sprite>("Assets/Visuals/Wildcard (no Border)")));
        cardList.Add(new Card(4, "Double Down", 1, "Next shot does double damage, if you misfire you deal one damage to yourself.", Resources.Load<Sprite>("Assets/Visuals/cardbackgun")));
      //  cardList.Add(new Card(4, "Wild Wild West", 1, "Random effect of any other wild card.", Resources.Load<Sprite>("Assets/Visuals/Wildcard (no Border)")));
      //  cardList.Add(new Card(5, "Drawing a Blank", 1, "Select one player and insert a blank cap into their blaster, shuffle the caps in their blaster. Does not work if blaster is full.", Resources.Load<Sprite>("Assets/Visuals/Wildcard (no Border)")));
      //  cardList.Add(new Card(6, "Clairvoyance", 0, "See the next cap on your blaster or someone else�s.", Resources.Load<Sprite>("Assets/Visuals/Wildcard (no Border)")));
       // cardList.Add(new Card(7, "Clean Shuffle", 0, "Shuffle someone�s caps or yours.", Resources.Load<Sprite>("Assets/Visuals/Wildcard (no Border)")));
       // cardList.Add(new Card(8, "True Shuffle", 0, "Get everyone�s caps and shuffle them evenly across everyone�s blaster.", Resources.Load<Sprite>("Assets/Visuals/Wildcard (no Border)")));
      //  cardList.Add(new Card(9, "Wanted", 1, "Mark someone for death, WHOEVER eliminates them gains HP.", Resources.Load<Sprite>("Assets/Visuals/Wildcard (no Border)")));
        cardList.Add(new Card(5, "Collecting Dues", 0, "Take 1 cap from someone and load it into your blaster.", Resources.Load<Sprite>("Assets/Visuals/cardbackgoldcoin")));

        Debug.Log("CardDatabase.cardList.Count: " + cardList.Count);
    }
}

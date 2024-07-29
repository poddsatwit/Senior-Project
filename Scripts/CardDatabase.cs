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

        cardList.Add(new Card(1, "Shared Fate", 2, "Chose another player. This round, any time one of you take damage, so will the other.", Resources.Load<Sprite>("Assets/Visuals/Wildcard (no Border)") ));
        cardList.Add(new Card(2, "No U", 2, "This round, any damage that you would take send back to the player that tried to hurt you.", Resources.Load<Sprite>("Assets/Visuals/Wildcard (no Border)")));
        cardList.Add(new Card(3, "Double Down", 2, "Your next shot will do double damage, but if you fail to fire you deal one damage to yourself.", Resources.Load<Sprite>("Assets/Visuals/Wildcard (no Border)")));
        cardList.Add(new Card(4, "Wild Wild West", 1, "Random effect of any other wild card.", Resources.Load<Sprite>("Assets/Visuals/Wildcard (no Border)")));
        cardList.Add(new Card(5, "Drawing a Blank", 1, "Select one player and insert a blank cap into their blaster, shuffle the caps in their blaster. Does not work if blaster is full.", Resources.Load<Sprite>("Assets/Visuals/Wildcard (no Border)")));
        cardList.Add(new Card(6, "Clairvoyance", 0, "See the next cap on your blaster or someone else’s.", Resources.Load<Sprite>("Assets/Visuals/Wildcard (no Border)")));
        cardList.Add(new Card(7, "Clean Shuffle", 0, "Shuffle someone’s caps or yours.", Resources.Load<Sprite>("Assets/Visuals/Wildcard (no Border)")));
        cardList.Add(new Card(8, "True Shuffle", 0, "Get everyone’s caps and shuffle them evenly across everyone’s blaster.", Resources.Load<Sprite>("Assets/Visuals/Wildcard (no Border)")));
        cardList.Add(new Card(9, "Wanted", 1, "Mark someone for death, WHOEVER eliminates them gains HP.", Resources.Load<Sprite>("Assets/Visuals/Wildcard (no Border)")));
        cardList.Add(new Card(10, "Collecting Dues", 0, "Take 1 cap from someone and load it into your blaster.", Resources.Load<Sprite>("Assets/Visuals/Wildcard (no Border)")));

        Debug.Log("CardDatabase.cardList.Count: " + cardList.Count);
    }
}

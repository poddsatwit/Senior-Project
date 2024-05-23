using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class WildCardDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public int x;
    public List<Card> container = new List<Card>();
    public int deckSize;
    // Start is called before the first frame update
    void Start()
    {
        x = 0;

        for (int i = 0; i < deck.Count; i++)
        {
            x = Random.Range(1, 4);
            Card card = CardDatabase.cardList[x];
            deck[i] = card;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShuffleDeck()
    {
        // if (WildAgainst == CardDatabase.cardList[null])
       // {
        for (int i = 0; i < deckSize;i++)
        {
            container[0] = deck[i];
            int randomIndex = Random.Range(0, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];

        }
      //  }
    }
}

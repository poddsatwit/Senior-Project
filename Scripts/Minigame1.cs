using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame1 : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Text turn;

    public Sprite[] cardImages;
    [SerializeField] public Transform grid;
    public GameObject cardPrefab;

    private List<GameObject> memoryCards = new List<GameObject>();
    private List<int> cardIndices = new List<int>();
    private GameObject firstCard;
    private GameObject secondCard;

    private void Start()
    {
        setTurnInd();
        button.onClick.AddListener(OnButtonPress);
        initializeGame();
    }

    private void setTurnInd()
    {
        if (GameManager.Instance.getPlayerTurn() == 1)
        {
            turn.text = GameManager.Instance.getPlayer1().Name;
        }
        else
        {
            turn.text = GameManager.Instance.getPlayer2().Name;
        }
    }

    private void OnButtonPress()
    {
        if (GameManager.Instance.getPlayerTurn() == 1)
        {
            GameManager.Instance.setPlayerTurn(2);
            GameManager.Instance.UpdateGameState(GameManager.Gamestate.Minigame1);
        }
        else
        {
            GameManager.Instance.setPlayerTurn(1);
            GameManager.Instance.UpdateGameState(GameManager.Gamestate.PlayerTurn);
        }
    }

    void initializeGame()
    {
        for (int i = 0; i < cardImages.Length; i++)
        {
            cardIndices.Add(i);
            cardIndices.Add(i);
        }
        shuffleCards(cardIndices);

        for (int i = 0; i < cardIndices.Count; i++)
        {
            GameObject card = Instantiate(cardPrefab, grid);
            card.GetComponent<MemoryCard>().Setup(cardImages[cardIndices[i]], cardIndices[i]);
            memoryCards.Add(card);
        }
    }


    private void shuffleCards(List<int> cardIdxList)
    {
        for (int i = 0; i < cardIdxList.Count; i++)
        {
            int temp = cardIdxList[i];
            System.Random random = new System.Random();
            int randomIdx = random.Next(0, cardIdxList.Count);
            cardIdxList[i] = cardIdxList[randomIdx];
            cardIdxList[randomIdx] = temp;
        }
    }

    public void CardClicked(GameObject card)
    {
        if (firstCard == null)
        {
            firstCard = card;
        }
        else if (secondCard == null)
        {
            secondCard = card;
            CheckMatch();
        }
    }

    void CheckMatch()
    {
        if (firstCard.GetComponent<MemoryCard>().cardIndex == secondCard.GetComponent<MemoryCard>().cardIndex)
        {
            // Match found, keep both cards flipped
            firstCard.GetComponent<Button>().interactable = false;
            secondCard.GetComponent<Button>().interactable = false;
            firstCard = null;
            secondCard = null;
        }
        else
        {
            // No match, flip both cards back after a short delay
            StartCoroutine(FlipBackCards());
        }
    }

    System.Collections.IEnumerator FlipBackCards()
    {
        yield return new WaitForSeconds(1f);
        firstCard.GetComponent<MemoryCard>().FlipCard(false);
        secondCard.GetComponent<MemoryCard>().FlipCard(false);
        firstCard = null;
        secondCard = null;
    }
}

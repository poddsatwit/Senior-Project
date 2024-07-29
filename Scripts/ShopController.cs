using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private Button buyBullet;
    [SerializeField] private Button buyHeal;
    [SerializeField] private Button buyCard;
    [SerializeField] private Button returnButton;
    [SerializeField] private Text coins;
    [SerializeField] private Text tooManyCard;
    public GameObject heartPrefab;
    public Transform heartsContainer;
    private List<Card> cardList;

    private PlayerObject player;
    private void Start()
    {
        initializePData();
        buyBullet.onClick.AddListener(OnBuyBulletClicked);
        returnButton.onClick.AddListener(OnreturnButtonClicked);
        buyHeal.onClick.AddListener(OnBuyHealClicked);
        buyCard.onClick.AddListener(OnBuyCardClicked);
    }

    private void AddCard()
    {
        if (player.Cardlist.Count <= 3)
        {
            System.Random rnd = new System.Random();
            int randIndex = rnd.Next(0, CardDatabase.cardList.Count);
            player.Cardlist.Add(CardDatabase.cardList[randIndex]);
        }
        else
        {
            {
                tooManyCard.text = player.Name + " already has max cards!";
                //text timer 3 sec
            }
        }
    }

    private void OnBuyCardClicked()
    {
        if (player.Coins > 2)
        {
            player.Coins = player.Coins-3;
            coins.text = player.Coins.ToString();
            AddCard();
        }
    }

    private void OnBuyHealClicked()
    {
        Debug.Log("Pressed");
        if (player.Coins > 1)
        {
            player.Coins = player.Coins-2;
            player.Health++;
            coins.text = player.Coins.ToString();

        }
    }

    private void initializePData()
    {
        if(GameManager.Instance.getPlayerTurn() == 1 )
        {
            player = GameManager.Instance.getPlayer1();
            coins.text = "Coins: " + player.Coins.ToString();
        }
        else
        {
            player = GameManager.Instance.getPlayer2();
            coins.text = "Coins: " + player.Coins.ToString();
        }
    }

    private void OnreturnButtonClicked()
    {
        GameManager.Instance.UpdateGameState(GameManager.Gamestate.PlayerTurn);
    }

    private void OnBuyBulletClicked()
    {
        if(player.Coins > 0)
        {
            player.Coins--;
            player.Ammo++;
            coins.text = player.Coins.ToString();
        }
    }
}

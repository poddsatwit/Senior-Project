using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private Button buyBullet;
    [SerializeField] private Button returnButton;
    [SerializeField] private Text coins;

    private PlayerObject player;
    private void Start()
    {
        initializePData();
        buyBullet.onClick.AddListener(OnBuyBulletClicked);
        returnButton.onClick.AddListener(OnreturnButtonClicked);
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

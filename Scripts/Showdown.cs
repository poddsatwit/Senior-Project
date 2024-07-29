using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Showdown : MonoBehaviour
{
    [SerializeField] private Button attackButton;
    [SerializeField] private Button endTurnButton;
    // [SerializeField] private Player Player1;
    [SerializeField] private SpriteRenderer playersprite;
    [SerializeField] private SpriteRenderer enemysprite;

    [SerializeField] private Text Coins;
    [SerializeField] private Text Ammo;
    [SerializeField] private Text Health;
    private PlayerObject currentPlayer;
    [SerializeField] private Text Damage;
    [SerializeField] private Button selectCard;
    [SerializeField] private Text NoCards;

    private int doubleDmg = 1;
    private bool reflectDmg = false;

    private void Start()
    {
        reflectDmg = GameManager.Instance.reflectDamage;
        GameManager.Instance.reflectDamage = false;
        initializePlayers();
        useCard();
        attackButton.onClick.AddListener(OnAttackButtonClicked);
        endTurnButton.onClick.AddListener(OnEndTurnButtonClicked);
        selectCard.onClick.AddListener(OnselectCardClicked);
    }

    private void useCard()
    {
        if (!currentPlayer.CardActive)
        {
            return;
        }
        Card card = currentPlayer.Cardlist[currentPlayer.ActiveCardIndex];
        if (card.id == 1)
        {
            currentPlayer.Ammo += 5;
        }
        else if (card.id == 2)
        {
            currentPlayer.Health += 3;
        }
        else if (card.id == 3)
        {
            GameManager.Instance.reflectDamage = true;
        }
        else if (card.id == 4)
        {
            doubleDmg = 2;
        } 
        else if (card.id == 5) {
            PlayerObject otherPlayer = null;
            if (GameManager.Instance.getPlayerTurn() == 1)
            {
                otherPlayer = GameManager.Instance.getPlayer2();
            } 
            else
            {
                otherPlayer = GameManager.Instance.getPlayer1();
            }
            if (otherPlayer.Ammo > 1)
            {
                otherPlayer.Ammo--;
                currentPlayer.Ammo++;
            } 
            else
            {
                NoCards.text = "Opponent has no caps to commandeer!";
            }
        }
    }

    private void OnselectCardClicked()
    {
        Debug.Log("Card");
        if(!currentPlayer.hasCard())
        {
            NoCards.text = currentPlayer.Name + " has no Wildcards!";
        }
        else if(currentPlayer.CardActive)
        {
            NoCards.text = currentPlayer.Name + " is already using a Card!";
        }
        else
        {
            {
                GameManager.Instance.UpdateGameState(GameManager.Gamestate.WildcardSelection);
            }
        }
    }

    private void OnAttackButtonClicked()
    {
        if (currentPlayer.Ammo > 0)
        {
            currentPlayer.Ammo--;
            System.Random random = new System.Random();
            int ChanceDamage = random.Next(1, 101);
            if (ChanceDamage == 1)
            {
                attack(3);
            }
            else if (ChanceDamage <= 16)
            {
                attack(2);
            }
           
            else if (ChanceDamage <= 91)
            {
                attack(1);
            }
            else
            {
                Damage.text = "Missfire!!!";
            }
        }
        checkHealth();
        Ammo.text = currentPlayer.Ammo.ToString();
    }
    private void attack(int attPower)
    {
       attPower = attPower * doubleDmg;
       doubleDmg = 1;
       Damage.text = currentPlayer.Name + "'s Attack did " + attPower.ToString() + " damage!";
       if(GameManager.Instance.getPlayerTurn() == 1)
        {
            GameManager.Instance.getPlayer2().Health -= attPower;
            if (reflectDmg)
            {
                GameManager.Instance.getPlayer1().Health -= attPower;
            }
        }
        else
        {
            GameManager.Instance.getPlayer1().Health -= attPower;
            if (reflectDmg)
            {
                GameManager.Instance.getPlayer2().Health -= attPower;
            }
        }
    }
    private void OnEndTurnButtonClicked()
    {
        currentPlayer.CardActive = false;
        currentPlayer.ActiveCardIndex = -1;
        GameManager.Instance.UpdateGameState(GameManager.Gamestate.Showdown);
        if (GameManager.Instance.getPlayerTurn() == 1)
        {
            GameManager.Instance.setPlayerTurn(2);
        }
        else
        {
            GameManager.Instance.setPlayerTurn(1);
        }
    }


    private void initializePlayers()
    {
        if (GameManager.Instance.getPlayerTurn() == 1)
        {
            PlayerObject playerObj1 = GameManager.Instance.getPlayer1();
            playersprite.sprite = playerObj1.sprite;
            Coins.text = "Coins: " + playerObj1.Coins;
            Ammo.text = "Ammo: " + playerObj1.Ammo;
            Health.text = "Health: " + playerObj1.Health.ToString();
            currentPlayer = playerObj1;
        }
        else
        {
            PlayerObject playerObj2 = GameManager.Instance.getPlayer2();
            playersprite.sprite = enemysprite.sprite;
            Coins.text = "Coins: " + playerObj2.Coins;
            Ammo.text = "Ammo: " + playerObj2.Ammo;
            enemysprite.sprite = GameManager.Instance.getPlayer1().sprite;
            Health.text = "Health: " + playerObj2.Health.ToString();
            currentPlayer = playerObj2;
        }

    }
    private void checkHealth()
    {
        // case 1 is a draw
        if (GameManager.Instance.getPlayer1().Health <= 0 && GameManager.Instance.getPlayer2().Health <= 0)
        {
            GameManager.Instance.UpdateGameState(GameManager.Gamestate.Victory);
            GameManager.Instance.setVictor("DRAW!");
        } 
        else if (GameManager.Instance.getPlayerTurn() == 1)
        {
            if(GameManager.Instance.getPlayer2().Health <= 0)
            {
                GameManager.Instance.UpdateGameState(GameManager.Gamestate.Victory);
                GameManager.Instance.setVictor(currentPlayer.Name);
            }
        }
        else
        {
             if (GameManager.Instance.getPlayer1().Health <= 0)
            {
                GameManager.Instance.UpdateGameState(GameManager.Gamestate.Victory);
                GameManager.Instance.setVictor(currentPlayer.Name);
            }
        }
    }
}

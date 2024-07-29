using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurn : MonoBehaviour
{
    [SerializeField] private Button shopButton;
    [SerializeField] private Button endTurnButton;
    [SerializeField] private SpriteRenderer playersprite;
    [SerializeField] private SpriteRenderer enemysprite;
    [SerializeField] private Text roundText;
    [SerializeField] private Text Coins;
    [SerializeField] private Text Ammo;
    [SerializeField] private GameObject Health;
    public GameObject heartPrefab;
    public Transform heartsContainer;
    private List<GameObject> hearts = new List<GameObject>();
    private PlayerObject currentPlayer;
    [SerializeField] private Text NoCards;

    private void Start()
    {
        initializePlayers();
        roundText.text = "Round: " + GameManager.Instance.getRound();
        shopButton.onClick.AddListener(OnShopButtonClicked);
        endTurnButton.onClick.AddListener(OnEndTurnButtonClicked);
    }
    private void OnselectCardClicked()
    {
        if (!currentPlayer.hasCard())
        {
            NoCards.text = currentPlayer.Name + " has no Wildcards!";
        }
        else
        {
            {
                GameManager.Instance.UpdateGameState(GameManager.Gamestate.WildcardSelection);
            }
        }
    }

    private void initializePlayers()
    {
        if(GameManager.Instance.getPlayerTurn() == 1)
            {
            if (GameManager.Instance.getPlayer1() == null)
            {
                Character char1 = GameManager.Instance.getCharacter();
                PlayerObject play1 = new PlayerObject(char1.sprite, char1.Charactername, 3, 0, 3);
                GameManager.Instance.setPlayer1(play1);
            }
            PlayerObject playerObj1 = GameManager.Instance.getPlayer1();
            playersprite.sprite = playerObj1.sprite;
            Coins.text = "Coins: " + playerObj1.Coins;
            Ammo.text = "Ammo: " + playerObj1.Ammo;
        }
        else
        {
            if(GameManager.Instance.getPlayer2()==null)
            {
                PlayerObject play2 = new PlayerObject(Resources.Load<Sprite>("Visuals/bartender.psb"), "player 2", 3, 0, 3);
                GameManager.Instance.setPlayer2(play2);
            }
            PlayerObject playerObj2 = GameManager.Instance.getPlayer2();
            playersprite.sprite = enemysprite.sprite;
            Coins.text = "Coins: " + playerObj2.Coins;
            Ammo.text = "Ammo: " + playerObj2.Ammo;
            enemysprite.sprite = GameManager.Instance.getPlayer1().sprite;
        }
        
    }

    private void OnEndTurnButtonClicked()
    {
        GameManager.Instance.UpdateGameState(GameManager.Gamestate.EnemyTurn);
        if(GameManager.Instance.getPlayerTurn() == 1)
        {
            GameManager.Instance.setPlayerTurn(2);
        }
        else
        {
            GameManager.Instance.setPlayerTurn(1);
            GameManager.Instance.incrementRound();

            if (GameManager.Instance.getRound() == 2)
            {
                GameManager.Instance.UpdateGameState(GameManager.Gamestate.Minigame1);
            }
            else if(GameManager.Instance.getRound() == 3)
            {
                GameManager.Instance.UpdateGameState(GameManager.Gamestate.Minigame2);
            }
            else if (GameManager.Instance.getRound() == 4)
            {
                GameManager.Instance.UpdateGameState(GameManager.Gamestate.Showdown);
            }
        }
    }

    private void OnShopButtonClicked()
    {
        GameManager.Instance.UpdateGameState(GameManager.Gamestate.Shop);
    }
    void AddHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab, heartsContainer);
        hearts.Add(newHeart);
    }
}

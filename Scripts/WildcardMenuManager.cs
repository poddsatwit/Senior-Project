using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class WildcardMenuManager : MonoBehaviour
{
    [SerializeField] private Button nextCard;
    [SerializeField] private Button prevCard;
    [SerializeField] private Button selectCard;
    [SerializeField] private SpriteRenderer spriteRenderer1;
    [SerializeField] private SpriteRenderer spriteRenderer2;
    [SerializeField] private SpriteRenderer spriteRenderer3;
    [SerializeField] private Text Name;
    [SerializeField] private Text Desc;
    private int selectedOption;
    public SpriteRenderer artworkSprite;

    private PlayerObject player;

    private void Start()
    {
        selectedOption = 0;
        initializePData();
        nextCard.onClick.AddListener(OnNextButtonClicked);
        prevCard.onClick.AddListener(OnPrevButtonClicked);
        selectCard.onClick.AddListener(OnSelectCardClicked);

    }

    private void OnSelectCardClicked()
    {
        player.CardActive = true;
        player.ActiveCardIndex = selectedOption;
        GameManager.Instance.UpdateGameState(GameManager.Gamestate.Showdown);
    }

    private void OnNextButtonClicked()
    {
        nextcard();
    }
    private void OnPrevButtonClicked()
    {
        previousCard();
    }
    private void nextcard()
    {
        selectedOption++;

        if (selectedOption >= player.Cardlist.Count)
        {
            selectedOption = 0;
        }
        UpdateCard(selectedOption);
    }
    public void previousCard()
    {
        selectedOption--;

        if (selectedOption < 0)
        {
            selectedOption = player.Cardlist.Count - 1;
        }
        UpdateCard(selectedOption);
    }
    private void UpdateCard(int selectedOption)
    {
        Card card = player.Cardlist[selectedOption];
        artworkSprite.sprite = card.spriteImage;
        Name.text = card.cardName;
    }

    private void initializePData()
        {
            if (GameManager.Instance.getPlayerTurn() == 1)
            {
                player = GameManager.Instance.getPlayer1();
            }
            else
            {
                player = GameManager.Instance.getPlayer2();
            }
        }
    }

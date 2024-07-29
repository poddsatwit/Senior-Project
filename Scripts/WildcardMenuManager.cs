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
    [SerializeField] private Button backButton;
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
        backButton.onClick.AddListener(OnBackButtonClicked);

    }

    private void OnBackButtonClicked()
    {
        GameManager.Instance.UpdateGameState(GameManager.Gamestate.Showdown);
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
        Sprite loadedSprite = Resources.Load<Sprite>("cardbackeye.psb");
        if (loadedSprite != null)
        {
            // Assign the loaded sprite to the SpriteRenderer component
            artworkSprite.sprite = loadedSprite;
        }
        else
        {
            Debug.LogError("Failed to load sprite from path: " + "Assets/Resources/cardbackskull.psb");
        }
        Card card = player.Cardlist[selectedOption];
      
      //  artworkSprite.sprite = card.spriteImage;
        Name.text = card.cardName;
        Desc.text = card.cardDescription;
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

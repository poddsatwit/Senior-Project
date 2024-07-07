using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerId;
    public bool IsActive { get; private set; }
    public List<Item> Inventory { get; private set; }
    public int ItemsUsedThisTurn { get; private set; }
    public bool IsHighlighted { get; private set; }
    public bool IsSelected { get; private set; }
    private Renderer playerRenderer;
    private Material originalMaterial;
    public Material highlightMaterial;
    public Material selectMaterial;

    public AudioClip selectionAudioClip;
    private AudioSource audioSource;
    private Animator animator;
    public AudioClip targetSelectedClip;
    private int[,] puzzle;
    public CharacterDatabase characterDB;
    public SpriteRenderer artworkSprite;
    private int selectedOption;

    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        originalMaterial = playerRenderer.material;
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    public Player(int playerId)
    {
        PlayerId = playerId;
        Inventory = new List<Item>();
        ItemsUsedThisTurn = 0;
    }
    public void StartTurn()
    {
        IsActive = true;
        Debug.Log("Player " + PlayerId + "'s turn starts.");

        // Reset the number of items used this turn
        ItemsUsedThisTurn = 0;

        // Update the UI to highlight the current player
        UpdateUIForTurnStart();

        // Enable player controls for this turn
        EnablePlayerControls();

        // Any additional logic to start the player's turn
        // For example, you might want to draw a card, regenerate action points, etc.
    }

    public void EndTurn()
    {
        IsActive = false;
        Debug.Log("Player " + PlayerId + "'s turn ends.");

        // Update the UI to indicate the turn has ended
        UpdateUIForTurnEnd();

        // Disable player controls at the end of the turn
        DisablePlayerControls();

        // Any additional logic to end the player's turn
        // For example, you might want to discard cards, reset temporary buffs, etc.
    }

    private void UpdateUIForTurnStart()
    {
        // Implement UI logic to highlight the current player
        // This might include showing a turn indicator, highlighting the player's UI panel, etc.
    }

    private void UpdateUIForTurnEnd()
    {
        // Implement UI logic to show the turn has ended
        // This might include hiding the turn indicator, dimming the player's UI panel, etc.
    }

    private void EnablePlayerControls()
    {
        // Implement logic to enable controls for the current player
        // This might include enabling UI buttons, allowing input for character movement, etc.
    }

    private void DisablePlayerControls()
    {
        // Implement logic to disable controls for the current player
        // This might include disabling UI buttons, preventing input for character movement, etc.
    }
    public void ApplyItemEffect(Item item)
    {
        // Implement the logic for applying item effects
        // E.g., reducing health, applying status effects, etc.
    }
    public void UseItem(Item item)
    {
        ItemsUsedThisTurn++;
        // Logic to use the item, such as applying damage or effects
    }

    public void ResetTurn()
    {
        ItemsUsedThisTurn = 0;
    }
    public int Coins { get; set; }
    public Inventory<Item> ItemInventory { get; private set; }
    public Inventory<Event> EventInventory { get; private set; }

    void Awake()
    {
        Coins = 100;
        ItemInventory = new Inventory<Item>();
        EventInventory = new Inventory<Event>();
    }

    public void Initialize(int playerId)
    {
        PlayerId = playerId;
    }

    public override string ToString()
    {
        return $"Player {PlayerId} with {Coins} coins, Items: {ItemInventory}, Events: {EventInventory}";
    }
    void OnMouseEnter()
    {
        if (!IsSelected)
        {
            Highlight();
        }
    }
    void OnMouseExit()
    {
        if (!IsSelected)
        {
            Unhighlight();
        }
    }
    void OnMouseDown()
    {
        Select();
    }

    public void Highlight()
    {
        playerRenderer.material = highlightMaterial;
        IsHighlighted = true;
    }

    public void Unhighlight()
    {
        playerRenderer.material = originalMaterial;
        IsHighlighted = false;
    }

    public void Select()
    {
        playerRenderer.material = selectMaterial;
        IsSelected = true;
        PlaySelectionAudio();
    }

    public void Deselect()
    {
        playerRenderer.material = originalMaterial;
        IsSelected = false;
    }

    private void PlaySelectionAudio()
    {
        if (audioSource != null && selectionAudioClip != null)
        {
            audioSource.PlayOneShot(selectionAudioClip);
        }
    }

    public void PlayTargetSelectedAudio()
    {
        if (audioSource != null && targetSelectedClip != null)
        {
            audioSource.PlayOneShot(targetSelectedClip);
        }
    }
    public void PlayAimAnimation()
    {
        animator.SetTrigger("Aim");
    }

    public void PlayDamageAnimation()
    {
        animator.SetTrigger("Damage");
    }

    // 8 Puzzle Game
    public void SetPuzzle(int[,] puzzle)
    {
        this.puzzle = puzzle;
        DisplayPuzzle();
    }
    void DisplayPuzzle()
    {
        // Display the puzzle to the player
        // This could involve updating the UI or positioning tile GameObjects
    }

    // Implement the puzzle-solving logic here
    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.character[selectedOption];
        artworkSprite.sprite = character.CharacterSprite;
    }

}

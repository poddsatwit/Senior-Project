using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerId;
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
}

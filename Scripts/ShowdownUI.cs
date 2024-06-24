using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowdownUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject targetingPanel;
    public Button endTurnButton;
    private ShowdownManager showdownManager;

    void Start()
    {
        showdownManager = FindObjectOfType<ShowdownManager>();

        endTurnButton.onClick.AddListener(() => showdownManager.EndPlayerTurn());
    }

    public void ShowInventory(Player player)
    {
        // Populate inventory UI with player's items
    }

    public void ShowTargeting(Player currentPlayer, List<Player> otherPlayers)
    {
        // Populate targeting UI with other players
    }
}

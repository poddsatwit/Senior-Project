using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowdownManager : MonoBehaviour
{
    private GameManager gameManager;
    private int currentPlayerIndex;
    private List<Player> players;
    private Player selectedTarget; 
    public Text turnIndicatorText;
    public GameObject selectionEffectPrefab;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        players = new List<Player>(gameManager.Players.Values);
        currentPlayerIndex = 0;
        StartPlayerTurn();
    }

    void StartPlayerTurn()
    {
        Player currentPlayer = players[currentPlayerIndex];
        currentPlayer.ResetTurn();
        EnablePlayerUI(currentPlayer);
        selectedTarget = null;
        UpdateTurnIndicator();
    }

    void EnablePlayerUI(Player player)
    {
        // Enable inventory UI and targeting UI for the current player
    }

    public void SelectTarget(Player targetPlayer)
    {
        if (selectedTarget != null)
        {
            selectedTarget.Deselect();
        }
        selectedTarget = targetPlayer;
        selectedTarget.Select();

        Instantiate(selectionEffectPrefab, selectedTarget.transform.position, Quaternion.identity);
    }
    void UpdateTurnIndicator()
    {
        Player currentPlayer = players[currentPlayerIndex];
        turnIndicatorText.text = $"Player {currentPlayer.PlayerId}'s Turn";
    }


    public void EndPlayerTurn()
    {
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
        StartPlayerTurn();
    }

    public void UseItem(Item item)
    {
        Player currentPlayer = players[currentPlayerIndex];

        if (selectedTarget != null)
        {
            currentPlayer.PlayAimAnimation();
            selectedTarget.PlayDamageAnimation();
            selectedTarget.ApplyItemEffect(item);
            currentPlayer.Inventory.Remove(item);
            currentPlayer.UseItem(item);

            if (currentPlayer.ItemsUsedThisTurn >= 2)
            {
                EndPlayerTurn();
            }
        }
        else
        {
            Debug.Log("No target selected.");
        }
    }
}

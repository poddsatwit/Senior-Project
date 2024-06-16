using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurnManager
{
    private List<Player> players;
    private PlayerActions playerActions;
    private MinigameRound minigameRound;
    private Shop shop;

    public TurnManager(List<Player> players)
    {
        this.players = players;
        playerActions = new PlayerActions();
        minigameRound = new MinigameRound();
        shop = new Shop();
    }

    public void RunTurnCycle()
    {
        foreach (var player in players)
        {
            // Player turn: Shop
            playerActions.Shop(player, shop);

            // Player turn: Use Item (example usage, you can add more complex logic)
            if (player.ItemInventory.GetItems().Count > 0)
            {
                playerActions.UseItem(player, player.ItemInventory.GetItems()[0]);
            }

            // Example: Allow player to use a wildcard if they have one
            Item wildcard = player.ItemInventory.GetItems().Find(item => item.cardType == "Wildcard");
            if (wildcard != null)
            {
                playerActions.UseWildcard(player, wildcard, players);
            }
        }

        // After all players have taken their turns, play a round of minigames
        minigameRound.PlayRound(players);
    }
}

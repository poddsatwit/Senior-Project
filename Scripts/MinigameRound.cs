using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameRound
{
    //temp for now
    public void PlayRound(List<Player> players)
    {
        // Implement minigame logic
        Debug.Log("Playing a round of minigames.");

        foreach (var player in players)
        {
            // Implement minigame logic for each player
            Debug.Log($"Player {player.PlayerId} is playing the minigame.");
        }
    }
}

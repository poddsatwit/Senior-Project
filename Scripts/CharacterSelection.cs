using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public List<Sprite> characterSprites; // List of available character sprites
    public List<Button> characterButtons; // Buttons for character selection
    private Dictionary<int, int> playerSelections; // Store player ID and their selected character index

    void Start()
    {
        playerSelections = new Dictionary<int, int>();

        // Assign button click events
        for (int i = 0; i < characterButtons.Count; i++)
        {
            int index = i; // Capture the index for the closure
            characterButtons[i].onClick.AddListener(() => SelectCharacter(index));
        }
    }

    void SelectCharacter(int characterIndex)
    {
        int playerId = GetCurrentPlayerId(); // Implement a way to get the current player ID
        if (playerSelections.ContainsKey(playerId))
        {
            playerSelections[playerId] = characterIndex;
        }
        else
        {
            playerSelections.Add(playerId, characterIndex);
        }

        Debug.Log($"Player {playerId} selected character {characterIndex}");
    }

    public Dictionary<int, int> GetPlayerSelections()
    {
        return playerSelections;
    }

    int GetCurrentPlayerId()
    {
        // Implement logic to get the current player ID
        return 1; // Example placeholder
    }
}

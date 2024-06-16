using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public GameObject playerHUD; // Assign the player's HUD in the Inspector
    public GameObject miniHUDPrefab; // Assign the mini HUD prefab in the Inspector
    public List<Transform> playerTransforms; // List of player transforms

    private Dictionary<int, GameObject> miniHUDs;
    private int currentPlayerId;

    void Start()
    {
        miniHUDs = new Dictionary<int, GameObject>();

        // Initialize mini HUDs for each player
        foreach (Transform playerTransform in playerTransforms)
        {
            GameObject miniHUD = Instantiate(miniHUDPrefab, playerTransform);
            miniHUD.SetActive(false);
            int playerId = playerTransform.GetComponent<Player>().PlayerId;
            miniHUDs.Add(playerId, miniHUD);
        }
    }

    public void SetCurrentPlayer(int playerId)
    {
        currentPlayerId = playerId;
        UpdateHUDVisibility();
    }

    void UpdateHUDVisibility()
    {
        playerHUD.SetActive(currentPlayerId == GetLocalPlayerId());

        foreach (var entry in miniHUDs)
        {
            entry.Value.SetActive(entry.Key == currentPlayerId);
        }
    }

    int GetLocalPlayerId()
    {
        // Implement logic to get the local player's ID
        return 1; // Example placeholder
    }
}

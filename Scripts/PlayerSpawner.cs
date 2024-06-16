using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform[] spawnPoints;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
            return;
        }

        SpawnPlayers();
    }

    void SpawnPlayers()
    {
        int numberOfPlayers = gameManager.Players.Count;

        for (int i = 0; i < numberOfPlayers; i++)
        {
            Transform spawnPoint = spawnPoints[i];
            GameObject playerObject = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
            Player playerScript = playerObject.GetComponent<Player>();

            if (playerScript != null)
            {
                int playerId = i + 1; // Assuming player IDs start from 1
                gameManager.AddPlayer(playerId, playerScript);
                playerScript.PlayerId = playerId; // Ensure player ID is set
            }
        }
    }
}

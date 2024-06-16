using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    private string previousScene;
    private int currentPlayerId;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }

    public void SetCurrentPlayer(int playerId)
    {
        currentPlayerId = playerId;
    }

    public void OpenShop()
    {
        if (gameManager != null && gameManager.GetCurrentPlayerId() == currentPlayerId)
        {
            previousScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("ShopScene"); // Replace with the actual name of your shop scene
        }
    }

    public void GoBack()
    {
        if (!string.IsNullOrEmpty(previousScene))
        {
            SceneManager.LoadScene(previousScene);
        }
    }
}

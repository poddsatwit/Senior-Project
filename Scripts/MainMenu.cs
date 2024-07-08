using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;
    private void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        // optionsButton.onClick.AddListener(OnOptionsButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }
    private void OnPlayButtonClicked()
    {
        GameManager.Instance.UpdateGameState(GameManager.Gamestate.CharacterSelect);
    }
    private void OnExitButtonClicked()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

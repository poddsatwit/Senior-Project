using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerObject player1 = null;
    private PlayerObject player2 = null;
    private int currentPlayerId;
    private int currentRound = 1; // Track the current round
    private static GameManager instance;
    public Gamestate State;
    public TMP_Text roundText; // Reference to the TMP_Text element to display the round
    private int playerTurn = 1;
    private int roundCount = 1;
    private string victor = "";

    public static event Action<Gamestate> Ongamestatechanged;
    private Character character;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    instance = go.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public enum Gamestate
    {
        MenuScene,
        CharacterSelect,
        OptionsMenu,
        PlayerTurn,
        Shop,
        EnemyTurn,
        Minigame1,
        Minigame2,
        Minigame3,
        Showdown,
        Victory,
        Lose
    }

    public void UpdateGameState(Gamestate newstate)
    {
        State = newstate;

        switch (newstate)
        {
            case Gamestate.MenuScene:
                HandleMenuScene();
                Debug.Log("State Change.menu");
                SceneManager.LoadScene("Scenes/Menu");
                break;
            case Gamestate.CharacterSelect:
                SceneManager.LoadScene("Scenes/CharacterSelect");
                break;
          //  case Gamestate.OptionsMenu:
          //      break;
            case Gamestate.PlayerTurn:
                SceneManager.LoadScene("Scenes/PlayerTurn");
                break;
                case Gamestate.Shop:
                SceneManager.LoadScene("Scenes/Shop Scene");
                break;
            case Gamestate.EnemyTurn:
                SceneManager.LoadScene("Scenes/PlayerTurn");
                break;
            case Gamestate.Minigame1:
                SceneManager.LoadScene("Scenes/MinigameTest1");
                break;
            case Gamestate.Minigame2:
                SceneManager.LoadScene("Scenes/MinigameTest2");
                break;
            case Gamestate.Minigame3:
                SceneManager.LoadScene("Scenes/MinigameTest3");
                break;
            case Gamestate.Showdown:
                SceneManager.LoadScene("Scenes/Showdown");
                break;
            case Gamestate.Victory:
                SceneManager.LoadScene("Scenes/Victory");
                break;
            case Gamestate.Lose:
                break;
            default:
                break;
        }
        Ongamestatechanged?.Invoke(newstate);
    }
    private Player CreatePlayerInstance(int playerId)
    {
        Player newPlayer = new Player(playerId);
        // Configure new player as needed
        return newPlayer;
    }

    // Overloaded AddPlayer to take playerId and Player instance

    public int GetCurrentPlayerId()
    {
        return currentPlayerId;
    }

    public void SetCurrentPlayerId(int playerId)
    {
        currentPlayerId = playerId;
    }

    private void HandleMenuScene()
    {
        // Implement the logic for handling the menu scene
        // This could involve setting up UI elements, displaying options, etc.
    }

  /*  private void UpdateRound<T>() where T : MinigameBase
    {
        currentRound++;
        UpdateRoundText();
    }*/

    public void UpdateRoundText()
    {
        if (roundText != null)
        {
            roundText.text = "Round " + currentRound;
        }
    }

    public void setCharacter(Character character)
    {
        this.character = character;
    }
    public Character getCharacter()
    {
        return character;
    }
    public void setPlayer1(PlayerObject Player)
    {
        this.player1 = Player;
    }

    //For Demo
    public PlayerObject getPlayer1()
    {
        return this.player1;
    }
    public void setPlayer2(PlayerObject Player)
    {
        this.player2 = Player;
    }
    public PlayerObject getPlayer2()
    {
        return this.player2;
    }
    public int getPlayerTurn()
    {
        return playerTurn;
    }
    public void setPlayerTurn(int playerturn)
    {
        this.playerTurn = playerturn;
    }
    public int getRound()
    {
        return roundCount;
    }
    public void incrementRound()
    {
        this.roundCount++;
    }
    public string getVictor()
    {

        return victor;
    }
    public void setVictor(string victor)
    {
        this.victor = victor;
    }
}

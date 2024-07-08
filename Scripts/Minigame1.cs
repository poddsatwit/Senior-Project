using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame1 : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Text turn;

    private void Start()
    {
       setTurnInd();
       button.onClick.AddListener(OnButtonPress);
    }

    private void setTurnInd()
    {
        if(GameManager.Instance.getPlayerTurn() == 1)
        {
            turn.text = GameManager.Instance.getPlayer1().Name;
        }
        else
        {
            turn.text = GameManager.Instance.getPlayer2().Name;
        }
    }

    private void OnButtonPress()
    {
        if (GameManager.Instance.getPlayerTurn() == 1)
        {
            GameManager.Instance.setPlayerTurn(2);
            GameManager.Instance.UpdateGameState(GameManager.Gamestate.Minigame1);
        }
        else
        {
            GameManager.Instance.setPlayerTurn(1);
            GameManager.Instance.UpdateGameState(GameManager.Gamestate.PlayerTurn);
        }
    }
}

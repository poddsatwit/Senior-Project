using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    [SerializeField] private Text VictoryTxt;
    [SerializeField] private Text mainVicTxt;
    private void Start()
    {
        if (GameManager.Instance.getVictor() == "DRAW!")
        {
            mainVicTxt.text = GameManager.Instance.getVictor();
            VictoryTxt.text = "There is no victor!";
        }
        else
        {
            VictoryTxt.text = GameManager.Instance.getVictor() + " Wins!";
        }
    }
}

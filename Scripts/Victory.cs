using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    [SerializeField] private Text VictoryTxt;
    private void Start()
    {
        VictoryTxt.text = GameManager.Instance.getVictor() + " Wins!";
    }
}

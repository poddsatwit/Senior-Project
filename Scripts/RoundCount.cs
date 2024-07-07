using UnityEngine;
using TMPro;

public class RoundDisplay : MonoBehaviour
{
    private TMP_Text roundText;

    private void Awake()
    {
        roundText = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        GameManager.Instance.roundText = roundText;
        UpdateRoundText();
    }

    public void UpdateRoundText()
    {
        GameManager.Instance.UpdateRoundText();
    }
}

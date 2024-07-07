using UnityEngine;
using UnityEngine.UI;

public class EndTurnButton : MonoBehaviour
{
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnEndTurnButtonClick);
    }

    void OnEndTurnButtonClick()
    {
        GameManager.Instance.EndPlayerTurn();
    }
}

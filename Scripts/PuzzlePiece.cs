using UnityEngine;
using UnityEngine.UI;

public class PuzzlePiece : MonoBehaviour
{
    private int pieceValue;
    private Vector2Int position;
    private PuzzleManager puzzleManager;
    private Text pieceText;

    public void Initialize(int pieceValue, Vector2Int position, PuzzleManager puzzleManager)
    {
        this.pieceValue = pieceValue;
        this.position = position;
        this.puzzleManager = puzzleManager;

        // Find the Text component and set its value
        pieceText = GetComponentInChildren<Text>();
        if (pieceText != null)
        {
            pieceText.text = pieceValue.ToString();
        }
    }

    void OnMouseDown()
    {
        if (puzzleManager.TryMovePiece(position))
        {
            position = new Vector2Int((int)transform.localPosition.x, (int)transform.localPosition.y);
        }
    }
}

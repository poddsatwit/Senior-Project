using UnityEngine;
using UnityEngine.UI;

public class EnsureRectTransform : MonoBehaviour
{
    public Canvas canvas;
    public RectTransform tileGrid;

    void Start()
    {
        // Ensure Canvas settings
        if (canvas.renderMode != RenderMode.ScreenSpaceCamera)
        {
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
        }

        canvas.sortingLayerName = "UI";
        canvas.sortingOrder = 1;

        // Ensure RectTransform settings
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        if (tileGrid != null)
        {
            tileGrid.anchorMin = new Vector2(0, 0);
            tileGrid.anchorMax = new Vector2(1, 1);
            tileGrid.offsetMin = new Vector2(0, 0);
            tileGrid.offsetMax = new Vector2(0, 0);
            tileGrid.anchoredPosition = new Vector2(0, 0);
        }
    }
}

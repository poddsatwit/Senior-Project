using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    public Canvas canvas;
    public Camera mainCamera;

    void Start()
    {
        if (canvas.renderMode != RenderMode.ScreenSpaceCamera)
        {
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
        }

        if (canvas.worldCamera != mainCamera)
        {
            canvas.worldCamera = mainCamera;
        }

        // Ensure sorting layer is correct
        canvas.sortingLayerName = "UI";
        canvas.sortingOrder = 1; // Make sure it's higher than the background

        // Ensure camera settings
        mainCamera.cullingMask |= (1 << LayerMask.NameToLayer("UI"));
        mainCamera.nearClipPlane = 0.1f;
        mainCamera.farClipPlane = 1000f;
    }
}

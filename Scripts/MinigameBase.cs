using UnityEngine;

public abstract class MinigameBase : MonoBehaviour
{
    public abstract void StartMinigame();
    public abstract void EndMinigame();
}

public class Minigame1 : MinigameBase
{
    public override void StartMinigame()
    {
        // Start logic for Minigame1
    }

    public override void EndMinigame()
    {
        // End logic for Minigame1
    }
}

public class Minigame2 : MinigameBase
{
    public override void StartMinigame()
    {
        // Start logic for Minigame2
    }

    public override void EndMinigame()
    {
        // End logic for Minigame2
    }
}

public class Minigame3 : MinigameBase
{
    public override void StartMinigame()
    {
        // Start logic for Minigame3
    }

    public override void EndMinigame()
    {
        // End logic for Minigame3
    }
}

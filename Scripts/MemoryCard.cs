using UnityEngine;
using UnityEngine.UI;

public class MemoryCard : MonoBehaviour
{
    public Sprite cardBack; // The back image of the card
    private Sprite cardFront; // The front image of the card
    public int cardIndex; // The index of the card

    private Image image; // The Image component
    private Button button; // The Button component
    private Minigame1 gameManager; // Reference to the GameManager

    void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        gameManager = FindObjectOfType<Minigame1>();
        button.onClick.AddListener(OnCardClicked);
    }

    public void Setup(Sprite front, int index)
    {
        cardFront = front;
        cardIndex = index;
        FlipCard(false); // Show card back initially
    }

    public void FlipCard(bool showFront)
    {
        image.sprite = showFront ? cardFront : cardBack;
    }

    void OnCardClicked()
    {
        if (image.sprite == cardBack)
        {
            FlipCard(true);
            gameManager.CardClicked(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCard : MonoBehaviour
{
    public List<Card> displayCard = new List<Card>();
    public int displayID;

    public int id;
    public string cardName;
    public string cardType;
    public int cost; // Commented out for now
    public int power; // Commented out for now
    public string cardDescription;
    public Sprite spriteImage;

    public Text nameText;
    public Text costText; // Commented out for now
    public Text powerText; // Commented out for now
    public Text descriptionText;
    public Image artImage;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        // Wait for a frame to ensure CardDatabase has time to initialize
        yield return null;

        Debug.Log("DisplayCard Start called");
        Debug.Log("CardDatabase.cardList.Count: " + CardDatabase.cardList.Count);
        Debug.Log("displayID: " + displayID);

        if (displayID >= 0 && displayID < CardDatabase.cardList.Count)
        {
            displayCard.Add(CardDatabase.cardList[displayID]);
            Debug.Log("Card added to displayCard list: " + displayCard[0].cardName);
            UpdateUI();
        }
        else
        {
            Debug.LogError("displayID is out of range");
        }
    }

    void UpdateUI()
    {
        if (displayCard.Count > 0)
        {
            Card currentCard = displayCard[0];
            id = currentCard.id;
            cardName = currentCard.cardName;
            // cost = currentCard.cost; // Commented out for now
            // power = currentCard.power; // Commented out for now
            cardDescription = currentCard.cardDescription;

            // Ensure these UI elements are properly linked in the inspector
            if (nameText != null)
            {
                nameText.text = cardName;
                Debug.Log("nameText updated: " + nameText.text);
            }
            else
            {
                Debug.LogError("nameText is not assigned in the inspector");
            }
            // if (costText != null)
            // {
            //     costText.text = cost.ToString();
            //     Debug.Log("costText updated: " + costText.text);
            // }
            // else
            // {
            //     Debug.LogError("costText is not assigned in the inspector");
            // }
            // if (powerText != null)
            // {
            //     powerText.text = power.ToString();
            //     Debug.Log("powerText updated: " + powerText.text);
            // }
            // else
            // {
            //     Debug.LogError("powerText is not assigned in the inspector");
            // }
            if (descriptionText != null)
            {
                descriptionText.text = cardDescription;
                Debug.Log("descriptionText updated: " + descriptionText.text);
            }
            else
            {
                Debug.LogError("descriptionText is not assigned in the inspector");
            }
            //test this
            if (spriteImage != null)
            {
                spriteImage = displayCard[0].spriteImage;
                artImage.sprite = spriteImage;
                Debug.Log("sprite image updatedL " + spriteImage);
            }
            else
            {
                Debug.LogError("Sprite not found in Resources");
            }

            Debug.Log("UI Updated with card info: " + cardName);
        }
        else
        {
            Debug.LogError("No card to display in displayCard list");
        }
    }
}

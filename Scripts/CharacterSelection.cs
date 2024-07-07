using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class CharacterSelection : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public static CharacterSelection instance;
    public Text nameText;
    public SpriteRenderer artworkSprite;

    private int selectedOption; 
    void Awake()
    {
        instance = this;
    }

    public void nextCharacter()
    {
        selectedOption++;

        if (selectedOption >= characterDB.characterCount)
        {
            selectedOption = 0;
        }
        UpdateCharacter(selectedOption);
        Save();
    }
        public void previousCharacter()
    {
        selectedOption--;

        if (selectedOption < 0)
        {
            selectedOption = characterDB.characterCount;
        }
        UpdateCharacter(selectedOption);
        Save();
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.character[selectedOption];
        artworkSprite.sprite = character.CharacterSprite;
        nameText.text = character.CharacterName;
    }
    void Start()
    {
        if(!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption=0;
        }
        else
        {
            Load();
        }

        UpdateCharacter(selectedOption);
        GameManager.Instance.UpdateGameState(GameManager.Gamestate.PlayerTurn);
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }
}

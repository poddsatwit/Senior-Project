using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;
using UnityEngine.TextCore.Text;

public class CharacterSelection : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public static CharacterSelection instance;
    public Text nameText;
    public SpriteRenderer artworkSprite;

    private int selectedOption;
    [SerializeField] private Button returnButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button prevButton;
    [SerializeField] private Button playButton;

    private void Start()
    {
       // CreateCharacters();
       // characterDB = new CharacterDatabase();
       // characterDB.Initialize();
        returnButton.onClick.AddListener(OnReturnButtonClicked);
        nextButton.onClick.AddListener(OnNextButtonClicked) ;
        prevButton.onClick.AddListener(OnPrevButtonClicked);
        playButton.onClick.AddListener(OnPlayButtonClicked);

      /*  if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
      */
      selectedOption = 0;
      UpdateCharacter(selectedOption);
    }
    
    private void OnReturnButtonClicked()
    {
        GameManager.Instance.UpdateGameState(GameManager.Gamestate.MenuScene);
    }
    private void OnNextButtonClicked()
    {
        nextCharacter();
    }
    private void OnPrevButtonClicked()
    {
        previousCharacter();
    }
    private void OnPlayButtonClicked()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
        GameManager.Instance.setCharacter(characterDB.GetCharacter(selectedOption));
        GameManager.Instance.UpdateGameState(GameManager.Gamestate.PlayerTurn);
    }
    void Awake()
    {
        instance = this;
    }

    private void nextCharacter()
    {
        selectedOption++;

        if (selectedOption >= characterDB.characterCount())
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
            selectedOption = characterDB.characterCount();
        }
        UpdateCharacter(selectedOption);
        Save();
    }

    private void UpdateCharacter(int selectedOption)
    {
        Debug.Log("Here is selectedOption" + selectedOption);
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.sprite;
        nameText.text = character.Charactername;
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

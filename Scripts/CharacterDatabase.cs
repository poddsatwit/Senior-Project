using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterDatabase : MonoBehaviour
{
    public List<Character> characters;

    public CharacterDatabase()
    {
        characters = new List<Character>();
    }

 /*   public void Initialize()
    {
        // Example initialization with 4 characters
        characters.Add(new Character("John", Resources.Load<Sprite>("Visuals/Cowboy.psb")));
        characters.Add(new Character("Sandy", Resources.Load<Sprite>("Visuals/cowgirl.psb")));
        characters.Add(new Character("Clint East-Bot", Resources.Load<Sprite>("Visuals/robot.psb")));
        characters.Add(new Character("Brother", Resources.Load<Sprite>("Visuals/bartender.psb")));
    } */
    public int characterCount()
    {
    return characters.Count;
    }
    public Character GetCharacter(int index)
    {
        return characters[index];
    }
}
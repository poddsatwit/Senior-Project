using UnityEngine;

[System.Serializable]
public class Character : MonoBehaviour
{
    public string Charactername;
    public Sprite sprite;

    public Character(string name, Sprite sprite)
    {
        this.Charactername = name;
        this.sprite = sprite;
    }
}
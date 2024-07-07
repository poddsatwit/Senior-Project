using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadCharacter : MonoBehaviour
{
    public GameObject characterPrefabs;
    public Transform spawnPoint;
    public TMP_Text label;
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("Select Character");
      //  GameObject prefab = characterPrefabs[selectedCharacter];
      //  label.text = prefab.name;
    }
}

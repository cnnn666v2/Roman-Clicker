using TMPro;
using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    // Reference input field
    [SerializeField]
    TMP_InputField inputName;

    void Start()
    {
        // Load current player's name into the input field
        inputName.text = SaveLoad.inventory.PlayerName;   
    }

    public void ChangeUsername(string newName)
    {
        // Define string to be current inputted text
        newName = inputName.text;

        // Set the player name to this string in inventory
        SaveLoad.inventory.PlayerName = newName;

        // Debug it out
        Debug.Log("New name:" + SaveLoad.inventory.PlayerName);
    }
}

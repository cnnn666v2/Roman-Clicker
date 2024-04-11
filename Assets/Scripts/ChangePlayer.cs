using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangePlayer : MonoBehaviour
{
    // Reference input field
    [SerializeField]
    TMP_InputField inputName;

    [SerializeField]
    Image slot1, slot2, slot3;

    void Start()
    {
        // Load current player's name into the input field
        inputName.text = SaveLoad.playercharacter.Name;

        // Load selected item sprites
        slot1.sprite = SaveLoad.playercharacter.slot1.ItemIcon;
        slot2.sprite = SaveLoad.playercharacter.slot2.ItemIcon;
        slot3.sprite = SaveLoad.playercharacter.slot3.ItemIcon;
    }

    public void ChangeUsername(string newName)
    {
        // Define string to be current inputted text
        newName = inputName.text;

        // Set the player name to this string in inventory
        SaveLoad.playercharacter.Name = newName;

        // Debug it out
        Debug.Log("New name:" + SaveLoad.playercharacter.Name);
    }
}

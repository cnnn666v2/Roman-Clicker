using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangePlayer : MonoBehaviour
{
<<<<<<< Updated upstream
=======
    // Reference playerstats script
    [SerializeField] PlayerStats PS;

>>>>>>> Stashed changes
    // Reference input field
    [SerializeField]
    TMP_InputField inputName;

<<<<<<< Updated upstream
    [SerializeField]
    Image slot1, slot2, slot3;

=======
    // Selected items icons
    [SerializeField]
    Image slot1, slot2, slot3;

    // Player stats
>>>>>>> Stashed changes
    [SerializeField]
    TMP_Text MaxHP, AtkDMG, CritMult, CritChance,
        Healing, 
        PlayerXP, PlayerLVL;

    void Start()
    {
        // Load current player's name into the input field
        inputName.text = SaveLoad.playercharacter.Name;

        // Load selected item sprites
        //slot1.sprite = SaveLoad.playercharacter.slot1.ItemIcon;
        //slot2.sprite = SaveLoad.playercharacter.slot2.ItemIcon;
        //slot3.sprite = SaveLoad.playercharacter.slot3.ItemIcon;

        // Load player stats
        LoadStats();
    }

    public void ChangeUsername(string newName)
    {
        // Define string to be current inputted text
        newName = inputName.text;

        // Set the player name to this string in inventory
<<<<<<< Updated upstream
=======
        PS.PlayerName = newName;
>>>>>>> Stashed changes
        SaveLoad.playercharacter.Name = newName;

        // Debug it out
        Debug.Log("New name:" + SaveLoad.playercharacter.Name);
    }

    public void LoadStats()
    {
        // Setup texts
        MaxHP.text = "Health: " + SaveLoad.playercharacter.MaxHealth;
        AtkDMG.text = "Attack: " + SaveLoad.playercharacter.Damage;
        CritMult.text = "Critical damage: x" + SaveLoad.playercharacter.Critical;
        CritChance.text = "Critical chance: " + SaveLoad.playercharacter.Luck + "%";
        Healing.text = "Healing: +" + SaveLoad.playercharacter.Healing + "HP";
        PlayerXP.text = "Player XP: " + SaveLoad.playercharacter.XP + "XP";
        PlayerLVL.text = "Player Level: " + SaveLoad.playercharacter.Level;
    }
}

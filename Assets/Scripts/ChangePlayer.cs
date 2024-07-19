using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangePlayer : MonoBehaviour
{
    // Reference scripts
    [SerializeField] PlayerStats PS;
    [SerializeField] SaveLoad SL;
    [SerializeField] ItemsDBScript ItemsDBS;

    // Reference input field
    [SerializeField]
    TMP_InputField inputName;

    // Selected items icons
    [SerializeField]
    Image slot1, slot2, slot3;

    // Player stats - Legacy
    /*[SerializeField]
    TMP_Text MaxHP, AtkDMG, CritMult, CritChance,
        Healing, 
        PlayerXP, PlayerLVL;*/

    void Start()
    {
        // Load player stats
        LoadCharacterInfo();
        //LoadStats();
    }

    public void ChangeUsername(string newName)
    {
        // Define string to be current inputted text
        newName = inputName.text;

        // Set the player name to this string in inventory
        PS.PlayerName = newName;
        SaveLoad.playercharacter.Name = newName;
        SL.SaveToJson();

        // Debug it out
        Debug.Log("New name:" + SaveLoad.playercharacter.Name);
    }

    public void LoadCharacterInfo()
    {
        Debug.Log("[CP]: Loading character info");
        // Load the item sprite by iterating through the DB
        for (int i = 0; i < SaveLoad.inventory.OwnedItems.Count; i++) {

            Debug.Log("[CP]: Stage 1");
            for (int j = 0; j < ItemsDBS.ItemsDB.Count; j++) {
                // Load (Slot 1/Weapon) sprite
                if ((ItemsDBS.ItemsDB[j].itemID == SaveLoad.playercharacter.slot1) && (ItemsDBS.ItemsDB[j].Item.ItemType == "Weapon" || ItemsDBS.ItemsDB[j].Item.ItemType == "Null")) {
                    Debug.Log("[ICP] Item ID inside SL is: " + ItemsDBS.ItemsDB[j].itemID);
                    Debug.Log("[ICP] Item ID inside SaveLoad is: " + SaveLoad.inventory.OwnedItems[i]);

                    slot1.sprite = ItemsDBS.ItemsDB[j].Item.ItemIcon;

                    // Stop searching further
                    break;
                } else { Debug.Log("[ICP] Does not exist SL inside SaveLoad or vice versa || " + ItemsDBS.ItemsDB[j].itemID + " || " + SaveLoad.inventory.OwnedItems[i]); }
            }

            Debug.Log("[CP]: Stage 2");
            for (int j = 0; j < ItemsDBS.ItemsDB.Count; j++) {
                // Load (Slot 2/Armor) sprite
                if ((ItemsDBS.ItemsDB[j].itemID == SaveLoad.playercharacter.slot2) && (ItemsDBS.ItemsDB[j].Item.ItemType == "Armor" || ItemsDBS.ItemsDB[j].Item.ItemType == "Null")) {
                    Debug.Log("[ICP] Item ID inside SL is: " + ItemsDBS.ItemsDB[j].itemID);
                    Debug.Log("[ICP] Item ID inside SaveLoad is: " + SaveLoad.inventory.OwnedItems[i]);

                    slot2.sprite = ItemsDBS.ItemsDB[j].Item.ItemIcon;

                    // Stop searching further
                    break;
                } else { Debug.Log("[ICP] Does not exist SL inside SaveLoad or vice versa || " + ItemsDBS.ItemsDB[j].itemID + " || " + SaveLoad.inventory.OwnedItems[i]); }
            }

            Debug.Log("[CP]: Stage 3");
            for (int j = 0; j < ItemsDBS.ItemsDB.Count; j++) {
                // Load (Slot 3/Shield) sprite
                if ((ItemsDBS.ItemsDB[j].itemID == SaveLoad.playercharacter.slot3) && (ItemsDBS.ItemsDB[j].Item.ItemType == "Shield" || ItemsDBS.ItemsDB[j].Item.ItemType == "Null")) {
                    Debug.Log("[ICP] Item ID inside SL is: " + ItemsDBS.ItemsDB[j].itemID);
                    Debug.Log("[ICP] Item ID inside SaveLoad is: " + SaveLoad.inventory.OwnedItems[i]);

                    slot3.sprite = ItemsDBS.ItemsDB[j].Item.ItemIcon;

                    // Stop searching further
                    break;
                } else { Debug.Log("[ICP] Does not exist SL inside SaveLoad or vice versa || " + ItemsDBS.ItemsDB[j].itemID + " || " + SaveLoad.inventory.OwnedItems[i]); }
            }
        }

        Debug.Log("[CP]: Finished loading");
        Debug.Log("[CP]: Loading name");
        // Load current player's name into the input field
        inputName.text = SaveLoad.playercharacter.Name;
        Debug.Log("[CP]: Loaded name!");
    }

    /*public void LoadStats()
    {
        // Setup texts
        MaxHP.text = "Health: " + SaveLoad.playercharacter.MaxHealth;
        AtkDMG.text = "Attack: " + SaveLoad.playercharacter.Damage;
        CritMult.text = "Critical damage: x" + SaveLoad.playercharacter.Critical;
        CritChance.text = "Critical chance: " + SaveLoad.playercharacter.Luck + "%";
        Healing.text = "Healing: +" + SaveLoad.playercharacter.Healing + "HP";
        PlayerXP.text = "Player XP: " + SaveLoad.playercharacter.XP + "XP";
        PlayerLVL.text = "Player Level: " + SaveLoad.playercharacter.Level;
    }*/
}

using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemInfoDisplay : MonoBehaviour
{
    // Reference item to display
    public ItemSO item;

    // Item information
    [Header("ItemSlot info")]
    public TMP_Text NameTXT;
    public Image IconIMG;
    public TMP_Text MoneyCost;
    public TMP_Text GemCost;

    // Information window item info
    //PI stands for "Popup Item" in this context
    //It's worth mentioning the following are all Text/Img fields for the popup
    [Header("Popup item info - main")]
    public TMP_Text PIName;
    public TMP_Text PIDescription;
    public Image PIIcon;

    [Header("Popup item info - attacks")]
    public TMP_Text PIDamage;
    public TMP_Text PICC; // <-- CC stands for "Critical Chance"
    public TMP_Text PICM; // <-- CM stands for "Critical Multiplier"

    [Header("Popup item info - misc")]
    public TMP_Text PIBC; // <-- BC stands for "Block Chance"

    public TMP_Text PIDOT; // <-- DOT stands for "Damage over time"
    public TMP_Text PIDOTD; // <-- DOT is same as above, last D stands for "Duration"

    public GameObject LockPanel; // <-- It will prohibit user from buying the item again

    // <-- END OF POPUP INFO --> //
    //////////////////////////////

    void Start()
    {
        // Set ItemSlot at the start
        NameTXT.text = item.ItemName;
        IconIMG.sprite = item.ItemIcon;

        // Economy
        MoneyCost.text = item.ItemMoneyCost.ToString() + "$";
        GemCost.text = item.ItemGemCost.ToString() + " Gems";

        // Lock or unlock item based on ownership status
        //if(item.IsOwned == true) { LockPanel.SetActive(true); }
        //else { LockPanel.SetActive(false); }
    }

    public void SetPopupInfo()
    {
        // Main item information
        PIName.text = item.ItemName;
        PIDescription.text = item.ItemDescription;
        PIIcon.sprite = item.ItemIcon;

        // Attack item info
        PIDamage.text = "Damage: " + item.ItemAttack.ToString();
        PICC.text = "Critical chance: " + item.ItemCritChance.ToString();
        PICM.text = "Critical multiplier: " + item.ItemCritMP.ToString();

        // Misc
        PIBC.text = "Block chance: " + item.ItemBlockChance.ToString();
        PIDOT.text = "Damage over time: " + item.ItemDmgOvertime.ToString();
        PIDOTD.text = "Damage over time duration: " + item.ItemDMGOTDuration.ToString();
    }

    public void SetItem()
    {
        // Assign item to a slot based on its type
        //Slot 1 - Weapon
        //Slot 2 - Armor
        //Slot 3 - Defense weapon
        // (All are subject to change)
        switch(item.ItemType)
        {
            case "Weapon":
                SaveLoad.playercharacter.slot1 = item.ItemID;
                Debug.Log("Set item to weapon slot");
                break;

            case "Armor":
                SaveLoad.playercharacter.slot2 = item.ItemID;
                Debug.Log("Set item to armor slot");
                break;
        }
        
        Debug.Log("Gratulacje u¿ytkowniku, zosta³eœ wybrany na darmowego: " + item.ItemName);
    }
}

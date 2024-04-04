using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetInfoOnObject : MonoBehaviour
{
    // Reference to iteminfo script to scrap it
    ItemInfoDisplay itemInfo;

    // Popup item info panel
    GameObject panel;

    // Popup texts (same as in display info item)
    TMP_Text PIName;
    TMP_Text PIDescription;
    Image PIIcon;

    TMP_Text PIDamage;
    TMP_Text PICC;
    TMP_Text PICM;

    TMP_Text PIBC;

    TMP_Text PIDOT;
    TMP_Text PIDOTD;

    private void Start()
    {
        // Reference of itemInfo in SlotItem
        itemInfo = GetComponent<ItemInfoDisplay>();
        // Find fucking popup panel
        panel = GameObject.Find("/Canvas/Panels/InventoryPanel/ItemInfoPopup");
    }

    public void SetInformation()
    {
        // Define two strings to make this shit shorter
        string MainInfo = "/Canvas/Panels/InventoryPanel/ItemInfoPopup/ItemMainInfo/";
        string StatsInfo = "/Canvas/Panels/InventoryPanel/ItemInfoPopup/ItemStatsInfo/Scrollview/StatsListContent/";
        panel.SetActive(true); // Toggle the panel

        // I'm going to hell for what's about to happen, I'm sorry to anyone going through the code - 2nd April, 2024 - 21:13
        PIName = GameObject.Find(MainInfo + "ItemTitleTXT").GetComponent<TMP_Text>();
        PIName.text = itemInfo.item.ItemName;

        PIDescription = GameObject.Find(MainInfo + "ItemDescriptionTXT").GetComponent<TMP_Text>();
        PIDescription.text = itemInfo.item.ItemDescription;

        PIIcon = GameObject.Find(MainInfo + "ItemIconIMG").GetComponent<Image>();
        PIIcon.sprite = itemInfo.item.ItemIcon;

        PIDamage = GameObject.Find(StatsInfo + "StatDamageTXT").GetComponent<TMP_Text>();
        PIDamage.text = "Damage: " + itemInfo.item.ItemAttack.ToString();

        PICC = GameObject.Find(StatsInfo + "StatCritChanceTXT").GetComponent<TMP_Text>();
        PICC.text = "Critical Chance: " + itemInfo.item.ItemCritChance.ToString();

        PICM = GameObject.Find(StatsInfo + "StatCritMultiplierTXT").GetComponent<TMP_Text>();
        PICM.text = "Critical Multiplier: " + itemInfo.item.ItemCritMP.ToString();

        PIBC = GameObject.Find(StatsInfo + "StatBlockChanceTXT").GetComponent<TMP_Text>();
        PIBC.text = "Block Chance: " + itemInfo.item.ItemBlockChance.ToString();

        PIDOT = GameObject.Find(StatsInfo + "StatDamageOTTXT").GetComponent<TMP_Text>();
        PIDOT.text = "Damage over time: " + itemInfo.item.ItemDmgOvertime.ToString();

        PIDOTD = GameObject.Find(StatsInfo + "StatDamageDurationTXT").GetComponent<TMP_Text>();
        PIDOTD.text = "Damage over time duration: " + itemInfo.item.ItemDMGOTDuration.ToString();
    }
}

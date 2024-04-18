using UnityEngine;

[CreateAssetMenu(fileName = "New Item")]
public class ItemSO : ScriptableObject
{
    // Main information stuff
    public string ItemName;
    public string ItemDescription;
    public string ItemType;
    public int ItemID;
    public Sprite ItemIcon;

    // Attack related stuff
    public int ItemAttack;
    public int ItemCritChance; // Critical dmg chance
    public int ItemCritMP; // Critical dmg multiplier

    // Misc stuff
    public int ItemBlockChance; // Block chance
    public int ItemDmgOvertime; // Dmg over time
    public int ItemDMGOTDuration; // Dmg over time duration

    // Economic stuff
    public int ItemMoneyCost;
    public int ItemGemCost;
    public int RequiredLevel;
    public bool IsOwned = false;
}

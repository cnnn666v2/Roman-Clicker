using UnityEngine;

public class ItemBuy : MonoBehaviour
{
    // Get player's money and item to buy
    public GameObject GameManager;
    public ItemSO Item;
    public ItemInfoDisplay itemInfo;

    // Economy script
    PlayerStats Economy;

    private void Start()
    {
        // Reference economy script
        Economy = GameManager.GetComponent<PlayerStats>();
        itemInfo = GetComponent<ItemInfoDisplay>();

        // Check if item is already owned inside a list
        if(SaveLoad.inventory.OwnedItems.Contains(Item.ItemID) == true) {
            // If it exists, lock this thing up
            Debug.Log("[IB]: " + Item.ItemName + " exists inside the list, locking it");
            itemInfo.LockPanel.SetActive(true);
        } else {
            // If it doesnt, FREEEEDOM AMERICAAA FUCK YEAH
            Debug.Log("[IB]: " + Item.ItemName + " does NOT exist inside the list");
            itemInfo.LockPanel.SetActive(false);
        }
    }

    public void BuyItem()
    {
        // Check if player has enough money and gems to buy item
        if(Economy.PlayerMoney >= Item.ItemMoneyCost && Economy.PlayerGem >= Item.ItemGemCost && Item.IsOwned != true) {
            // Subtract player's money and gems
            Economy.PlayerMoney -= Item.ItemMoneyCost;
            Economy.PlayerGem -= Item.ItemGemCost;

            // Lock the item
            itemInfo.LockPanel.SetActive(true);

            // Mark item as owned
            Item.IsOwned = true;

            // Add item to the Owned list
            SaveLoad.inventory.OwnedItems.Add(Item.ItemID);
            Debug.Log("Successfully bought: " + Item.ItemName + " for " + Item.ItemGemCost + " gems and " + Item.ItemMoneyCost + "$");
        } else {
            Debug.Log("You're too poor to buy " + Item.ItemName + " or you already own it");
        }
    }
}

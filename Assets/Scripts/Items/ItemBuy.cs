using UnityEngine;

public class ItemBuy : MonoBehaviour
{
    // Get player's money and item to buy
    public GameObject GameManager;
    public ItemSO Item;

    // Economy script
    PlayerEconomy Economy;

    private void Start()
    {
        // Reference economy script
        Economy = GameManager.GetComponent<PlayerEconomy>();
    }

    public void BuyItem()
    {
        // Check if player has enough money and gems to buy item
        if(Economy.PlayerMoney >= Item.ItemMoneyCost && Economy.PlayerGems >= Item.ItemGemCost && Item.IsOwned != true) {
            // Subtract player's money and gems
            Economy.PlayerMoney -= Item.ItemMoneyCost;
            Economy.PlayerGems -= Item.ItemGemCost;

            // Mark item as owned
            Item.IsOwned = true;
            Debug.Log("Successfully bought: " + Item.ItemName + " for " + Item.ItemGemCost + " gems and " + Item.ItemMoneyCost + "$");
        } else {
            Debug.Log("You're too poor to buy " + Item.ItemName + " or you already own it");
        }
    }
}

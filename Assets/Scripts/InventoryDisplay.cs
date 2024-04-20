// TODO
// REWRITE ENTIRE PLAYER STATS AND ECONOMY TO WORK WITH JSON
//

using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    // Reference to full item list
    [SerializeField]
    ItemsDBScript ItemsDBS;

    // Reference the spawn and prefab of what is supposed to be spawned and where
    public Transform InventoryPanel;
    public GameObject ItemSlotPrefab;

    [SerializeField]
    private ItemSO itemS;

    void Start()
    {
        // BIG NOTE HERE
        // I HAVE NO IDEA *AT ALL* HOW THIS CODE WORKS
        // IT IS BEST IF YOU JUST DONT TOUCH IT UNLESS ITS REALLY NEEDED
        // THIS IS SO FUCKING DUMB

        // Check how many prefabs should it spawn
        for (int i = 0; i < SaveLoad.inventory.OwnedItems.Count; i++) {
            for(int j = 0; j < ItemsDBS.ItemsDB.Count; j++) {
                if (ItemsDBS.ItemsDB[j].itemID == SaveLoad.inventory.OwnedItems[i]) {
                    Debug.Log("[IID] Item ID inside SL is: " + ItemsDBS.ItemsDB[j].itemID);
                    Debug.Log("[IID] Item ID inside SaveLoad is: " + SaveLoad.inventory.OwnedItems[i]);

                    // Spawn item inside inventory
                    ItemSlotPrefab.GetComponent<ItemInfoDisplay>().item = ItemsDBS.ItemsDB[j].Item;
                    Instantiate(ItemSlotPrefab, InventoryPanel);

                    // Stop searching further
                    break;
                } else {
                    Debug.Log("[IID] Does not exist SL inside SvaeLoad or vice versa || " + ItemsDBS.ItemsDB[j].itemID + " || " + SaveLoad.inventory.OwnedItems[i]);
                }
            }
        }
    }

    public void AddItem(ItemSO item)
    {
        SaveLoad.inventory.OwnedItems.Add(item.ItemID);
        Debug.Log("Added: " + item.ItemName);
    }
}

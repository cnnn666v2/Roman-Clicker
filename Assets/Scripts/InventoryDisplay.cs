// TODO
// REWRITE ENTIRE PLAYER STATS AND ECONOMY TO WORK WITH JSON
//

using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    // Get object where Inventory script is located
    //public GameObject GameManager;
    //Inventory inventory;

    // Reference the spawn and prefab of what is supposed to be spawned and where
    public Transform InventoryPanel;
    public GameObject ItemSlotPrefab;

    [SerializeField]
    private ItemSO itemS;

    void Start()
    {
        // Check how many prefabs should it spawn
        for (int i = 0; i < SaveLoad.inventory.OwnedItems.Count; i++)
        {
            // Spawn item based on current element in the list
            ItemSlotPrefab.GetComponent<ItemInfoDisplay>().item = SaveLoad.inventory.OwnedItems[i];
            Instantiate(ItemSlotPrefab, InventoryPanel);
        }
    }

    public void AddItem(ItemSO item)
    {
        SaveLoad.inventory.OwnedItems.Add(item);
        Debug.Log("Added: " + item.ItemName);
    }
}

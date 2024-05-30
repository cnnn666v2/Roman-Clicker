/*using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    // Get object where Inventory script is located
    public GameObject GameManager;
    Inventory inventory;

    // Reference the spawn and prefab of what is supposed to be spawned and where
    public Transform InventoryPanel;
    public GameObject ItemSlotPrefab;

    void Start()
    {
        inventory = GameManager.GetComponent<Inventory>();

        // Check how many prefabs should it spawn
        for (int i = 0; i < inventory.OwnedItems.Count; i++)
        {
            // Spawn item based on current element in the list
            ItemSlotPrefab.GetComponent<ItemInfoDisplay>().item = inventory.OwnedItems[i];
            Instantiate(ItemSlotPrefab, InventoryPanel);
        }
    }
}*/

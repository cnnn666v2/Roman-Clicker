using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Create lsit of owned items
    public List<ItemSO> OwnedItems;

    // Reference the spawn and prefab of what is supposed to be spawned and where
    public Transform InventoryPanel;
    public GameObject ItemSlotPrefab;

    void Start()
    {
        // Check how many prefabs should it spawn
        for(int i = 0; i < OwnedItems.Count; i++)
        {
            // Spawn item based on current element in the list
            ItemSlotPrefab.GetComponent<ItemInfoDisplay>().item = OwnedItems[i];
            Instantiate(ItemSlotPrefab, InventoryPanel);
        }
    }

}

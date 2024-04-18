// TODO
// REWRITE ENTIRE PLAYER STATS AND ECONOMY TO WORK WITH JSON
//

using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    // Reference to full item list
    [SerializeField]
    SaveLoad SL;


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
        for (int i = 0; i < SaveLoad.inventory.OwnedItems.Count; i++)
        {
            for(int j = 0; j < SL.ItemsDB.Count; j++)
            {
                if (SL.ItemsDB[j].itemID == SaveLoad.inventory.OwnedItems[i])
                {
                    Debug.Log("[IID] Item ID inside SL is: " + SL.ItemsDB[j].itemID);
                    Debug.Log("[IID] Item ID inside SaveLoad is: " + SaveLoad.inventory.OwnedItems[i]);

                    ItemSlotPrefab.GetComponent<ItemInfoDisplay>().item = SL.ItemsDB[j].Item;
                    Instantiate(ItemSlotPrefab, InventoryPanel);
                } else
                {
                    Debug.Log("[IID] Does not exist SL inside SvaeLoad or vice versa || " + SL.ItemsDB[j].itemID + " || " + SaveLoad.inventory.OwnedItems[i]);
                }
            }

            // Spawn item based on current element in the list
            /*ItemSlotPrefab.GetComponent<ItemInfoDisplay>().item = SaveLoad.inventory.OwnedItems[i];
            Instantiate(ItemSlotPrefab, InventoryPanel);*/
        }
    }

    public void AddItem(ItemSO item)
    {
        SaveLoad.inventory.OwnedItems.Add(item.ItemID);
        Debug.Log("Added: " + item.ItemName);
    }
}

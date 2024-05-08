using System.Collections.Generic;
using UnityEngine;

public class ItemsDBScript : MonoBehaviour
{
    public List<ItemsDB> ItemsDB = new List<ItemsDB>(); // Create a list of all items
}

[System.Serializable]
public class ItemsDB
{
    // This will be used as a 2 value, single element list
    public int itemID; // ID of the item
    public ItemSO Item; // ScriptableObject reference for the said item
}

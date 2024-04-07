using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    // Reference to Player's inventory
    public static Inventory inventory = new Inventory();

    void Awake()
    {
        // Define where from read the data
        string filePath = Application.persistentDataPath + "/InventoryData.json";
        string inventoryData = System.IO.File.ReadAllText(filePath);
        Debug.Log(filePath);

        // Load the data
        inventory = JsonUtility.FromJson<Inventory>(inventoryData);
        Debug.Log("Data loaded!");
    }

    public void SaveToJson()
    {
        // Define where file should've been saved and what
        string inventoryData = JsonUtility.ToJson(inventory);
        string filePath = Application.persistentDataPath + "/InventoryData.json"; 

        Debug.Log(filePath);
        // Actually write the file with correct data
        System.IO.File.WriteAllText(filePath, inventoryData);
        Debug.Log("Saving complete!");
    }

    public void LoadFromJson() 
    {
        // Define where from read the data
        string filePath = Application.persistentDataPath + "/InventoryData.json";
        string inventoryData = System.IO.File.ReadAllText(filePath);
        Debug.Log(filePath);

        // Load the data
        inventory = JsonUtility.FromJson<Inventory>(inventoryData);
        Debug.Log("Data loaded!");
    }
}

[System.Serializable]
public class Inventory
{
    // Create list of owned items
    public List<ItemSO> OwnedItems;
    public new string PlayerName;
    public Inventory()
    {
        OwnedItems = new List<ItemSO>();
    }
}

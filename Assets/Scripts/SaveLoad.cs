using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    // Reference to Player's inventory
    public static Inventory inventory = new Inventory();
    public static PlayerCharacter playercharacter = new PlayerCharacter();

    // [DEBUG]: slot item reference // Little todo - replace the instanceID storing referenece?
    public ItemSO itemSO;

    void Awake()
    {
        // Define inventory location
        string filePathInv = Application.persistentDataPath + "/InventoryData.json";

        // Define player profile location
        string filePathPlayer = Application.persistentDataPath + "/PlayerData.json";

        // Check if the file already exists
        if (!System.IO.File.Exists(filePathInv) && !System.IO.File.Exists(filePathPlayer))
        {
            Debug.Log("Not every file exists!!");
            Debug.Log("Creating files...");
            SaveToJson();
            Debug.Log("Files created and saved!");
        }

        // Save json file read to a string
        string inventoryData = System.IO.File.ReadAllText(filePathInv);
        Debug.Log(filePathInv);
        string playerData = System.IO.File.ReadAllText(filePathPlayer);
        Debug.Log(filePathPlayer);

        // Approve the existence of the files
        Debug.Log("Files exist");

        // Load the data
        inventory = JsonUtility.FromJson<Inventory>(inventoryData);
        playercharacter = JsonUtility.FromJson<PlayerCharacter>(playerData);
        Debug.Log("Data loaded!");

        // Check if the json data files are up to date or not
        if(inventory.VersionNumber != PlayerPrefs.GetString("version-branch") + " " + PlayerPrefs.GetFloat("version-number"))
        {
            Debug.Log("Version mismatch! Might cause errors");
        }

        Debug.Log("Game version: " + inventory.VersionNumber);
    }

    public void SaveToJson()
    {
        // Update game version json file
        Debug.Log("Old version: " + inventory.VersionNumber);
        PlayerPrefs.SetString("version-branch", "dev");
        PlayerPrefs.SetFloat("version-number", 3.3f);
        inventory.VersionNumber = PlayerPrefs.GetString("version-branch") + " " + PlayerPrefs.GetFloat("version-number");
        Debug.Log("New version: " + inventory.VersionNumber);

        // Define inventory data and its location
        string filePathInv = Application.persistentDataPath + "/InventoryData.json";
        string inventoryData = JsonUtility.ToJson(inventory);
        // Define player data and its location
        string filePathPlayer = Application.persistentDataPath + "/PlayerData.json";
        string playerData = JsonUtility.ToJson(playercharacter);

        Debug.Log(filePathInv);
        // Actually write the file with correct data
        System.IO.File.WriteAllText(filePathInv, inventoryData);

        Debug.Log(filePathPlayer);
        // Actually write the file with correct data
        System.IO.File.WriteAllText(filePathPlayer, playerData);

        Debug.Log("Saving complete!");
    }

    public void LoadFromJson() 
    {
        // Define save file locations
        string filePathInv = Application.persistentDataPath + "/InventoryData.json";
        string filePathPlayer = Application.persistentDataPath + "/PlayerData.json";

        // Read save files
        string inventoryData = System.IO.File.ReadAllText(filePathInv);
        string playerData = System.IO.File.ReadAllText(filePathPlayer);
        Debug.Log(filePathInv + " || " + filePathPlayer);

        // Load the data
        inventory = JsonUtility.FromJson<Inventory>(inventoryData);
        playercharacter = JsonUtility.FromJson<PlayerCharacter>(playerData);
        Debug.Log("Data loaded!");
    }
}

[System.Serializable]
public class Inventory
{
    // Create list of owned items
    public List<ItemSO> OwnedItems;
    public Inventory()
    {
        OwnedItems = new List<ItemSO>();
    }

    public string VersionNumber;
}

[System.Serializable]
public class PlayerCharacter
{
    [Header("Player main stats")]
    public string Name;
    public int MaxHealth;
    // public int CurrHealth; // <-- turn it into a local variable in battlesystem?
    public int Damage;
    public int Healing;

    [Header("Player Level")]
    public int XP;
    public int Level;

    [Header("Player skills")]
    public int Luck; // Chance for critical
    public int Critical; // Critical damage multiplier
    //Special skill: poison
    public int PoisonDmg; // Poison damage
    public int PoisonTime; // Poison duration

    [Header("Economic stuff")]
    public int Money;
    public int Gem;

    [Header("Equipped Items")]
    public ItemSO slot1;
    public ItemSO slot2;
    public ItemSO slot3;
}

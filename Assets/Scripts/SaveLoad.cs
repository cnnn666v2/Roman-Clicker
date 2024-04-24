using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    // Reference to Player's inventory
    public static Inventory inventory = new Inventory();
    public static PlayerCharacter playercharacter = new PlayerCharacter();
    public static PlayerSkills playerskills = new PlayerSkills();

    // Get local stats variables
    public PlayerStats Stats;

    // [DEBUG]: slot item reference
    public ItemSO itemSO;

    void Awake()
    {
        // Define inventory location
        string filePathInv = Application.persistentDataPath + "/InventoryData.json";

        // Define player profile location
        string filePathPlayer = Application.persistentDataPath + "/PlayerData.json";

        // Check if the file already exists
        if (!System.IO.File.Exists(filePathInv) || !System.IO.File.Exists(filePathPlayer))
        {
            Debug.Log("Not every file exists!!");
            Debug.Log("Creating files...");
            SaveToJson();
            Debug.Log("Files created and saved!");
        }

        // Load data
        LoadFromJson();

        // Check if the json data files are up to date or not
        if(inventory.VersionNumber != PlayerPrefs.GetString("version-branch") + " " + PlayerPrefs.GetFloat("version-number"))
        {
            Debug.Log("Version mismatch! Might cause errors");
        }

        Debug.Log("Game version: " + inventory.VersionNumber);
    }
    void Start()
    {
        // Load Data on start
        LoadFromJson();

        // Auto save data every 5 minutes
        InvokeRepeating("SaveToJson", 10.0f, 300.0f);

        // Load player stats
        Stats.LoadPlayer();
    }
    void OnApplicationQuit()
    {
        // Save data when shutting down game
        SaveToJson();
    }

    public void SaveToJson()
    {
        // Update game version json file
        Debug.Log("Old version: " + inventory.VersionNumber);
        PlayerPrefs.SetString("version-branch", "dev");
        PlayerPrefs.SetFloat("version-number", 4.0f);
        inventory.VersionNumber = PlayerPrefs.GetString("version-branch") + " " + PlayerPrefs.GetFloat("version-number");
        Debug.Log("New version: " + inventory.VersionNumber);

        // Save player data from local variables to json
        //Stats.LoadPlayer();
        Stats.SavePlayer();

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

    public void LoadInventory()
    {
        // Define save file locations
        string filePathInv = Application.persistentDataPath + "/InventoryData.json";

        // Read save files
        string inventoryData = System.IO.File.ReadAllText(filePathInv);

        // Load the data
        inventory = JsonUtility.FromJson<Inventory>(inventoryData);
        Debug.Log("Loaded inventory!");
    }
}

[System.Serializable]
public class Inventory
{
    // Create list of owned items
    public List<int> OwnedItems;
    public Inventory()
    {
        OwnedItems = new List<int>();
    }

    public string VersionNumber;
}

[System.Serializable]
public class PlayerCharacter
{
    [Header("Player main stats")]
    public string Name;
    public int MaxHealth;
    public int Damage;
    public int Healing;

    [Header("Player Level")]
    public int XP;
    public int ReqXP;
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
    public int slot1; // ID to selected item
    public ItemSO slot2;
    public ItemSO slot3;
}

[System.Serializable]
public class PlayerSkills
{
    // Currency
    public int SkillPoints;
}

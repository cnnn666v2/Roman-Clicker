using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    // Reference to Player's inventory
    public static Inventory inventory = new Inventory();
    public static PlayerCharacter playercharacter = new PlayerCharacter();

    // [DEBUG]: slot item reference
    public ItemSO itemSO;

    // Level up popup objects
    TMP_Text MoneyT, GemsT, NewXPT, LvlT, StatsT, NewArenaT, NewItemsT, NewSkillsT, NewQuestsT;
    [SerializeField]
    GameObject PanelL;

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
        InvokeRepeating("SaveToJson", 0.0f, 300.0f);

        // Level up player
        LevelUP();
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

    public void LoadInventory()
    {
        // Define save file locations
        string filePathInv = Application.persistentDataPath + "/InventoryData.json";
        Debug.Log("Checkpoint A");

        // Read save files
        string inventoryData = System.IO.File.ReadAllText(filePathInv);
        Debug.Log("Checkpoint B");

        // Load the data
        inventory = JsonUtility.FromJson<Inventory>(inventoryData);
        Debug.Log("Loaded inventory!");
    }

    void LevelUP()
    {
        // Check if XP is equal or higher to required xp for lvl up
        if (playercharacter.XP >= playercharacter.ReqXP)
        {
            // Remove XP amount
            playercharacter.XP -= playercharacter.ReqXP;
            // Level up
            playercharacter.Level++;

            // Rewards
            //Convert money int to float
            float MoneyTemp;
            MoneyTemp = (float)playercharacter.Money;
            Debug.Log("Old money: " + MoneyTemp);
            //Add money
            MoneyTemp += playercharacter.Level * (playercharacter.ReqXP * 0.1f) + ((playercharacter.Level * 100)/2) * 25/2;
            Debug.Log("New money: " + MoneyTemp);
            //Round up money to int
            MoneyTemp = Mathf.RoundToInt(MoneyTemp);
            Debug.Log("Rounded money: " + MoneyTemp);
            //Convert float to int
            playercharacter.Money = (int)MoneyTemp;
            Debug.Log("Converted money: " + playercharacter.Money);
            //Add Gems
            playercharacter.Gem += playercharacter.Level * 2;

            // Set new Required XP
            playercharacter.ReqXP += (playercharacter.Level + ((playercharacter.ReqXP/2) + (playercharacter.Level * playercharacter.ReqXP/50)));
            Mathf.RoundToInt(playercharacter.ReqXP);
            Debug.Log("New req xp: " + playercharacter.ReqXP + " || " + (playercharacter.Level * playercharacter.ReqXP) / 50);

            // Set up info
            DisplayLevelInfo();
        }
    }

    void DisplayLevelInfo()
    {
        PanelL.SetActive(true);
        Debug.Log("Displayed level up panel");
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
    public ItemSO slot1;
    public ItemSO slot2;
    public ItemSO slot3;
}

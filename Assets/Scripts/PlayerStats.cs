using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Reference to ItemsDB
    [SerializeField]
    GameObject ItemManager;
    ItemsDBScript ItemsDBS;

    [Header("Player main stats")]
    public string PlayerName;
    public int PlayerMaxHealth;
    public int PlayerCurrHealth;
    public int PlayerHealing;

    [Header("Player damage")]
    public int PlayerDamage; // Total damage
    public int PlayerSATK; // S - means Skill, in this case it's skill attack
    public int PlayerIATK; // I - means Item, in this case it's item attack

    [Header("Player Level")]
    public int PlayerXP;
    public int PlayerReqXP;
    public int PlayerLevel;

    [Header("Player skills")]
    public int PlayerLuck; // Chance for critical
    public int PlayerCritical; // Critical damage multiplier
    //Special skill: poison
    public int PlayerPoisonDmg; // Poison damage
    public int PlayerPoisonTime; // Poison duration

    [Header("Economic stuff")]
    public int PlayerMoney;
    public int PlayerGem;

    private void Awake()
    {
        // Find ItemsManager and get the items db
        ItemManager = GameObject.Find("ItemsDBManager");
        ItemsDBS = ItemManager.GetComponent<ItemsDBScript>();
        
        DontDestroyOnLoad(ItemManager);
        DontDestroyOnLoad(ItemsDBS);
    }

    void Start()
    {
        // Load items
        LoadItems();
    }

    public void LoadPlayer()
    {
        Debug.Log("Loading...");

        // Load all selected items
        LoadItems();

        // Define local variables from the saved data file
        PlayerName = SaveLoad.playercharacter.Name;
        PlayerMaxHealth = SaveLoad.playercharacter.MaxHealth;
        PlayerCurrHealth = SaveLoad.playercharacter.MaxHealth;
        
        PlayerHealing = SaveLoad.playercharacter.Healing;

        PlayerSATK = SaveLoad.playercharacter.Damage;
        //PlayerIATK = SaveLoad.playercharacter.slot1.ItemAttack;
        PlayerDamage = PlayerSATK + PlayerIATK;

        PlayerXP = SaveLoad.playercharacter.XP;
        PlayerReqXP = SaveLoad.playercharacter.ReqXP;
        PlayerLevel = SaveLoad.playercharacter.Level;

        PlayerLuck = SaveLoad.playercharacter.Luck;
        PlayerCritical = SaveLoad.playercharacter.Critical;

        PlayerPoisonDmg = SaveLoad.playercharacter.PoisonDmg;
        PlayerPoisonTime = SaveLoad.playercharacter.PoisonTime;

        PlayerMoney = SaveLoad.playercharacter.Money;
        PlayerGem = SaveLoad.playercharacter.Gem;

        Debug.Log("Loaded!");
    }

    public void SavePlayer()
    {
        Debug.Log("Saving...");

        SaveLoad.playercharacter.Name = PlayerName;
        SaveLoad.playercharacter.MaxHealth = PlayerMaxHealth;

        SaveLoad.playercharacter.Healing = PlayerHealing;
        SaveLoad.playercharacter.Damage = PlayerSATK;

        SaveLoad.playercharacter.XP = PlayerXP;
        SaveLoad.playercharacter.ReqXP = PlayerReqXP;
        SaveLoad.playercharacter.Level = PlayerLevel;

        SaveLoad.playercharacter.Luck = PlayerLuck;
        SaveLoad.playercharacter.Critical = PlayerCritical;

        SaveLoad.playercharacter.PoisonDmg = PlayerPoisonDmg;
        SaveLoad.playercharacter.PoisonTime = PlayerPoisonTime;

        Debug.Log(PlayerMoney);
        SaveLoad.playercharacter.Money = PlayerMoney;
        SaveLoad.playercharacter.Gem = PlayerGem;

        Debug.Log(SaveLoad.playercharacter.Money);
        Debug.Log("Saved!");
    }

    public void LoadItems()
    {
        // Search for item ID
        for(int i = 0;i < ItemsDBS.ItemsDB.Count; i++) {
            // If the selected ID matches with in the DB
            if (ItemsDBS.ItemsDB[i].itemID == SaveLoad.playercharacter.slot1) {
                // Set Item attack value to the selected item
                PlayerIATK = ItemsDBS.ItemsDB[i].Item.ItemAttack;
                break;
            }
        }
    }
}

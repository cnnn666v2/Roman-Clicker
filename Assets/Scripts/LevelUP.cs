using UnityEngine;
using TMPro;

public class LevelUP : MonoBehaviour
{
    // Level up panel
    [SerializeField] GameObject Panel;
    //Panel texts
    [SerializeField] TMP_Text MoneyT, GemsT, NewXPT, LvlT, SkillPointsT,
        NewArenaT, NewItemsT, NewSkillsT, NewQuestsT,
        HealthT, DamageT, CritChanceT, BlockChanceT, BlockDamageT;

    // Get necessary scripts
    PlayerStats Player;
    SaveLoad SaveSystem;
    PlayerMainMenuInfo PMMI;
    ColorStrings CS;

    // Temporar Script Vars
    float MoneyAdd, NewXP, NewXP2;
    int GemAdd, OldXP;
    bool isLvl5, isLvl7, isLvl12;

    void Start()
    {
        // Get localized player stats
        Player = GetComponent<PlayerStats>();
        //Load json into local vars
        Player.LoadPlayer();

        // Get save system script
        SaveSystem = GetComponent<SaveLoad>();

        // Get player main menu info script
        PMMI = GetComponent<PlayerMainMenuInfo>();

        // Get color strings script
        CS = GetComponent<ColorStrings>();

        // Reset Variables
        ResetVars();

        // Level up player
        LevelUp();
    }

    void ResetVars()
    {
        GemAdd = 0;
        MoneyAdd = 0;
        OldXP = 0;
        NewXP = 0;
        NewXP2 = 0;
        isLvl5 = false;
        isLvl7 = false;
        isLvl12 = false;
    }

    // REWRITE ENTRIE THING TO LOCAL VARS NSTEAD OF DIRECT JSON READ-WRITE
    public void LevelUp()
    {
        // Disable texts
        CritChanceT.gameObject.SetActive(false);
        BlockChanceT.gameObject.SetActive(false);
        BlockDamageT.gameObject.SetActive(false);

        // Reset Variables
        ResetVars();

        // Check if XP is equal or higher to required xp for lvl up
        if (Player.PlayerXP >= Player.PlayerReqXP)
        {
            Debug.Log("Available level up");

            // Remove XP amount
            Player.PlayerXP -= Player.PlayerReqXP;
            // Level up
            Player.PlayerLevel++;

            // Rewards
            UpdateMoney();
            UpdateGems();
            UpdateXP();
            UpdateStats();

            // Add Skill Points
            Player.PlayerSkillPoints += Player.PlayerLevel;

            // Save to json
            SaveSystem.SaveToJson();

            // Set up info
            DisplayLevelInfo();
            PMMI.UpdateUI();

        } else { Debug.Log("No available level up"); }
    }

    void UpdateMoney()
    {
        //Convert money int to float
        float MoneyTemp;
        MoneyTemp = (float)Player.PlayerMoney;
        Debug.Log("Old money: " + MoneyTemp);

        // Add money
        MoneyAdd = Player.PlayerLevel * (Player.PlayerReqXP * 0.1f) + ((Player.PlayerLevel * 100) / 2) * 25 / 2;
        MoneyTemp += MoneyAdd;
        Debug.Log("New money: " + MoneyTemp);

        // Round up money to int
        MoneyTemp = Mathf.RoundToInt(MoneyTemp);
        MoneyAdd = Mathf.RoundToInt(MoneyAdd);
        Debug.Log("Rounded money: " + MoneyTemp);

        // Convert float to int
        Player.PlayerMoney = (int)MoneyTemp;
        Debug.Log("Converted money: " + Player.PlayerMoney);
    }

    void UpdateXP()
    {
        // Write old and new XP
        OldXP = Player.PlayerReqXP;
        NewXP = Player.PlayerLevel + ((Player.PlayerReqXP / 2) + (Player.PlayerLevel * Player.PlayerReqXP / 50));

        // Round up XP to set it
        Mathf.RoundToInt(NewXP);
        NewXP2 = Player.PlayerReqXP + (int)NewXP;
        Player.PlayerReqXP += (int)NewXP;

        // Mathf.RoundToInt(Player.PlayerReqXP);
        Debug.Log("New req xp: " + Player.PlayerReqXP + " || " + (Player.PlayerLevel * Player.PlayerReqXP) / 50);
    }

    void UpdateGems()
    {
        GemAdd = Player.PlayerLevel * 2;
        Player.PlayerGem += GemAdd;
    }

    void UpdateStats()
    {
        Player.PlayerMaxHealth++;
        Player.PlayerSATK++;

        // Every 5 levels increase crit chance by 0.05%
        if ((Player.PlayerLevel % 5) == 0) { Player.PlayerLuck += 0.05f; isLvl5 = true; }

        // Every 7 levels increase block chance by 0.05%
        if ((Player.PlayerLevel % 7) == 0) { Player.PlayerBlockChance += 0.05f; isLvl7 = true;  }

        // Every 12 levels increase blocked damage by 0.05%
        if ((Player.PlayerLevel % 12) == 0) { Player.PlayerBlockedDamageP += 0.05f; isLvl12 = true;  }

        EnableTexts();
    }

    void EnableTexts()
    {
        switch (isLvl5, isLvl7, isLvl12)
        {
            case (true, false, false):
                CritChanceT.gameObject.SetActive(true);
                break;

            case (false, true, false):
                BlockChanceT.gameObject.SetActive(true);
                break;

            case (false, false, true):
                BlockDamageT.gameObject.SetActive(true);
                break;
        }
    }

    void DisplayLevelInfo()
    {
        Panel.SetActive(true);
        Debug.Log("Displayed level up panel");

        MoneyT.text = CS.GD + "Money<color=white>: " + CS.G + "+" + MoneyAdd + "$";
        GemsT.text = CS.C + "Gems<color=white>: " + CS.G + "+" + GemAdd;
        SkillPointsT.text = CS.PK + "Skill Points<color=white>: " + CS.G + "+" + Player.PlayerLevel;
        NewXPT.text = CS.C + "Req. " + CS.W + "XP: " + CS.GD + OldXP + CS.W + " -> " + CS.G + NewXP2;
        LvlT.text = CS.S + "Level<color=white>: " + CS.GY + (Player.PlayerLevel-1) + CS.W + " -> " + CS.GY + Player.PlayerLevel;

        HealthT.text = "Hea" + CS.R + "lth<color=white>: " + CS.G + "+1" + CS.W + "H" + CS.R + "P";
        DamageT.text = CS.GY + "Damage<color=white>: " + CS.G + "+1";
        CritChanceT.text = CS.R + "Critical " + CS.Y + "Chance<color=white>: " + CS.G + "+0.05%";
        BlockChanceT.text = CS.C + "Block " + CS.Y + "Chance<color=white>: " + CS.G + "+0.05%";
        BlockDamageT.text = CS.C + "Blocked " + CS.GY + "Damage<color=white>: " + CS.G + "+0.05%";
    }
}

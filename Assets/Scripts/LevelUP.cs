using UnityEngine;
using TMPro;

public class LevelUP : MonoBehaviour
{
    // Level up panel
    [SerializeField] GameObject Panel;
    //Panel texts
    [SerializeField] TMP_Text MoneyT, GemsT, NewXPT, LvlT, StatsT, NewArenaT, NewItemsT, NewSkillsT, NewQuestsT;

    // Get player stats script
    PlayerStats Player;

    // Get Save system script
    SaveLoad SaveSystem;

    void Start()
    {
        // Get localized player stats
        Player = GetComponent<PlayerStats>();
        //Load json into local vars
        Player.LoadPlayer();

        // Get save system script
        SaveSystem = GetComponent<SaveLoad>();

        // Level up player
        LevelUp();
    }

    // REWRITE ENTRIE THING TO LOCAL VARS NSTEAD OF DIRECT JSON READ-WRITE
    void LevelUp()
    {
        // Check if XP is equal or higher to required xp for lvl up
        if (Player.PlayerXP >= Player.PlayerReqXP)
        {
            // Remove XP amount
            Player.PlayerXP -= Player.PlayerReqXP;
            // Level up
            Player.PlayerLevel++;

            // Rewards
            //Convert money int to float
            float MoneyTemp;
            MoneyTemp = (float)Player.PlayerMoney;
            Debug.Log("Old money: " + MoneyTemp);
            //Add money
            MoneyTemp += Player.PlayerLevel * (Player.PlayerReqXP * 0.1f) + ((Player.PlayerLevel * 100) / 2) * 25 / 2;
            Debug.Log("New money: " + MoneyTemp);
            //Round up money to int
            MoneyTemp = Mathf.RoundToInt(MoneyTemp);
            Debug.Log("Rounded money: " + MoneyTemp);
            //Convert float to int
            Player.PlayerMoney = (int)MoneyTemp;
            Debug.Log("Converted money: " + Player.PlayerMoney);
            //Add Gems
            Player.PlayerGem += Player.PlayerLevel * 2;

            // Set new Required XP
            Player.PlayerReqXP += (Player.PlayerLevel + ((Player.PlayerReqXP / 2) + (Player.PlayerLevel * Player.PlayerReqXP / 50)));
            Mathf.RoundToInt(Player.PlayerReqXP);
            Debug.Log("New req xp: " + Player.PlayerReqXP + " || " + (Player.PlayerLevel * Player.PlayerReqXP) / 50);

            // Save to json
            SaveSystem.SaveToJson();

            // Set up info
            DisplayLevelInfo();
        }
    }

    void DisplayLevelInfo()
    {
        Panel.SetActive(true);
        Debug.Log("Displayed level up panel");
    }
}

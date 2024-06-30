using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerMainMenuInfo : MonoBehaviour
{
    [SerializeField] Scrollbar scrollbar;
    [SerializeField] TMP_Text XPTXT, LevelTXT, MoneyTXT, GemsTXT, SPGMoneyTXT, SPGGemsTXT, SKPointsTXT; // SPG stands for: SP - Shop, G - GUI ||| SK stands for: Skill Points |||
    [SerializeField] TMP_Text DmgT, CritChanceT, DmgMultT, BlockChanceT, BlockDmgT, MaxHPT, HealingT, DmgPoisonT, PoisonTurnT;
    PlayerStats PS;
    ColorStrings CS;
    

    private void Start()
    {
        PS = GetComponent<PlayerStats>();
        CS = GetComponent<ColorStrings>();

        PS.LoadPlayer();
        UpdateUI();
    }

    public void UpdateUI()
    {
        // Update Level Panel
        scrollbar.value = (float)PS.PlayerXP / PS.PlayerReqXP;
        XPTXT.text = "XP: " + PS.PlayerXP + "/" + PS.PlayerReqXP;
        LevelTXT.text = "Level: " + PS.PlayerLevel;

        // Update Currency Panel
        MoneyTXT.text = "Money: " + PS.PlayerMoney + "$";
        GemsTXT.text = "Gems: " + PS.PlayerGem;
        //Update ShopGUI Currency
        SPGMoneyTXT.text = "Money: " + PS.PlayerMoney + "$";
        SPGGemsTXT.text = "Gems: " + PS.PlayerGem;
        //Update Skill Points Currency
        SKPointsTXT.text = "Available Skill Points: " + PS.PlayerSkillPoints;

        // Update Stats Panel
        DmgT.text = "Base " + CS.GY + "Damage<color=white>: " + CS.G + PS.PlayerDamage;
        CritChanceT.text = CS.R + "Crit " + CS.Y + "Chance<color=white>: " + CS.G + PS.PlayerLuck + "%";
        DmgMultT.text = CS.GY + "Damage " + CS.O + "Multiplier<color=white>: " + CS.G + PS.PlayerCritical + "x";

        BlockChanceT.text = CS.C + "Block " + CS.Y + "Chance<color=white>: " + CS.G + PS.PlayerBlockChance + "%";
        BlockDmgT.text = CS.C + "Block " + CS.GY + "Damage<color=white>: " + PS.PlayerBlockedDamageP + "%";

        MaxHPT.text = CS.Y + "Max " + CS.R + "Health<color=white>: " + CS.G + PS.PlayerMaxHealth + "<color=white>H<color=red>P";
        HealingT.text = CS.R + "Healing: " + CS.G + "+" + PS.PlayerHealing + "<color=white>H<color=red>P";

        DmgPoisonT.text = CS.GD + "Poison " + CS.GY + "Damage<color=white>: " + CS.G + PS.PlayerPoisonDmg;
        PoisonTurnT.text = CS.GD + "Poison " + CS.W + "Duration: " + CS.G + PS.PlayerPoisonTime + CS.O + " Turns";
    }
}

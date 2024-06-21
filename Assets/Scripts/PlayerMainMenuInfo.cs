using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerMainMenuInfo : MonoBehaviour
{
    [SerializeField] Scrollbar scrollbar;
    [SerializeField] TMP_Text XPTXT, LevelTXT, MoneyTXT, GemsTXT, SPGMoneyTXT, SPGGemsTXT, SKPointsTXT; // SPG stands for: SP - Shop, G - GUI ||| SK stands for: Skill Points |||
    [SerializeField] PlayerStats PS;

    private void Start()
    {
        PS = GetComponent<PlayerStats>();
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
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [Header("Statistics Texts")]
    public TMP_Text HealthTXT;
    public TMP_Text AttackDmgTXT;
    public TMP_Text AttackSpeedTXT;
    public TMP_Text DefenseTXT;
    public TMP_Text CriticalChanceTXT;
    public TMP_Text EnergyTXT;
    public TMP_Text PlayerLevelTXT;
    public TMP_Text PlayerXPTXT;

    [Header("Statistics Values")]
    public int Health;
    public int Attack;
    public int AttackSpeed;
    public int Defense;
    public int CriticalChance;
    //soon
    public int Energy;
    public int EnergyMAX;
    public int EnergyRegen;
    //////////////

    [Header("Level Progress")]
    public int PlayerLVL;
    public int PlayerXP;
    public int PlayerXPMax;
    public Slider ProgressbarXP;

    void Awake() {
        Health = PlayerPrefs.GetInt("Health", 5);
        Attack = PlayerPrefs.GetInt("Attack", 1);
        AttackSpeed = PlayerPrefs.GetInt("AttackSpeed", 10);
        Defense = PlayerPrefs.GetInt("Defense", 0);
        CriticalChance = PlayerPrefs.GetInt("CriticalChance", 0);
        //soon
        Energy = PlayerPrefs.GetInt("Energy", 0);
        EnergyMAX = PlayerPrefs.GetInt("EnergyMAX", 0);
        EnergyRegen = PlayerPrefs.GetInt("EnergyRegen", 0);
        /////////////
        PlayerLVL = PlayerPrefs.GetInt("PlayerLVL", 1);
        PlayerXP = PlayerPrefs.GetInt("PlayerXP", 0);
        PlayerXPMax = PlayerPrefs.GetInt("PlayerXPMax", 50);

        HealthTXT.text = "Health: " + Health.ToString();
        AttackDmgTXT.text = "Attack: " + Attack.ToString();
        AttackSpeedTXT.text = "Attack Speed: " + AttackSpeed.ToString() + "s";
        DefenseTXT.text = "Defense: " + Defense.ToString();
        CriticalChanceTXT.text = "Critical Chance: " + CriticalChance.ToString() + "%";
        EnergyTXT.text = "Energy: " + Energy.ToString() + "/" + EnergyMAX.ToString();
        PlayerLevelTXT.text = "Level: " + PlayerLVL.ToString();
        PlayerXPTXT.text = "XP: " + PlayerXP.ToString() + "/" + PlayerXPMax.ToString();
    }

    void Update() {
        ProgressbarXP.value = PlayerXP/(float)PlayerXPMax;
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    Money scriptMoney;
    MainMenu scriptMenu;

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
    public int HealthMAX;
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
    public long PlayerXP;
    public long PlayerXPMax;
    public Slider ProgressbarXP;

    [Header("Other")]
    int S1UPB;
    int S2UPB;
    int S3UPB;
    int S4UPB;
    int POUPB;
    int HMUPB;
    int P1UPB;
    int P2UPB;
    int P3UPB;
    int P4UPB;
    int FTUPB;
    int FCUPB;

    void Awake() {
        scriptMoney = GetComponent<Money>();
        scriptMenu = GameObject.Find("Canvas").GetComponent<MainMenu>();
    }

    void Start() {
        Health = PlayerPrefs.GetInt("Health", 5);
        HealthMAX = PlayerPrefs.GetInt("HealthMAX", 5);
        AttackSpeed = PlayerPrefs.GetInt("AttackSpeed", 10);
        Attack = PlayerPrefs.GetInt("Attack", 1);
        Defense = PlayerPrefs.GetInt("Defense", 0);
        CriticalChance = PlayerPrefs.GetInt("CriticalChance", 0);

        //soon
        Energy = PlayerPrefs.GetInt("Energy", 0);
        EnergyMAX = PlayerPrefs.GetInt("EnergyMAX", 0);
        EnergyRegen = PlayerPrefs.GetInt("EnergyRegen", 0);
        /////////////
        
        PlayerLVL = PlayerPrefs.GetInt("PlayerLVL", 1);

        HealthTXT.text = "Health: " + HealthMAX.ToString();
        AttackDmgTXT.text = "Attack: " + Attack.ToString();
        DefenseTXT.text = "Defense: " + Defense.ToString();
        AttackSpeedTXT.text = "Attack Speed: " + AttackSpeed.ToString() + "s";
        CriticalChanceTXT.text = "Critical Chance: " + CriticalChance.ToString() + "%";
        EnergyTXT.text = "Energy: " + Energy.ToString() + "/" + EnergyMAX.ToString();

        string PlayerXPString = PlayerPrefs.GetString("PlayerXP", "0");
        string PlayerXPMaxString = PlayerPrefs.GetString("PlayerXPMax", "15");

        PlayerXP = long.Parse(PlayerXPString);
        PlayerXPMax = long.Parse(PlayerXPMaxString);

        ProgressbarXP.value = PlayerXP/(float)PlayerXPMax;

        PlayerLevelTXT.text = "Level: " + PlayerLVL.ToString();
        PlayerXPTXT.text = "XP: " + PlayerXP.ToString() + "/" + PlayerXPMax.ToString();

        HealthTXT.text = "Health: " + Health.ToString();
        AttackSpeedTXT.text = "Attack Speed: " + AttackSpeed.ToString() + "s";

        S1UPB = PlayerPrefs.GetInt("S1UPB", 1);
        S2UPB = PlayerPrefs.GetInt("S2UPB", 0);
        S3UPB = PlayerPrefs.GetInt("S3UPB", 0);
        S4UPB = PlayerPrefs.GetInt("S4UPB", 0);
        POUPB = PlayerPrefs.GetInt("POUPB", 0);
        HMUPB = PlayerPrefs.GetInt("HMUPB", 0);
        P1UPB = PlayerPrefs.GetInt("P1UPB", 1);
        P2UPB = PlayerPrefs.GetInt("P2UPB", 0);
        P3UPB = PlayerPrefs.GetInt("P3UPB", 0);
        P4UPB = PlayerPrefs.GetInt("P4UPB", 0);
        FTUPB = PlayerPrefs.GetInt("FTUPB", 0);
        FCUPB = PlayerPrefs.GetInt("FCUPB", 0);

        if(PlayerXP >= PlayerXPMax) {
            scriptMenu.LevelUPPanel.SetActive(true);

            PlayerXP -= PlayerXPMax;
            PlayerXPMax = Mathf.RoundToInt((float)PlayerXPMax * 2.5f);
            PlayerLVL++;

            PlayerPrefs.SetString("PlayerXP", PlayerXP.ToString());
            PlayerPrefs.SetString("PlayerXPMax", PlayerXPMax.ToString());
            PlayerPrefs.SetInt("PlayerLVL", PlayerLVL);

            scriptMoney.egg += 1;
            Health += 1;
            HealthMAX += 1;

            PlayerPrefs.SetInt("Health", Health);
            PlayerPrefs.SetInt("HealthMAX", HealthMAX);
            PlayerPrefs.SetString("egg", scriptMoney.egg.ToString());

            if(PlayerLVL <= 10)
                AttackSpeed -= 1;
                PlayerPrefs.SetInt("AttackSpeed", AttackSpeed);

            if(PlayerLVL % 1 == 0) {
                S1UPB += 5;
                PlayerPrefs.SetInt("S1UPB", S1UPB);
            };
            
            if(PlayerLVL % 4 == 0) {
                S2UPB++;
                PlayerPrefs.SetInt("S2UPB", S2UPB);
            };

            if(PlayerLVL % 8 == 0) {
                S3UPB++;
                PlayerPrefs.SetInt("S3UPB", S3UPB);
            };

            if(PlayerLVL % 10 == 0) {
                S4UPB++;
                PlayerPrefs.SetInt("S4UPB", S4UPB);
            };

            if(PlayerLVL % 12 == 0) {
                HMUPB++;
                PlayerPrefs.SetInt("HMUPB", HMUPB);
            };

            if(PlayerLVL % 14 == 0) {
                POUPB++;
                PlayerPrefs.SetInt("POUPB", POUPB);
            };



            if(PlayerLVL % 1 == 0) {
                P1UPB++;
                PlayerPrefs.SetInt("P1UPB", P1UPB);
            };

            if(PlayerLVL % 2 == 0) {
                P2UPB++;
                PlayerPrefs.SetInt("P2UPB", P2UPB);
            };

            if(PlayerLVL % 5 == 0) {
                P3UPB++;
                PlayerPrefs.SetInt("P3UPB", P3UPB);
            };

            if(PlayerLVL % 7 == 0) {
                P4UPB++;
                PlayerPrefs.SetInt("P4UPB", P4UPB);
            };

            if(PlayerLVL % 9 == 0) {
                FTUPB++;
                PlayerPrefs.SetInt("FTUPB", FTUPB);
            };

            if(PlayerLVL % 12 == 0) {
                FCUPB++;
                PlayerPrefs.SetInt("FCUPB", FCUPB);
            };
        }
    }
}

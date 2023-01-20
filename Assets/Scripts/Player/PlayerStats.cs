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

    void Awake() {
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
        //PlayerXP = PlayerPrefs.GetInt("PlayerXP", 0);
        //PlayerXPMax = PlayerPrefs.GetInt("PlayerXPMax", 50);

        AttackDmgTXT.text = "Attack: " + Attack.ToString();
        DefenseTXT.text = "Defense: " + Defense.ToString();
        CriticalChanceTXT.text = "Critical Chance: " + CriticalChance.ToString() + "%";
        EnergyTXT.text = "Energy: " + Energy.ToString() + "/" + EnergyMAX.ToString();

        scriptMoney = GetComponent<Money>();
        scriptMenu = GameObject.Find("Canvas").GetComponent<MainMenu>();
    }

    void Start() {
        string PlayerXPString = PlayerPrefs.GetString("PlayerXP", "0");
        string PlayerXPMaxString = PlayerPrefs.GetString("PlayerXPMax", "50");

        PlayerXP = long.Parse(PlayerXPString);
        PlayerXPMax = long.Parse(PlayerXPMaxString);
    }

    void Update() {
        ProgressbarXP.value = PlayerXP/(float)PlayerXPMax;

        PlayerLevelTXT.text = "Level: " + PlayerLVL.ToString();
        PlayerXPTXT.text = "XP: " + PlayerXP.ToString() + "/" + PlayerXPMax.ToString();

        HealthTXT.text = "Health: " + Health.ToString();
        AttackSpeedTXT.text = "Attack Speed: " + AttackSpeed.ToString() + "s";

        if(PlayerXP >= PlayerXPMax) {
            scriptMenu.LevelUPPanel.SetActive(true);

            PlayerXP -= PlayerXPMax;
            PlayerXPMax = Mathf.RoundToInt((float)PlayerXPMax * 2.5f);

            PlayerPrefs.SetString("PlayerXP", PlayerXP.ToString());
            PlayerPrefs.SetString("PlayerXPMax", PlayerXPMax.ToString());

            PlayerLVL++;

            scriptMoney.egg += 1;

            Health += 1;
            HealthMAX += 1;

            PlayerPrefs.SetInt("Health", Health);
            PlayerPrefs.SetInt("HealthMAX", HealthMAX);
            PlayerPrefs.SetString("egg", scriptMoney.egg.ToString());
            if(PlayerLVL < 10)
                AttackSpeed -= 1;

            //Make upgrades depend on level
            /*if(PlayerLVL % 5 == 0) {

            }*/
        }
    }
}

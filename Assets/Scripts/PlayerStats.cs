using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player main stats")]
    public string PlayerName;
    public int PlayerMaxHealth;
    public int PlayerCurrHealth;
    public int PlayerDamage;
    public int PlayerHealing;

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

    public void LoadPlayer()
    {
        // Define local variables from the saved data file
        PlayerName = SaveLoad.playercharacter.Name;
        PlayerMaxHealth = SaveLoad.playercharacter.MaxHealth;
        PlayerCurrHealth = SaveLoad.playercharacter.MaxHealth;
        PlayerHealing = SaveLoad.playercharacter.Healing;

        PlayerDamage = SaveLoad.playercharacter.Damage + SaveLoad.playercharacter.slot1.ItemAttack;

        PlayerXP = SaveLoad.playercharacter.XP;
        PlayerReqXP = SaveLoad.playercharacter.ReqXP;
        PlayerLevel = SaveLoad.playercharacter.Level;

        PlayerLuck = SaveLoad.playercharacter.Luck;
        PlayerCritical = SaveLoad.playercharacter.Critical;

        PlayerPoisonDmg = SaveLoad.playercharacter.PoisonDmg;
        PlayerPoisonTime = SaveLoad.playercharacter.PoisonTime;
        ///////////////////
    }
}

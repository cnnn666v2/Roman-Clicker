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
}

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

    /*public bool TakeDamage(int damage)
    {
        Debug.Log("[TakeDamage]: Current health: " + PlayerCurrHealth);
        PlayerCurrHealth -= damage;
        Debug.Log("[TakeDamage]: Taken damage: " + damage + " || New health: " + PlayerCurrHealth);

        // Determine wether the enemy is dead or not
        if(PlayerCurrHealth <= 0 ) {return true;} else {return false;}
    }*/
}

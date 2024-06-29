// TODO
// REPLACE CURRENTTURN STRING WITH BATTLESTATES IN BATTLESYSTEM AND ATTACKMETHODS SCRIPTS
// SOON

using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class AttackMethods : MonoBehaviour
{
    // Reference the necessary scripts
    PlayerStats statsP;
    PlayerStats statsE;
    BattleSystem battleSystem;
    OnClickCalls onClick;

    // Poison status
    bool SetPoison;

    // Prefabs
    //Chat logs
    public Transform MessageContainer;
    public TMP_Text MessagePrefab;
    //int messages; // Count the amount of spawned messages
    public List<TMP_Text> messageObjects = new List<TMP_Text>(); // List of spawned messages

    void Awake()
    {
        // Get components and variables from BattleSystem script
        battleSystem = GetComponent<BattleSystem>();

        // Get OnClickCalls component
        onClick= GetComponent<OnClickCalls>();

        // Poison has not been used yet
        SetPoison = false;
    }
    public void ScrapInfo()
    {
        // Get player stats
        Debug.Log("Object inside ScrapInfo(): " + battleSystem + " || TurnState: " + battleSystem.State + " || onClick: " + onClick);
        statsP = battleSystem.PlayableCharacter;

        // Get enemy stats
        statsE = battleSystem.EnemyCharacter;
    }

    public void TakeDamage(int damage, float critDmg, float critChance)
    {
        ScrapInfo();

        // Define a variable for dealt dmg
        float dealtDmg;
        int randomized = Random.Range(1, 100);

        Debug.Log("[TakeDamage]: Initiated variables");

        // Determine if the hit should've been a crit or no via randomizing
        if (randomized <= critChance) {
            // if odds are in favour, Multiply base dmg by critDmg which is a multiplier
            dealtDmg = damage * critDmg;
        } else {
            // if odds arent in favour, define dealtDmg as base dmg
            dealtDmg = damage;
        }

        Mathf.RoundToInt(dealtDmg);

        Debug.Log("[TakeDamage]: Rolled number is " + randomized);
        Debug.Log("[TakeDamage]: It's " + battleSystem.State + "'s turn");

        // Determine who should've been attacked
        if (battleSystem.State == BattleState.PLAYERTURN) {
            // Deal damage to enemy
            Debug.Log("[TakeDamage]: Current health: " + statsE.PlayerCurrHealth);
            // Try to block damage by enemy
            if(Random.Range(0, 100) <= statsE.PlayerBlockChance) {
                // Spawn new message inside container
                TMP_Text messageTXT = Instantiate(MessagePrefab, MessageContainer);
                messageObjects.Add(messageTXT);
                messageTXT.text = "<color=#FF0000>" + statsE.PlayerName + "<color=#FFF> has blocked the attack";
            } else {
                statsE.PlayerCurrHealth -= (int)dealtDmg;
                Debug.Log("[TakeDamage]: Taken damage: " + dealtDmg + " || New health: " + statsE.PlayerCurrHealth);

                // Spawn new message inside container
                TMP_Text messageTXT = Instantiate(MessagePrefab, MessageContainer);
                messageObjects.Add(messageTXT);
                messageTXT.text = "<color=#00ECFF>" + statsP.PlayerName + "<color=#FFF> damaged <color=#FF0000>" + statsE.PlayerName + "<color=#FFF> for: " + dealtDmg + "hp </color>";
            }

            CheckDeath();
        } else if (battleSystem.State == BattleState.ENEMYTURN) {
            // Deal damage to player
            Debug.Log("[TakeDamage]: Current health: " + statsP.PlayerCurrHealth);
            if(Random.Range(0, 100) <= statsP.PlayerBlockChance) {
                // Spawn new message inside container
                TMP_Text messageTXT = Instantiate(MessagePrefab, MessageContainer);
                messageObjects.Add(messageTXT);
                messageTXT.text = "<color=#00ECFF>" + statsP.PlayerName + "<color=#FFF> has blocked the attack";
            } else {
                statsP.PlayerCurrHealth -= (int)dealtDmg;
                Debug.Log("[TakeDamage]: Taken damage: " + dealtDmg + " || New health: " + statsP.PlayerCurrHealth);

                // Spawn new message inside container
                TMP_Text messageTXT = Instantiate(MessagePrefab, MessageContainer);
                messageObjects.Add(messageTXT);
                messageTXT.text = "<color=#FF0000>" + statsE.PlayerName + "<color=#FFF> damaged <color=#00ECFF>" + statsP.PlayerName + "<color=#FFF> for: " + dealtDmg + "hp </color>";
            }

            CheckDeath();
        } else { Debug.Log("Something is wrong: " + battleSystem.State); }
    }

    public void UseHealing(int healing)
    {
        ScrapInfo();

        // Determine who should've been healed
        if (battleSystem.State == BattleState.PLAYERTURN) {
            // Heal player
            Debug.Log("[UseHealing]: Current health: " + statsP.PlayerCurrHealth);
            statsP.PlayerCurrHealth += healing;

            if (statsP.PlayerCurrHealth >= statsP.PlayerMaxHealth)
                statsP.PlayerCurrHealth = statsP.PlayerMaxHealth;

            Debug.Log("[UseHealing]: Taken health: " + healing + " || New health: " + statsP.PlayerCurrHealth);

            // Spawn new message inside container
            TMP_Text messageTXT = Instantiate(MessagePrefab, MessageContainer);
            messageObjects.Add(messageTXT);
            messageTXT.text = "<color=#00ECFF>" + statsP.PlayerName + "<color=#FFF> healed themselves for: " + healing + "hp </color>";

            CheckDeath();
        } else if (battleSystem.State == BattleState.ENEMYTURN) {
            // Heal enemy
            Debug.Log("[UseHealing]: Current health: " + statsE.PlayerCurrHealth);
            statsE.PlayerCurrHealth += healing;
            Debug.Log("[UseHealing]: Taken health: " + healing + " || New health: " + statsE.PlayerCurrHealth);

            // Spawn new message inside container
            TMP_Text messageTXT = Instantiate(MessagePrefab, MessageContainer);
            messageObjects.Add(messageTXT);
            messageTXT.text = "<color=#FF0000>" + statsE.PlayerName + "<color=#FFF> healed themselves for: " + healing + "hp </color>";

            CheckDeath();
        } else {
            Debug.Log("Something is wrong: " + battleSystem.State);
        }
    }

    public void Poisoning(int poisonDmg, int poisonDuration)
    {
        ScrapInfo();

        // Get current turn count left for poison from battlesystem
        int turnsLeft = battleSystem.durationPoisonLeft;

        Debug.Log("Poison status: " + SetPoison);
        
        // Determine if poison has been already called by player
        if(SetPoison == true) {
            Debug.Log("Poison has been called already");
        } else {
            // Set how long the attack should last
            Debug.Log("Activate poison");

            // Do attack overtime
            Debug.Log("[Poisoning]: isUsed status: " + onClick.isUsed);
            if (onClick.isUsed == true) {
                Debug.Log("Poison has been used, turns left: " + turnsLeft);

                // Check if it should still poison the enemy
                if (turnsLeft > 0) {
                    // Subtract poison time left from battlesystem by 1
                    battleSystem.durationPoisonLeft -= 1;

                    // Determine who should've been poisoned
                    if (battleSystem.State == BattleState.PLAYERTURN) {
                        // Poison enemy
                        Debug.Log("[Poisoning]: Current health: " + statsE.PlayerCurrHealth);
                        statsE.PlayerCurrHealth -= poisonDmg;
                        Debug.Log("[Poisoning]: Taken dmg: " + poisonDmg + " || New health: " + statsE.PlayerCurrHealth + " || Duration left: " + turnsLeft);

                        // Spawn new message inside container
                        TMP_Text messageTXT = Instantiate(MessagePrefab, MessageContainer);
                        messageObjects.Add(messageTXT);
                        messageTXT.text = "<color=#00ECFF>" + statsP.PlayerName + "<color=#FFF> poisoned <color=#FF0000>" + statsE.PlayerName + "<color=#FFF>, damage dealt: " + poisonDmg + "hp </color>";

                        CheckDeath(true);
                    } else if (battleSystem.State == BattleState.ENEMYTURN) {
                        // Poison player
                        Debug.Log("[Poisoning]: Current health: " + statsP.PlayerCurrHealth);
                        statsP.PlayerCurrHealth -= poisonDmg;
                        Debug.Log("[Poisoning]: Taken dmg: " + poisonDmg + " || New health: " + statsP.PlayerCurrHealth + " || Duration left: " + turnsLeft);

                        // Spawn new message inside container
                        TMP_Text messageTXT = Instantiate(MessagePrefab, MessageContainer);
                        messageObjects.Add(messageTXT);
                        messageTXT.text = "<color=#FF0000>" + statsE.PlayerName + "<color=#FFF> poisoned <color=#00ECFF>" + statsP.PlayerName + "<color=#FFF>, damage dealt: " + poisonDmg + "hp </color>";

                        CheckDeath(true);
                    } else { Debug.Log("Something is wrong: " + battleSystem.State); }
                } else { SetPoison = true; Debug.Log("Turns left from posioning: 0"); }
            } else { Debug.Log("Poison has not been used yet."); }
        }
    }

    public void SkipTurn()
    {
        ScrapInfo();

        // Spawn new message inside container
        TMP_Text messageTXT = Instantiate(MessagePrefab, MessageContainer);
        messageObjects.Add(messageTXT);
        messageTXT.text = "<color=#00ECFF>" + statsP.PlayerName + "<color=#FFF> has <color=#00ECFF>skipped <color=#FFF>turn their</color>";

        // Determine next turn
        CheckDeath();
    }

    bool CheckDeath()
    {
        // Update UI
        battleSystem.UpdateUI();

        if (battleSystem.State == BattleState.PLAYERTURN) {
            // Create a bool to determine enemy's health
            bool isDead = statsE.PlayerCurrHealth <= 0;

            // Check if the enemy is dead after attack
            if (isDead) {
                // Spawn new message inside container
                TMP_Text messageTXT = Instantiate(MessagePrefab, MessageContainer);
                messageObjects.Add(messageTXT);
                messageTXT.text = "<color=#00ECFF>" + statsP.PlayerName + "<color=#FFF> has <color=#00FFAA>won <color=#FFF>the battle </color>";

                // Mark battle as "won"
                battleSystem.State = BattleState.WIN;
                battleSystem.EndBattle();
                return true;
            } else {
                // Spawn new message inside container
                TMP_Text messageTXT = Instantiate(MessagePrefab, MessageContainer);
                messageObjects.Add(messageTXT);
                messageTXT.text = "It's <color=#FF0000>" + statsE.PlayerName + "'s <color=#FFF> turn</color>";

                // Let enemy do its own thing
                battleSystem.State = BattleState.ENEMYTURN;
                battleSystem.EnemyTurn();
                return false;
            }

        } else if (battleSystem.State == BattleState.ENEMYTURN) {
            // Create a bool to determine player's health
            bool isDead = statsP.PlayerCurrHealth <= 0;

            // Check if the player is dead after attack
            if (isDead) {
                // Spawn new message inside container
                TMP_Text messageTXT = Instantiate(MessagePrefab, MessageContainer);
                messageObjects.Add(messageTXT);
                messageTXT.text = "<color=#00ECFF>" + statsP.PlayerName + "<color=#FFF> has <color=#FF0000>lost <color=#FFF>the battle</color>";

                // Mark battle as "lost"
                battleSystem.State = BattleState.LOSS;
                battleSystem.EndBattle();
                Debug.Log("Player ded");
                return true;
            } else {
                // Spawn new message inside container
                TMP_Text messageTXT = Instantiate(MessagePrefab, MessageContainer);
                messageObjects.Add(messageTXT);
                messageTXT.text = "It's <color=#00ECFF>" + statsP.PlayerName + "'s <color=#FFF> turn</color>";

                // Set turn to player's
                battleSystem.State = BattleState.PLAYERTURN;
                battleSystem.PlayerTurn();
                Debug.Log("Player not dead");
                return false;
            }
        } return false; // <-- its only for the compiler, but in case something's wrong I'll put 2 debug logs above, if either of these is not displayed in console and something is not working correctly, there's a deep problem i can't imagine solving myself
    }


    public bool CheckDeath(bool isPoisoning)
    {
        // Determine if poison is active
        if(isPoisoning == true) {
            // If it's active, let user do an action
            Debug.Log("[CheckDeath(bool)]: continue action.");
            return false;
        } else {
            // If it's not, call CheckDeath()
            CheckDeath();
            return false;
        }
    }
}

// TODO
// REPLACE CURRENTTURN STRING WITH BATTLESTATES IN BATTLESYSTEM AND ATTACKMETHODS SCRIPTS
// POISON:
//  MAKE TURNSLEFT VAR WORK
//  ALLOW PLAYER DO ADDITIONAL FUNCTION WHILE POISONING IS ACTIVE
// SOON

using UnityEngine;

public class AttackMethods : MonoBehaviour
{
    PlayerStats statsP;
    PlayerStats statsE;

    BattleSystem battleSystem;

    OnClickCalls onClick;

    string TurnState;
    bool SetPoison;

    void Awake()
    {
        // Get components and variables from BattleSystem script
        battleSystem = GetComponent<BattleSystem>();
        TurnState = battleSystem.CurrentTurn;

        // Get OnClickCalls component
        onClick= GetComponent<OnClickCalls>();

        // Poison has not been used yet
        SetPoison = false;
    }

    public void ScrapInfo()
    {
        // Get player stats
        Debug.Log("Object inside ScrapInfo(): " + battleSystem + " || TurnState: " + TurnState + " || onClick: " + onClick);
        statsP = battleSystem.PlayableCharacter;

        // Get enemy stats
        statsE = battleSystem.EnemyCharacter;

        // Get current turn state
        TurnState = battleSystem.CurrentTurn;
    }

    public void TakeDamage(int damage, int critDmg, int critChance)
    {
        ScrapInfo();

        // Define a variable for dealt dmg
        int dealtDmg;
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

        Debug.Log("[TakeDamage]: Rolled number is " + randomized);
        Debug.Log("[TakeDamage]: It's " + TurnState + "'s turn");

        // Determine who should've been attacked
        if (TurnState == "Player") {
            // Deal damage to enemy
            Debug.Log("[TakeDamage]: Current health: " + statsE.PlayerCurrHealth);
            statsE.PlayerCurrHealth -= dealtDmg;
            Debug.Log("[TakeDamage]: Taken damage: " + dealtDmg + " || New health: " + statsE.PlayerCurrHealth);
            CheckDeath();

            //if (statsE.PlayerCurrHealth <= 0) { return true; } else { return false; }
        } else if (TurnState == "Enemy") {
            // Deal damage to player
            Debug.Log("[TakeDamage]: Current health: " + statsP.PlayerCurrHealth);
            statsP.PlayerCurrHealth -= dealtDmg;
            Debug.Log("[TakeDamage]: Taken damage: " + dealtDmg + " || New health: " + statsP.PlayerCurrHealth);
            CheckDeath();

            //if (statsP.PlayerCurrHealth <= 0) { return true; } else { return false; }
        } else
        {
            Debug.Log("Something is wrong: " + TurnState);
        }

        // --- the comments below should be useless, but I'll keep them just in case --- //
        // Determine wether the enemy is dead or not
        //if (statsP.PlayerCurrHealth <= 0) { return true; } else { return false; }
        // ARCHIVE ->>>>>>> if (attackWho.PlayerCurrHealth <= 0) { return true; } else { return false; }
    }

    public void UseHealing(int healing)
    {
        ScrapInfo();

        // Determine who should've been healed
        if (TurnState == "Player") {
            // Heal player
            Debug.Log("[UseHealing]: Current health: " + statsP.PlayerCurrHealth);
            statsP.PlayerCurrHealth += healing;
            Debug.Log("[UseHealing]: Taken health: " + healing + " || New health: " + statsP.PlayerCurrHealth);

            CheckDeath();
        } else if (TurnState == "Enemy") {
            // Heal enemy
            Debug.Log("[UseHealing]: Current health: " + statsE.PlayerCurrHealth);
            statsE.PlayerCurrHealth += healing;
            Debug.Log("[UseHealing]: Taken health: " + healing + " || New health: " + statsE.PlayerCurrHealth);

            CheckDeath();
        } else {
            Debug.Log("Something is wrong: " + TurnState);
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
                    if (TurnState == "Player") {
                        // Poison enemy
                        Debug.Log("[Poisoning]: Current health: " + statsE.PlayerCurrHealth);
                        statsE.PlayerCurrHealth -= poisonDmg;
                        Debug.Log("[Poisoning]: Taken dmg: " + poisonDmg + " || New health: " + statsE.PlayerCurrHealth + " || Duration left: " + turnsLeft);

                        CheckDeath();
                    } else if (TurnState == "Enemy") {
                        // Poison player
                        Debug.Log("[UseHealing]: Current health: " + statsE.PlayerCurrHealth);
                        //statsE.PlayerCurrHealth += healing;
                        //Debug.Log("[UseHealing]: Taken health: " + healing + " || New health: " + statsE.PlayerCurrHealth);

                        CheckDeath();
                    } else { Debug.Log("Something is wrong: " + TurnState); }
                } else { SetPoison = true; Debug.Log("Turns left from posioning: 0"); }
            } else { Debug.Log("Poison has not been used yet."); }
            // Tell that poison is used
            //if (turnsLeft == 0) { SetPoison == true; }
            //else { SetPoison = false; }
        }
    }

    bool CheckDeath()
    {
        if(TurnState == "Player") {
            // Create a bool to determine enemy's health
            bool isDead = statsE.PlayerCurrHealth <= 0;

            // Check if the enemy is dead after attack
            if (isDead) {
                battleSystem.State = BattleState.WIN;
                battleSystem.EndBattle();
                return true;
            } else {
                battleSystem.State = BattleState.ENEMYTURN;
                battleSystem.EnemyTurn();
                return false;
            }

        } else if (TurnState == "Enemy") {
            // Create a bool to determine player's health
            bool isDead = statsP.PlayerCurrHealth <= 0;

            // Check if the player is dead after attack
            if (isDead) {
                battleSystem.State = BattleState.LOSS;
                battleSystem.EndBattle();
                Debug.Log("Player ded");
                return true;
            } else {
                battleSystem.State = BattleState.PLAYERTURN;
                battleSystem.PlayerTurn();
                Debug.Log("Player not dead");
                return false;
            }
        } return false; // <-- its only for the compiler, but in case something's wrong I'll put 2 debug logs above, if either of these is not displayed in console and something is not working correctly, there's a deep problem i can't imagine solving myself
    }
}

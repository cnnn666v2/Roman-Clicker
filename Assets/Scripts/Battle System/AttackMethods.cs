// TODO
// REPLACE CURRENTTURN STRING WITH BATTLESTATES IN BATTLESYSTEM AND ATTACKMETHODS SCRIPTS
// SOON

using UnityEngine;

public class AttackMethods : MonoBehaviour
{
    PlayerStats statsP;
    PlayerStats statsE;

    BattleSystem battleSystem;

    string TurnState;

    private void Start()
    {
        // Get components and variables from BattleSystem script
        battleSystem = GetComponent<BattleSystem>();
        TurnState = battleSystem.CurrentTurn;

        ScrapInfo();
    }

    void ScrapInfo()
    {
        // Get player stats
        statsP = battleSystem.PlayableCharacter;

        // Get enemy stats
        statsE = battleSystem.EnemyCharacter;

        // Get current turn state
        TurnState = battleSystem.CurrentTurn;
    }

    public void TakeDamage(int damage)
    {
        ScrapInfo();

        // Determine who should've been attacked
        if (TurnState == "Player") {
            // Deal damage to enemy
            Debug.Log("[TakeDamage]: Current health: " + statsE.PlayerCurrHealth);
            statsE.PlayerCurrHealth -= damage;
            Debug.Log("[TakeDamage]: Taken damage: " + damage + " || New health: " + statsE.PlayerCurrHealth);
            CheckDeath();

            //if (statsE.PlayerCurrHealth <= 0) { return true; } else { return false; }
        } else if (TurnState == "Enemy") {
            // Deal damage to player
            Debug.Log("[TakeDamage]: Current health: " + statsP.PlayerCurrHealth);
            statsP.PlayerCurrHealth -= damage;
            Debug.Log("[TakeDamage]: Taken damage: " + damage + " || New health: " + statsP.PlayerCurrHealth);
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

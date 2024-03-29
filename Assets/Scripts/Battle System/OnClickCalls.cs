using UnityEngine;

public class OnClickCalls : MonoBehaviour
{
    AttackMethods attackMethods;
    BattleSystem bs;

    // Use this bool to determine if attack has been used already or not
    public bool isUsed = false;

    private void Start()
    {
        // Get reference to battlesystem and attackmethods
        bs = GetComponent<BattleSystem>();
        attackMethods = GetComponent<AttackMethods>();
    }

    public void ClickAttack()
    {
        // Check if it is playerturn
        if (bs.State != BattleState.PLAYERTURN)
            return;

        Debug.Log("State is playerturn :)");

        // Call damage function and update text
        attackMethods.TakeDamage(bs.PlayableCharacter.PlayerDamage, bs.PlayableCharacter.PlayerCritical, bs.PlayableCharacter.PlayerLuck);
        bs.EnemyHealthTXT.text = "Health: " + bs.EnemyCharacter.PlayerCurrHealth + "/" + bs.EnemyCharacter.PlayerMaxHealth;
    }

    public void ClickHeal()
    {
        // Check if it is playerturn
        if (bs.State != BattleState.PLAYERTURN)
            return;

        Debug.Log("State is playerturn :)");

        // Call heal function and update text
        Debug.Log("[ClickHeal]: Current health before heal: " + bs.PlayableCharacter.PlayerCurrHealth + " || Healing value: " + bs.PlayableCharacter.PlayerHealing);
        attackMethods.UseHealing(bs.PlayableCharacter.PlayerHealing);
        bs.PlayerHealthTXT.text = "Health: " + bs.PlayableCharacter.PlayerCurrHealth + "/" + bs.PlayableCharacter.PlayerMaxHealth;
        Debug.Log("[ClickHeal]: Current health: " + bs.PlayableCharacter.PlayerCurrHealth);
    }

    public void ClickPoison()
    {
        // Check if it is playerturn
        if (bs.State != BattleState.PLAYERTURN)
            return;

        Debug.Log("State is playerturn :)");

        // If action is us
        Debug.Log("isUsed status: " + isUsed);
        if (isUsed == true) {
            Debug.Log("Zu¿y³eœ jebanego kondoma ju¿ (isUSed: true)");
        } else {
            // Use up the action
            isUsed = true;
            Debug.Log("isUsed status: " + isUsed);

            // Call poison function and update text
            attackMethods.Poisoning(bs.PlayableCharacter.PlayerPoisonDmg, bs.PlayableCharacter.PlayerPoisonTime);
            bs.EnemyHealthTXT.text = "Health: " + bs.EnemyCharacter.PlayerCurrHealth + "/" + bs.EnemyCharacter.PlayerMaxHealth;
        }
    }
}

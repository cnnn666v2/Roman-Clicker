using UnityEngine;

public class OnClickCalls : MonoBehaviour
{
    AttackMethods attackMethods;
    BattleSystem bs;

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
        attackMethods.TakeDamage(bs.PlayableCharacter.PlayerDamage);
        bs.EnemyHealthTXT.text = "Health: " + bs.EnemyCharacter.PlayerCurrHealth + "/" + bs.EnemyCharacter.PlayerMaxHealth;
    }
}

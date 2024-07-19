using UnityEngine;

public class SpellAttacks : MonoBehaviour
{
    // Reference the necessary scripts
    PlayerStats statsP;
    PlayerStats statsE;
    BattleSystem battleSystem;

    void Start()
    {
        // Get references to the necessary scripts
        battleSystem = GetComponent<BattleSystem>();

        ScrapInfo();
    }

    void ScrapInfo()
    {
        // Get player stats
        statsP = battleSystem.PlayableCharacter;

        // Get enemy stats
        statsE = battleSystem.EnemyCharacter;
    }

    public void FreezeEnemyATK()
    {
        ScrapInfo();

    }
}

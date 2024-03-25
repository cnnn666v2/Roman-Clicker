using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WIN, LOSS }

public class BattleSystem : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;

    public Transform PlayerSpawn;
    public Transform EnemySpawn;
    
    public BattleState State;

    void Start()
    {
        State = BattleState.START;
        SetupBattle();
    }

    void SetupBattle()
    {
        Instantiate(PlayerPrefab, PlayerSpawn);
        Instantiate(EnemyPrefab, EnemySpawn);
    }
}

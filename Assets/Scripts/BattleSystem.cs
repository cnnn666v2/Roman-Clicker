using UnityEngine;
using TMPro;
using System.Resources;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WIN, LOSS }

public class BattleSystem : MonoBehaviour
{
    // Player and Enemy prefabs
    [Header("Prefabs")]
    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;

    // Reference player&enemy stats script
    PlayerStats PlayableCharacter;
    PlayerStats EnemyCharacter;

    // Player and Enemy spawn locations
    [Header("Spawners")]
    public Transform PlayerSpawn;
    public Transform EnemySpawn;

    // Battle HUD
    [Header("Stats Texts")]
    //Player
    public TMP_Text PlayerNameTXT;
    public TMP_Text PlayerHealthTXT;
    //Enemy
    public TMP_Text EnemyNameTXT;
    public TMP_Text EnemyHealthTXT;

    // Battle state
    [Header("BattleState")]
    public BattleState State;

    // Panel for disabling player UI
    [Header("Panels")]
    TogglePanel switchPanel;
    public GameObject DisableHUD;
    public GameObject ContinuePanel;
    public GameObject DefeatPanel;

    // Misc variables
    public TMP_Text GameTrack;
    int BattleCount;
    int TurnCount;
    bool isPlayerSpawned;

    private void Awake()
    {
        // Default the battle and turn count
        BattleCount = 0;
        TurnCount = 0;
        //Set Texts
        GameTrack.text = "Battles: " + BattleCount + " || Turn: " + TurnCount;

        // Set isPlayerSpawned to false to avoid problems
        isPlayerSpawned = false;
    }

    void Start()
    {
        // Get TogglePanel script
        switchPanel = GetComponent<TogglePanel>();

        // Set BattleState to START
        State = BattleState.START;
        SetupBattle();
    }

    public void SetupBattle()
    {
        Debug.Log("Setting up battle");
        // Disable all panels
        ContinuePanel.SetActive(false);
        DefeatPanel.SetActive(false);

        // Update battle count
        BattleCount++;
        //Update text
        GameTrack.text = "Battles: " + BattleCount + " || Turn: " + TurnCount;

        // Check if player is spawned
        if (isPlayerSpawned == true) {
            Debug.Log("[isPlayerSpawned]: True, skipping");
        } else {
            // Scrap info and spawn player
            GameObject player = Instantiate(PlayerPrefab, PlayerSpawn);
            PlayableCharacter = player.GetComponent<PlayerStats>();
        }

        // Spawn enemy and scrap info
        GameObject enemy = Instantiate(EnemyPrefab, EnemySpawn);
        EnemyCharacter = enemy.GetComponent<PlayerStats>();

        // Set info about player&enemy with text
        //Enemy
        EnemyNameTXT.text = EnemyCharacter.PlayerName;
        EnemyHealthTXT.text = "Health: " + EnemyCharacter.PlayerCurrHealth + "/" + EnemyCharacter.PlayerMaxHealth;
        //Player
        PlayerNameTXT.text = PlayableCharacter.PlayerName;
        PlayerHealthTXT.text = "Health: " + PlayableCharacter.PlayerCurrHealth + "/" + PlayableCharacter.PlayerMaxHealth;

        // Set BattleState and call next function
        State = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerAttack()
    {
        // Damage the enemy
        bool isDead = EnemyCharacter.TakeDamage(PlayableCharacter.PlayerDamage);
        EnemyHealthTXT.text = "Health: " + EnemyCharacter.PlayerCurrHealth + "/" + EnemyCharacter.PlayerMaxHealth;

        // Check if the enemy is dead after attack
        if (isDead) {
            State = BattleState.WIN;
            EndBattle();
        } else {
            State = BattleState.ENEMYTURN;
            EnemyTurn();
        }
    }

    void EnemyTurn()
    {
        // Update tracking game
        TurnCount++;
        //Set Texts
        GameTrack.text = "Battles: " + BattleCount + " || Turn: " + TurnCount;

        // Damage the player
        bool isDead = PlayableCharacter.TakeDamage(EnemyCharacter.PlayerDamage);
        PlayerHealthTXT.text = "Health: " + PlayableCharacter.PlayerCurrHealth + "/" + PlayableCharacter.PlayerMaxHealth;

        // Check if the player is dead after attack
        if (isDead) {
            State = BattleState.LOSS;
            EndBattle();
        } else {
            State = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void PlayerTurn()
    {
        switchPanel.ToggleUIPanel(DisableHUD);
        //Debug.Log("Player turn");

        Debug.Log("[PlayerTurn]: Turn count: " + TurnCount);
        // Update tracking game
        TurnCount++;
        Debug.Log("[PlayerTurn]: Turn count: " + TurnCount);
        //Set Texts
        GameTrack.text = "Battles: " + BattleCount + " || Turn: " + TurnCount;

        // Toggle panel so that player cant do action
        switchPanel.ToggleUIPanel(DisableHUD);
    }

    void EndBattle()
    {
        // Check if player won or lost battle
        if (State == BattleState.WIN) {
            // Look for enemy object and destroy it
            GameObject enemy = GameObject.FindWithTag("EnemyChar");
            Destroy(enemy);

            // Acknowledge the spawn of player
            isPlayerSpawned = true;

            // Display the WIN panel
            switchPanel.ToggleUIPanel(ContinuePanel);
            Debug.Log("Player win");
        } else if (State == BattleState.LOSS) {
            switchPanel.ToggleUIPanel(DefeatPanel);
            Debug.Log("Player lose");
        }
    }

    public void OnAttackButton()
    {
        // Check if it is playerturn
        if (State != BattleState.PLAYERTURN)
            return;

        Debug.Log("State is playerturn :)");

        // Continue
        PlayerAttack();
    }

    /*public void OnHealButton()
    {
        // Check if it is playerturn
        if (State != BattleState.PLAYERTURN)
            return;

        Debug.Log("State is playerturn :)");

        // Continue
        PlayerHeal();
    }*/
}

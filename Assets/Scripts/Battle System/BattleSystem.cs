// TODO
// MAKE AI LOGIC FOR THE ENEMY
// SOON

using UnityEngine;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WIN, LOSS }

public class BattleSystem : MonoBehaviour
{
    // Player and Enemy prefabs
    [Header("Prefabs")]
    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;

    // Reference player&enemy stats script
    public PlayerStats PlayableCharacter;
    public PlayerStats EnemyCharacter;

    // Reference script with attack modes
    AttackMethods attackMethods;

    // Player and Enemy spawn locations
    [Header("Spawners")]
    public Transform PlayerSpawn;
    public Transform EnemySpawn;

    // Battle HUD
    [Header("Stats Texts")]
    //Player
    public TMP_Text PlayerNameTXT;
    public TMP_Text PlayerHealthTXT;
    public TMP_Text PlayerDamageTXT;
    public TMP_Text PlayerXPTXT;
    public TMP_Text PlayerLVLTXT;
    //Enemy
    public TMP_Text EnemyNameTXT;
    public TMP_Text EnemyHealthTXT;
    public TMP_Text EnemyDamageTXT;

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
    //Game  tracking
    public TMP_Text GameTrack;
    int BattleCount;
    int TurnCount;
    //Flagging player spawn
    bool isPlayerSpawned;
    //Poison duration
    public int durationPoisonLeft;

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
        Debug.Log("Setting up the battle");
        // Disable all panels
        ContinuePanel.SetActive(false);
        DefeatPanel.SetActive(false);

        // Update battle count
        BattleCount++;
        //Update text
        GameTrack.text = "Battles: " + BattleCount + " || Turn: " + TurnCount;

        // Get AttackMethods
        attackMethods = GetComponent<AttackMethods>();

        // Check if player is spawned
        if (isPlayerSpawned == true) {
            Debug.Log("[isPlayerSpawned]: True, skipping");
        } else {
            // Scrap info and spawn player
            GameObject player = Instantiate(PlayerPrefab, PlayerSpawn);
            PlayableCharacter = GetComponent<PlayerStats>();

            // Load player stats
            PlayableCharacter.LoadPlayer();

            // Decide how long should poison last, based on player statistics
            durationPoisonLeft = PlayableCharacter.PlayerPoisonTime;
        }

        // Spawn enemy and scrap info
        GameObject enemy = Instantiate(EnemyPrefab, EnemySpawn);
        EnemyCharacter = enemy.GetComponent<PlayerStats>();

        // Call ScrapInfo() function
        attackMethods.ScrapInfo();

        // Set info about player&enemy with text
        //Enemy
        EnemyNameTXT.text = EnemyCharacter.PlayerName;
        EnemyHealthTXT.text = "Health: " + EnemyCharacter.PlayerCurrHealth + "/" + EnemyCharacter.PlayerMaxHealth;
        EnemyDamageTXT.text = "Damage: " + EnemyCharacter.PlayerDamage;
        //Player
        PlayerNameTXT.text = PlayableCharacter.PlayerName;
        PlayerHealthTXT.text = "Health: " + PlayableCharacter.PlayerCurrHealth + "/" + PlayableCharacter.PlayerMaxHealth;
        PlayerDamageTXT.text = "Damage: " + PlayableCharacter.PlayerDamage;
        PlayerXPTXT.text = "XP: " + PlayableCharacter.PlayerXP + "/" + PlayableCharacter.PlayerReqXP;
        PlayerLVLTXT.text = "Level: " + PlayableCharacter.PlayerLevel;

        // Set BattleState and call next function
        State = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    public void EnemyTurn()
    {
        Debug.Log("Enemy turn now");

        // Update tracking game
        TurnCount++;
        //Set Texts
        GameTrack.text = "Battles: " + BattleCount + " || Turn: " + TurnCount;

        // Damage the player
        attackMethods.TakeDamage(EnemyCharacter.PlayerDamage, EnemyCharacter.PlayerCritical, EnemyCharacter.PlayerLuck);
        PlayerHealthTXT.text = "Health: " + PlayableCharacter.PlayerCurrHealth + "/" + PlayableCharacter.PlayerMaxHealth;
    }

    public void PlayerTurn()
    {
        switchPanel.ToggleUIPanel(DisableHUD);
        //Debug.Log("Player turn");

        Debug.Log("[PlayerTurn]: Turn count: " + TurnCount);
        // Update tracking game
        TurnCount++;
        Debug.Log("[PlayerTurn]: Turn count: " + TurnCount);
        //Set Texts
        GameTrack.text = "Battles: " + BattleCount + " || Turn: " + TurnCount;

        // Call poison action every turn
        attackMethods.Poisoning(PlayableCharacter.PlayerPoisonDmg, PlayableCharacter.PlayerPoisonTime);
        EnemyHealthTXT.text = "Health: " + EnemyCharacter.PlayerCurrHealth + "/" + EnemyCharacter.PlayerMaxHealth;

        // Toggle panel so that player cant do action
        switchPanel.ToggleUIPanel(DisableHUD);
    }

    public void EndBattle()
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

    /*void PlayerAttack()
{

    // Damage the enemy
    //bool isDead = EnemyCharacter.TakeDamage(PlayableCharacter.PlayerDamage);
    Debug.Log("I'm in playerattack");
    attackMethods.TakeDamage(PlayableCharacter.PlayerDamage);
    EnemyHealthTXT.text = "Health: " + EnemyCharacter.PlayerCurrHealth + "/" + EnemyCharacter.PlayerMaxHealth;

    //attackMethods.CheckDeath();

    // Check if the enemy is dead after attack

    //////////////if (isDead) {
        State = BattleState.WIN;
        EndBattle();
    } else {
        State = BattleState.ENEMYTURN;
        EnemyTurn();
    }/////////////////
}*/

    /*public void OnAttackButton(string functionName)
    {
        // Check if it is playerturn
        if (State != BattleState.PLAYERTURN)
            return;

        Debug.Log("State is playerturn :)");

        // Continue
        attackMethods.Invoke(functionName, 0f); //PlayerAttack();
    }*/

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

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Fight : MonoBehaviour
{
    public EnemyStats enemyScript;
    public PlayerStats playerScript;
    BattleMenu battlemenuScript;
    AreaStats scriptAreaStats;

    [Header("Texts")]
    public TMP_Text PlayerHPTxT;
    public TMP_Text EnemyHPTxT;
    public TMP_Text EnemyNameTxT;
    public TMP_Text EarnedXPTXT;
    public TMP_Text EarnedXPTXT1;
    public TMP_Text TimeLeftTXT;
    public TMP_Text SubTimeLeftTXT;

    [Header("Game Objects")]
    public GameObject enemy;
    public GameObject player;
    public Slider PlayerHPSlider;
    public Slider EnemyHPSlider;
    public GameObject[] prefabs;
    public Transform spawnPoint;
    public GameObject DefeatPanel;

    [Header("Other")]
    public int EarnedXP;
    public bool DoRewards = false;

    [Header("Private Variables")]
    private float timePPassed;
    private float timeEPassed;
    private float timeLeft;

    private int playerCurrXP;
    private int EarnedXPSc;

    void Awake() {
        int randomIndex = Random.Range(0, prefabs.Length);
        GameObject prefab = prefabs[randomIndex];
        GameObject enemyObject = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        enemyObject.name = "Enemy";
    }


    void Start() {
        enemy = GameObject.Find("Enemy");
        playerScript = player.GetComponent<PlayerStats>();
        enemyScript = enemy.GetComponent<EnemyStats>();
        battlemenuScript = GetComponent<BattleMenu>();
        scriptAreaStats = GetComponent<AreaStats>();

        playerCurrXP = PlayerPrefs.GetInt("PlayerXP", 0);
        
        EnemyNameTxT.text = "Enemy: " + enemyScript.EName;
        Time.timeScale = 1f;
    }


    void Update() {
        EarnedXPTXT.text = "+ XP: " + EarnedXP.ToString();
        EarnedXPTXT1.text = "+ XP: " + EarnedXP.ToString();

        PlayerHPTxT.text = "HP " + playerScript.Health.ToString() + "/" + playerScript.HealthMAX.ToString();
        EnemyHPTxT.text = "HP " + enemyScript.EHealth.ToString() + "/" + enemyScript.EHealthMAX.ToString();
        EnemyNameTxT.text = "Enemy: " + enemyScript.EName;

        enemy = GameObject.Find("Enemy");
        enemyScript = enemy.GetComponent<EnemyStats>();

        PlayerHPSlider.value = playerScript.Health/(float)playerScript.HealthMAX;
        EnemyHPSlider.value = enemyScript.EHealth/(float)enemyScript.EHealthMAX;

        timePPassed += Time.deltaTime;
        timeEPassed += Time.deltaTime;
        timeLeft += Time.deltaTime;

        if (timePPassed >= playerScript.AttackSpeed) {
            timePPassed = 0;

            enemyScript.EHealth -= playerScript.Attack;
        };

        if (timeEPassed >= enemyScript.EAttackSpeed) {
            timeEPassed = 0;

            playerScript.Health -= enemyScript.EAttack;
        };

        if(DoRewards == false) {
            TimeLeftTXT.text = "Time left: " +  (120 - (int)timeLeft) + "s";
            if(timeLeft >= 120) {
                timeLeft = 0;
                DoRewards = true;
            };
        } else {
            TimeLeftTXT.text = "You can now leave";
            SubTimeLeftTXT.text = "And get your rewards!";
        };

        if(enemyScript.EHealth <= 0) {
            enemyScript.EHealth = 0;
            Destroy(GameObject.Find("Enemy"));

            scriptAreaStats.CurrentLevel += 1;

            int randomIndex = Random.Range(0, prefabs.Length);
            GameObject prefab = prefabs[randomIndex];
            GameObject enemy = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            enemy.name = "Enemy";
            EnemyNameTxT.text = "Enemy: " + enemyScript.EName;

            timeEPassed = 0;
            EarnedXP += enemyScript.XPGet;
        };

        if(playerScript.Health <= 0) {
            Time.timeScale = 0f;
            playerScript.Health = 0;
            DefeatPanel.SetActive(true);
            DoRewards = true;
        };
            
    }

    public void AddRewards() {
        if(DoRewards == true) {
            EarnedXPSc = playerCurrXP + EarnedXP;
            PlayerPrefs.SetInt("PlayerXP", EarnedXPSc);

            DoRewards = false;
        }

        DefeatPanel.SetActive(false);
        SceneManager.LoadScene(0);
    }
    
}

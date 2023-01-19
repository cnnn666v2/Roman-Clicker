using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fight : MonoBehaviour
{
    public EnemyStats enemyScript;
    public PlayerStats playerScript;
    AreaStats scriptAreaStats;

    [Header("Texts")]
    public TMP_Text PlayerHPTxT;
    public TMP_Text EnemyHPTxT;

    [Header("Game Objects")]
    public GameObject enemy;
    public GameObject player;
    public Slider PlayerHPSlider;
    public Slider EnemyHPSlider;
    public GameObject[] prefabs;
    public Transform spawnPoint;

    [Header("Private Variables")]
    private float timePPassed;
    private float timeEPassed;

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
        scriptAreaStats = GetComponent<AreaStats>();
    }


    void Update() {
        PlayerHPTxT.text = "HP " + playerScript.Health.ToString() + "/" + playerScript.HealthMAX.ToString();
        EnemyHPTxT.text = "HP " + enemyScript.EHealth.ToString() + "/" + enemyScript.EHealthMAX.ToString();

        PlayerHPSlider.value = playerScript.Health/(float)playerScript.HealthMAX;
        EnemyHPSlider.value = enemyScript.EHealth/(float)enemyScript.EHealthMAX;

        timePPassed += Time.deltaTime;
        timeEPassed += Time.deltaTime;

        if (timePPassed >= playerScript.AttackSpeed) {
            timePPassed = 0;

            enemyScript.EHealth -= playerScript.Attack;
        };

        if (timeEPassed >= enemyScript.EAttackSpeed) {
            timeEPassed = 0;

            playerScript.Health -= enemyScript.EAttack;
        };

        if(enemyScript.EHealth <= 0) {
            enemyScript.EHealth = 0;
            Destroy(GameObject.Find("Enemy"));

            scriptAreaStats.CurrentLevel++;

            int randomIndex = Random.Range(0, prefabs.Length);
            GameObject prefab = prefabs[randomIndex];
            GameObject enemy = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            enemy.name = "Enemy";

            enemy = GameObject.Find("Enemy");
            enemyScript = enemy.GetComponent<EnemyStats>();
        };
            
    }
    
}

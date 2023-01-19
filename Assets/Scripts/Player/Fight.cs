using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fight : MonoBehaviour
{
    private EnemyStats _enemyScript;
    private PlayerStats playerScript;

    [Header("Texts")]
    public TMP_Text PlayerHPTxT;
    public TMP_Text EnemyHPTxT;

    [Header("Game Objects")]
    public GameObject enemy;
    public GameObject player;
    public Slider PlayerHPSlider;
    public Slider EnemyHPSlider;

    [Header("Private Variables")]
    private float timePPassed;
    private float timeEPassed;


    void Start() {
        _enemyScript = enemy.GetComponent<EnemyStats>();
        playerScript = player.GetComponent<PlayerStats>();
    }

    void Update() {
        PlayerHPTxT.text = "HP " + playerScript.Health.ToString() + "/" + playerScript.HealthMAX.ToString();
        EnemyHPTxT.text = "HP " + _enemyScript.EHealth.ToString() + "/" + _enemyScript.EHealthMAX.ToString();

        PlayerHPSlider.value = playerScript.Health/(float)playerScript.HealthMAX;
        EnemyHPSlider.value = _enemyScript.EHealth/(float)_enemyScript.EHealthMAX;

        timePPassed += Time.deltaTime;
        timeEPassed += Time.deltaTime;
        if (timePPassed >= playerScript.AttackSpeed) {
            timePPassed = 0;

            _enemyScript.EHealth -= playerScript.Attack;
        };

        if (timeEPassed >= _enemyScript.EAttackSpeed) {
            timeEPassed = 0;

            playerScript.Health -= _enemyScript.EAttack;
        };
    }
}

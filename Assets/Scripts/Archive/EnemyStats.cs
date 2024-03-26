using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Enemy main stats")]
    public string EnemyName;
    public int EnemyMaxHealth;
    public int EnemyCurrHealth;
    public int EnemyDamage;

    //[Header("Enemy Level")]
    //public int EnemyXP;
    //public int EnemyLevel;

    [Header("Enemy skills")]
    public int EnemyLuck;
}

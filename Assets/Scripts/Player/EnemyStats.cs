using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Enemy Stats")]
    public string EName;
    public int EHealth;
    public int EHealthMAX;
    public int EAttack;
    public int EAttackSpeed;
    public int EDefense;
    public int ECriticalChance;

    [Header("Enemy Types")]
    public int EType;
    public int EFreezeTime;

    // Enemy Types:
    // 1 - Green - Slime - Sends big ball in the enemy's color to the player
    // 2 - Blue - Ice - Can freeze enemies for a period of type
}

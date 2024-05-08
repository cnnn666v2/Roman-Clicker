using UnityEngine;

[CreateAssetMenu(fileName="New skill", menuName="RPG Maker/Skill")]
public class SkillSO : ScriptableObject
{
    [Header("Main Information:")]
    public string Name;
    public string Description;
    public int SkillID;
    public Sprite Icon;
    public bool isPoison, isHealer, isDamager;
    public int CostSP; // SP stands for Skill Point
    //public int CostMana;

    [Header("Special Effects:")]
    // Poisoning - P stands for Poison
    public int PDamage;
    public int PDuration;
    [Space]
    // Healing - H stands for Healing
    public int HAmount;
    [Space]
    // Damager - D stands for Di- i mean damage
    public int DAmount;
}
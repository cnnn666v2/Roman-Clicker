using UnityEngine;

[CreateAssetMenu(fileName="New spell", menuName="RPG Maker/Spell")]
public class SpellSO : ScriptableObject
{
    [Header("Main Information:")]
    public string Name;
    public string Description;
    public int SpellID;
    public Sprite Icon;
    //public int CostMana;
    public string AttackType;
}

using UnityEngine;

[CreateAssetMenu(fileName="New spell", menuName="RPG Maker/Spell")]
public class SpellSO : ScriptableObject
{
    [Header("Main Information:")]
    public string Name;
    public string Description;
    public int SpellID;
    public Sprite Icon;
    public int CostMana;

    [Header("Attack Info")]
    public string AttackName; // This should be a function name, for example "FreezeATK"
    public int Value1, Value2, Value3, Value4; // Values can be interpreted any way wanted to, not all of them has to be in use
}

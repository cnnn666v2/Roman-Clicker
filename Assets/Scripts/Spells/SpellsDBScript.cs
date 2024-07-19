using System.Collections.Generic;
using UnityEngine;

public class SpellsDBScript : MonoBehaviour
{
    public List<SpellsDB> SpellsDB = new List<SpellsDB>(); // Create a list of all spells
}

[System.Serializable]
public class SpellsDB
{
    // This will be used as a 2 value, single element list
    public int SpellID; // ID of the spell
    public SpellSO Spell; // ScriptableObject reference for the said spell
}
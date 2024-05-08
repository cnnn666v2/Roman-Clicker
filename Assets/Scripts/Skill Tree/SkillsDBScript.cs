using System.Collections.Generic;
using UnityEngine;

public class SkillsDBScript : MonoBehaviour
{
    public List<SkillsDB> SkillsDB = new List<SkillsDB>(); // Create a list of all Skills
}

[System.Serializable]
public class SkillsDB
{
    // This will be used as a 2 value, single element list
    public int skillID; // ID of the item
    public SkillSO Skill; // ScriptableObject reference for the said item
}

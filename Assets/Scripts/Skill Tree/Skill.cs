using System.Collections.Generic;
using UnityEngine;


public class Skill : MonoBehaviour
{
    // Get Skills
    [SerializeField] List<ReqSkills> previousSkills; // previous skill reference
    [SerializeField] List<ReqSkills> nextSkills; // next skill reference

    // Get lock panel
    [SerializeField] GameObject LockPanel;

    void Start()
    {
        // Iterate through list of previous skills
        for (int i = 0; i < previousSkills.Count; i++)
        {
            // If one of the skills is not unlocked
            if (!previousSkills[i].Skill.isUnlocked)
            {
                // Lock it
                LockPanel.SetActive(true);
            }
        }
    }
}

[System.Serializable]
public class SkillReference
{
    // Main info
    string Name;
    //int SkillID; // <-- might use in future

    // Skills tree info
    public bool isUnlocked; // is current skill unlocked
}

[System.Serializable]
class SkillInfo 
{
    List<SkillStats> SkillStats;
}

[System.Serializable]
public class SkillStats
{
    int Damage;
    int Heal;
}

[System.Serializable]
public class ReqSkills
{
    public SkillReference Skill;
}
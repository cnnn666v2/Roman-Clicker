using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    [SerializeField] private TogglePanel TP; // Reference toggle panel for lock/unlock
    [SerializeField] private GameObject LockPanel; // Get lock panel
    [SerializeField] private PlayerStats PS; // Get player stats

    // This script is a template for new skill tree
    // Apply it to the parent panel of a skill tree
    // ST - it's a short form for SkillTree

    // Main info
    string STName;
    bool STisUnlocked;

    // 
    int STunlockPrice;
    List<Skill> STSkills;

    private void Start()
    {
        // If skill tree is not unlocked then display lock panel
        if (!STisUnlocked)
        {
            TP.ToggleUIPanel(LockPanel);
        }
    }

    public void UnlockST()
    {
        if (!STisUnlocked)
        {
            if (SaveLoad.playerskills.SkillPoints >= STunlockPrice)
            {

            }
        }
    }
}
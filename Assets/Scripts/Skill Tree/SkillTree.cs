using UnityEngine;

public class SkillTree : MonoBehaviour
{
    [SerializeField] private PlayerStats PS; // Get player stats
    [SerializeField] private GameObject LockPanel; // Get lock panel

    // This script is a template for new skill tree
    // Apply it to the parent panel of a skill tree
    // ST - it's a short form for SkillTree

    // Main info
    string STName;
    bool STisUnlocked;

    // Sub info
    [SerializeField] int STunlockPrice;
    //List<Skill> STSkills;

    private void Start()
    {
        // If skill tree is not unlocked then display lock panel
        if (!STisUnlocked)
        {
            LockPanel.SetActive(true);
        }
    }

    public void UnlockST()
    {
        // Check if the tree is unlocked
        if (!STisUnlocked)
        {
            // If it's not then check if player has enough to unlock it
            if (SaveLoad.playerskills.SkillPoints >= STunlockPrice)
            {
                // Unlock tree
                STisUnlocked = true;

                // Remove currency
                SaveLoad.playerskills.SkillPoints -= STunlockPrice;
            }
        }
    }
}
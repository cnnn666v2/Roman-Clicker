using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillChecker : MonoBehaviour
{
    // Define Skills DB
    [SerializeField] SkillsDBScript SkillDBS;

    // Reference PlayerStats script to make local changes to the player stats
    [SerializeField] PlayerStats PS; // PS stands for PlayerStats

    // Define required and future skills, as well as the skill to unlock
    [SerializeField] SkillSO Skill;
    [SerializeField] List<SkillSO> PreviousSkills;
    [SerializeField] List<Transform> NextSkills;

    // Define wether the skills is first in the tree
    [SerializeField] bool isFirstSkill;

    // Define the lock panel for a skill
    [SerializeField] GameObject LockPanel;

    // Define the button to buy skill
    [SerializeField] Button BuyBTN;

    // Define the parent of skill game object
    [SerializeField] GameObject SkillParent;

    // Reference script to show skill stats
    [SerializeField] SkillStatsCheck StatsDisplay;


    private void Start()
    {
        // Check if player has bought current skill
        if (SaveLoad.playerskills.OwnedSkills.Contains(Skill.SkillID)){
            // Disable the lock panel
            LockPanel.SetActive(false);
        }

        // If the skill isn't first of the tree
        if (!isFirstSkill) {
            for(int i = 0;i < PreviousSkills.Count;i++) {
                // Check if player has bought all the previous skill
                if (SaveLoad.playerskills.OwnedSkills.Contains(PreviousSkills[i].SkillID)) {
                    // Enable the option to buy the skill
                    BuyBTN.interactable = true;
                }
            }
        }
    }

    public void BuySkill(int cost)
    {
        // Check if player has enough skill points
        if(SaveLoad.playerskills.SkillPoints >= cost) {
            // Remove skill point from the player
            SaveLoad.playerskills.SkillPoints -= cost;

            // Add player's skill to list
            SaveLoad.playerskills.OwnedSkills.Add(Skill.SkillID);

            // Disable lock panel
            LockPanel.SetActive(false);

            // Iterate through every child in the list
            foreach (Transform child in NextSkills) {
                //Find lockPanel with name "LockPanel"
                Transform lockPanel = child.Find("LockPanel");
                //Check if lockPanel is found
                if (lockPanel != null) {
                    //Find button in lockPanel
                    Button button = lockPanel.GetComponentInChildren<Button>();
                    //Check if button is found
                    if (button != null) {
                        //Make it interactable
                        button.interactable = true;
                    }
                }
            }

            // Modify player stats
            //Poison Stats
            if(Skill.isPoison) {
                // Add poison dmg
                PS.PlayerPoisonDmg += Skill.PDamage;
                // Add poison duration
                PS.PlayerPoisonTime += Skill.PDuration;
            }
            //Heal Stats
            if(Skill.isHealer) {
                // Add healing amount
                PS.PlayerHealing += Skill.HAmount;
            } 
            //Damage Stats
            if(Skill.isDamager) {
                // Add damage
                PS.PlayerSATK += Skill.DAmount;
            }
        }
    }

    public void DisplayStats()
    {
        // Execute method which will edit texts
        StatsDisplay.SetSkillInfo(Skill);
    }
}
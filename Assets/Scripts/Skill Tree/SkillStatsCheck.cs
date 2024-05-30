using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillStatsCheck : MonoBehaviour
{
    // Reference text fields
    [Header("Text Fields")]
    public TMP_Text SkillName;
    public TMP_Text SkillDescription, SkillTypes, SkillStats1, SkillStats2, SkillStats3;
    public Image Icon;

    public void SetSkillInfo(SkillSO Skill)
    {
        // Clear some texts
        SkillTypes.text = "";
        SkillStats1.text = "";
        SkillStats2.text = "";
        SkillStats3.text = "";

        SkillName.text = Skill.Name;
        SkillDescription.text = Skill.Description;

        Icon.sprite = Skill.Icon;

        // Code below checks if skill is of some type, if it is, then it adds the text of the
        // said type to the text field alongside some stats related to the type
        //
        // Here comes the 'if' hell
        if (Skill.isPoison) {
            SkillTypes.text += "\n- Poison";
            SkillStats1.text += "\n- <color=green>Poison <color=grey>Damage<color=white>: <color=green>+" + Skill.PDamage + "</color>";
            SkillStats1.text += "\n- <color=green>Poison <color=grey>Duration<color=white>: " + Skill.PDuration;
        }
        
        if (Skill.isDamager) {
            SkillTypes.text += "\n- Damager";
            SkillStats1.text += "\n- <color=grey>Damage<color=white>: <color=green>+" + Skill.DAmount;
        }

        if (Skill.isHealer) {
            SkillTypes.text += "\n- Healer";
            SkillStats1.text += "\n- <color=red>Heal <color=grey>Amount<color=white>: <color=green>+" + Skill.HAmount;
        }
    }
}

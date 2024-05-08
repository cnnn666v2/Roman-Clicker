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
        // Clear SkillTypes text
        SkillTypes.text = "";

        SkillName.text = Skill.Name;
        SkillDescription.text = Skill.Description;

        Icon.sprite = Skill.Icon;

        // Code below checks if skill is of some type, if it is, then it adds the text of the
        // said type to the text field
        //
        // Here comes the 'if' hell
        if (Skill.isPoison) { SkillTypes.text += "\n- Poison"; }
        if (Skill.isDamager) { SkillTypes.text += "\n- Damager"; }
        if (Skill.isHealer) { SkillTypes.text += "\n- Healer"; }
    }
}

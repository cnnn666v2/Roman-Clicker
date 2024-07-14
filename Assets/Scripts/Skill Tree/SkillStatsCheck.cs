using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class SkillStatsCheck : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] ColorStrings CS;

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
        if (Skill.isDamager) {
            SkillTypes.text += "\n- " + CS.S + "Damager</color>";
            SkillStats1.text += "\n- " + CS.GY + "Damage<color=white>: <color=green>+" + Skill.DAmount + "</color>";
        }

        if (Skill.isHealer) {
            SkillTypes.text += "\n- " + CS.R + "Healer</color>";
            SkillStats1.text += "\n- " + CS.R + "Healing <color=white>: <color=green>+" + Skill.HAmount + "<color=white>H<color=red>P</color>";
        }

        if (Skill.isPoison) {
            SkillTypes.text += "\n- " + CS.GD + "Poison</color>";
            SkillStats1.text += "\n- " + CS.GD + "Poison " + CS.GY + "Damage<color=white>: <color=green>+" + Skill.PDamage + "</color>";
            SkillStats1.text += "\n- " + CS.GD + "Poison " + "<color=white>Duration: " + CS.G + Skill.PDuration + CS.O + " Turns</color>";
        }
    }
}

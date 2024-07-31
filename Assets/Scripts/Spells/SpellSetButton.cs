using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellSetButton : MonoBehaviour
{
    GameObject SpellManager;
    SpellsDBScript SpellsDBS;

    OnClickCalls OCC;

    [SerializeField] Button SPBTN1, SPBTN2, SPBTN3, SPBTN4; //SP - Spell, BTN - Button
    [SerializeField] TMP_Text SPBTNT1, SPBTNT2, SPBTNT3, SPBTNT4; //SP - Spell, BTNT - Text inside button

    void Start()
    {
        // Clear variables for safety measures
        PlayerPrefs.SetInt("SPELL-VALUE-1", 0);
        PlayerPrefs.SetInt("SPELL-VALUE-2", 0);
        PlayerPrefs.SetInt("SPELL-VALUE-3", 0);
        PlayerPrefs.SetInt("SPELL-VALUE-4", 0);
        PlayerPrefs.SetInt("SPELL-MANA-COST", 0);

        OCC = GetComponent<OnClickCalls>();

        SpellManager = GameObject.Find("SpellsDBManager");
        SpellsDBS = SpellManager.GetComponent<SpellsDBScript>();

        // Set sprites on buttons
        SPBTN1.image.sprite = SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell1].Spell.Icon;
        SPBTN2.image.sprite = SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell2].Spell.Icon;
        SPBTN3.image.sprite = SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell3].Spell.Icon;
        SPBTN4.image.sprite = SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell4].Spell.Icon;

        // Set texts on buttons
        SPBTNT1.text = "<sprite name=\"mana\"> " + SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell1].Spell.CostMana.ToString();
        SPBTNT2.text = "<sprite name=\"mana\"> " + SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell2].Spell.CostMana.ToString();
        SPBTNT3.text = "<sprite name=\"mana\"> " + SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell3].Spell.CostMana.ToString();
        SPBTNT4.text = "<sprite name=\"mana\"> " + SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell4].Spell.CostMana.ToString();

        if (SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell1].Spell.SpellID == 0) { SPBTN1.interactable = false; SPBTNT1.text = ""; }
        if (SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell2].Spell.SpellID == 0) { SPBTN2.interactable = false; SPBTNT2.text = ""; }
        if (SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell3].Spell.SpellID == 0) { SPBTN3.interactable = false; SPBTNT3.text = ""; }
        if (SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell4].Spell.SpellID == 0) { SPBTN4.interactable = false; SPBTNT4.text = ""; }
    }

    public void SpellSlot1()
    {
        string AttackName = SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell1].Spell.AttackName;
        PlayerPrefs.SetInt("SPELL-VALUE-1", SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell1].Spell.Value1);
        PlayerPrefs.SetInt("SPELL-VALUE-2", SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell1].Spell.Value2);
        PlayerPrefs.SetInt("SPELL-VALUE-3", SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell1].Spell.Value3);
        PlayerPrefs.SetInt("SPELL-VALUE-4", SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell1].Spell.Value4);

        PlayerPrefs.SetInt("SPELL-MANA-COST", SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell1].Spell.CostMana);

        OCC.Invoke(AttackName, 0f);
    }

    public void SpellSlot2()
    {
        string AttackName = SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell2].Spell.AttackName;
        PlayerPrefs.SetInt("SPELL-VALUE-1", SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell2].Spell.Value1);
        PlayerPrefs.SetInt("SPELL-VALUE-2", SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell2].Spell.Value2);
        PlayerPrefs.SetInt("SPELL-VALUE-3", SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell2].Spell.Value3);
        PlayerPrefs.SetInt("SPELL-VALUE-4", SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell2].Spell.Value4);

        PlayerPrefs.SetInt("SPELL-MANA-COST", SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell2].Spell.CostMana);

        OCC.Invoke(AttackName, 0f);
    }

    public void SpellSlot3()
    {
        string AttackName = SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell3].Spell.AttackName;
        PlayerPrefs.SetInt("SPELL-VALUE-1", SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell3].Spell.Value1);
        PlayerPrefs.SetInt("SPELL-VALUE-2", SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell3].Spell.Value2);
        PlayerPrefs.SetInt("SPELL-VALUE-3", SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell3].Spell.Value3);
        PlayerPrefs.SetInt("SPELL-VALUE-4", SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell3].Spell.Value4);

        PlayerPrefs.SetInt("SPELL-MANA-COST", SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell3].Spell.CostMana);

        OCC.Invoke(AttackName, 0f);
    }

    public void SpellSlot4()
    {
        string AttackName = SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell4].Spell.AttackName;
        PlayerPrefs.SetInt("SPELL-VALUE-1", SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell4].Spell.Value1);
        PlayerPrefs.SetInt("SPELL-VALUE-2", SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell4].Spell.Value2);
        PlayerPrefs.SetInt("SPELL-VALUE-3", SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell4].Spell.Value3);
        PlayerPrefs.SetInt("SPELL-VALUE-4", SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell4].Spell.Value4);

        PlayerPrefs.SetInt("SPELL-MANA-COST", SpellsDBS.SpellsDB[SaveLoad.playercharacter.spell4].Spell.CostMana);

        OCC.Invoke(AttackName, 0f);
    }
}

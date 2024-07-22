using TMPro;
using UnityEngine;

public class SwitchTextBtn : MonoBehaviour
{
    [SerializeField] TMP_Text BtnTxt;
    [SerializeField] bool SwitchState;

    private void Start()
    {
        SwitchState = false;
        SwitchText();
    }
    public void SwitchText()
    {
        string text = "SPECIAL STATS";
        string text2 = "PLAYER STATS";

        if (SwitchState) { BtnTxt.text = text2; SwitchState = false; } else { BtnTxt.text = text; SwitchState = true; }
    }
}

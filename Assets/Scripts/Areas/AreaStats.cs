using UnityEngine;
using TMPro;

public class AreaStats : MonoBehaviour
{
    Fight scriptFight;
    BattleMenu scriptBM;

    [Header("Texts")]
    public TMP_Text CurrentLevelTXT;
    public TMP_Text HighScoreTXT;
    public GameObject NewHighScoreTXT;

    [Header("Variables")]
    public int CurrentLevel;
    public int AreaHS;
    public string SelectedArea;
    public int SelectedAreaGlobal;

    void Start() {
        CurrentLevel = 1;

        scriptFight = GetComponent<Fight>();
        scriptBM = GetComponent<BattleMenu>();

        SelectedAreaGlobal = PlayerPrefs.GetInt("SelAreaGlobal", 1);
        SelectedArea = "AreaHS-" + SelectedAreaGlobal.ToString();

        AreaHS = PlayerPrefs.GetInt(SelectedArea.ToString(), 1);
        HighScoreTXT.text = "Highest Level: " + AreaHS;
    }

    void Update() {
        CurrentLevelTXT.text = "Current Level: " + CurrentLevel.ToString();

        if(CurrentLevel > AreaHS) {
            PlayerPrefs.SetInt(SelectedArea, CurrentLevel);
            NewHighScoreTXT.SetActive(true);
        } else {
            NewHighScoreTXT.SetActive(false);
        }
    }
}

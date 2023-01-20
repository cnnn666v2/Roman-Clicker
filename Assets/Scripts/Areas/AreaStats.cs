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

    void Start() {
        CurrentLevel = 1;

        scriptFight = GetComponent<Fight>();
        scriptBM = GetComponent<BattleMenu>();

        AreaHS = PlayerPrefs.GetInt("AreaHS-1", 1);
        HighScoreTXT.text = "Highest Level: " + AreaHS;
    }

    void Update() {
        CurrentLevelTXT.text = "Current Level: " + CurrentLevel.ToString();

        if(CurrentLevel > AreaHS) {
            PlayerPrefs.SetInt("AreaHS-1", CurrentLevel);
            NewHighScoreTXT.SetActive(true);
        } else {
            NewHighScoreTXT.SetActive(false);
        }
    }
}

using UnityEngine;
using TMPro;

public class AreaStats : MonoBehaviour
{
    Fight scriptFight;

    [Header("Texts")]
    public TMP_Text CurrentLevelTXT;

    [Header("Variables")]
    public int CurrentLevel;

    void Start() {
        CurrentLevel = 1;
        scriptFight = GetComponent<Fight>();
    }

    void Update() {
        CurrentLevelTXT.text = "Current Level: " + CurrentLevel.ToString();
    }
}

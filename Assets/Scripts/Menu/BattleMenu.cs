using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BattleMenu : MonoBehaviour
{
    public Fight scriptFight;
    PlayerStats scriptPlayer;

    [Header("Texts")]
    public TMP_Text SelectedAreaTXT;
    public TMP_Text SAHighestScoreTXT;
    public TMP_Text SADifficultyTXT;

    //Remove later
    public TMP_Text TempTXT;

    [Header("Areas")]
    public List<string> AreaList;
    public List<string> AreaDifficultyList;
    public List<int> AreaHSList;
    public List<int> AreaSceneIndexList;

    [Header("Other")]
    public int currentIndex = 0;
    public GameObject BattleConfirmLeavePanel;

    public int EarnedXPSc;


    void Start() {
        SelectedAreaTXT.text = "Current Area: " + AreaList[currentIndex];
        SAHighestScoreTXT.text = "Highest Level: " + AreaHSList[currentIndex].ToString();
        SADifficultyTXT.text = "Difficulty: " + AreaDifficultyList[currentIndex];

        AreaHSList[0] = PlayerPrefs.GetInt("AreaHS-1", 1);
        AreaHSList[1] = PlayerPrefs.GetInt("AreaHS-2", 1);
        AreaHSList[2] = PlayerPrefs.GetInt("AreaHS-3", 1);
        AreaHSList[3] = PlayerPrefs.GetInt("AreaHS-4", 1);

        scriptFight = GetComponent<Fight>();
        scriptPlayer = GetComponent<PlayerStats>();
        scriptPlayer.PlayerXP = PlayerPrefs.GetInt("PlayerXP", 0);
        EarnedXPSc = scriptFight.EarnedXP;
    }

    public void ChangeArea() {
        currentIndex = (currentIndex + 1) % AreaList.Count;
        SelectedAreaTXT.text = "Current Area: " + AreaList[currentIndex];
        SAHighestScoreTXT.text = "Highest Level: " + AreaHSList[currentIndex].ToString();
        SADifficultyTXT.text = "Difficulty: " + AreaDifficultyList[currentIndex];
        TempTXT.text = "Area Load Scene: " + AreaSceneIndexList[currentIndex];
    }

    public void AreaLoad() {
        SceneManager.LoadScene(AreaSceneIndexList[currentIndex]);
    }

    public void MenuLoad() {
        if(BattleConfirmLeavePanel.activeInHierarchy == true)
            BattleConfirmLeavePanel.SetActive(false);
        else
            BattleConfirmLeavePanel.SetActive(true);
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void ConfirmLeavePanel() {
        if(BattleConfirmLeavePanel.activeInHierarchy == true)
            BattleConfirmLeavePanel.SetActive(false);
        else
            BattleConfirmLeavePanel.SetActive(true);

        if(Time.timeScale == 1.0f)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1.0f;
    }
}

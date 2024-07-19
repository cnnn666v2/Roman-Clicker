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

    [Header("Areas")]
    public List<string> AreaList;
    public List<string> AreaDifficultyList;
    public List<int> AreaHSList;
    public List<int> AreaSceneIndexList;
    public int SelectedAreaGlobal;

    [Header("Other")]
    public int currentIndex;
    public GameObject BattleConfirmLeavePanel;

    public int EarnedXPSc;

    void Start() {
        currentIndex = 0;
        SelectedAreaTXT.text = "Current Area: " + AreaList[currentIndex];
        SADifficultyTXT.text = "Difficulty: " + AreaDifficultyList[currentIndex];

        SelectedAreaGlobal = PlayerPrefs.GetInt("SelAreaGlobal", 1);

        AreaHSList[0] = PlayerPrefs.GetInt("AreaHS-0", 1);
        AreaHSList[1] = PlayerPrefs.GetInt("AreaHS-1", 1);
        AreaHSList[2] = PlayerPrefs.GetInt("AreaHS-2", 1);
        AreaHSList[3] = PlayerPrefs.GetInt("AreaHS-3", 1);

        scriptFight = GetComponent<Fight>();
        scriptPlayer = GetComponent<PlayerStats>();
        scriptPlayer.PlayerXP = PlayerPrefs.GetInt("PlayerXP", 0);
        EarnedXPSc = scriptFight.EarnedXP;
    }

    void Update() {
        SAHighestScoreTXT.text = "Highest Level: " + AreaHSList[currentIndex].ToString();
    }

    public void ChangeArea() {
        currentIndex = (currentIndex + 1) % AreaList.Count;
        SelectedAreaTXT.text = "Current Area: " + AreaList[currentIndex];
        SADifficultyTXT.text = "Difficulty: " + AreaDifficultyList[currentIndex];
    }

    public void AreaLoad() {
        PlayerPrefs.SetInt("SelAreaGlobal", currentIndex);
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

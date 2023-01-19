using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BattleMenu : MonoBehaviour
{
    [Header("Texts")]
    public TMP_Text SelectedAreaTXT;
    public TMP_Text SAHighestScoreTXT;
    public TMP_Text SADifficultyTXT;
    public TMP_Text TempTXT;

    [Header("Areas")]
    public List<string> AreaList;
    public List<string> AreaDifficultyList;
    public List<int> AreaHSList;
    public List<int> AreaSceneIndexList;

    [Header("Other")]
    private int currentIndex = 0;
    public GameObject BattleConfirmLeavePanel;

    void Start() {
        SelectedAreaTXT.text = "Current Area: " + AreaList[currentIndex];
        SAHighestScoreTXT.text = "Highest Level: " + AreaHSList[currentIndex].ToString();
        SADifficultyTXT.text = "Difficulty: " + AreaDifficultyList[currentIndex];
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
